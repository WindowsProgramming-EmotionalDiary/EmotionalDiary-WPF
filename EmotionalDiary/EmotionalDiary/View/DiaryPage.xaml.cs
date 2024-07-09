using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySqlConnector;
using OpenCvSharp;
using Newtonsoft.Json.Linq;

namespace EmotionalDiary.View
{
    public partial class DiaryPage : Page
    {
        private MySqlConnection conn;
        public static string emotion; 

        public DiaryPage()
        {
            InitializeComponent();
            conn = MainWindow.Conn;
        }

        private void CapturePhoto_Click(object sender, RoutedEventArgs e)
        {
            CapturePhotoAsync();
        }

        private async Task CapturePhotoAsync()
        {
            using (var capture = new OpenCvSharp.VideoCapture(0))
            {
                if (!capture.IsOpened())
                {
                    MessageBox.Show("카메라를 열 수 없습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                using (var frame = new OpenCvSharp.Mat())
                {
                    capture.Read(frame);

                    if (frame.Empty())
                    {
                        MessageBox.Show("카메라에서 이미지를 캡처할 수 없습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // 저장
                    string directory = @"../Image";
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string filePath = Path.Combine(directory, $"photo_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                    Cv2.ImWrite(filePath, frame);

                    MessageBox.Show($"사진이 저장되었습니다: {filePath}", "정보", MessageBoxButton.OK, MessageBoxImage.Information);
                    check_btn.Visibility = Visibility.Visible;

                    // 이미지를 플라스크 서버로 전송하여 예측
                    string predictedEmotion = await PredictEmotionAsync(filePath, ContentTextBox.Text); // 예측된 감정 저장
                    if (predictedEmotion != null)
                    {
                        emotion = predictedEmotion;
                        OnConfirmClick(emotion, new RoutedEventArgs()); // 예측된 감정을 전달하지 않고 호출
                    }

                }
            }
        }


        private async Task<string> PredictEmotionAsync(string filePath, string text)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    {
                        byte[] imageData = File.ReadAllBytes(filePath);
                        var byteArrayContent = new ByteArrayContent(imageData);
                        byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");

                        form.Add(byteArrayContent, "image", Path.GetFileName(filePath));
                        form.Add(new StringContent(text), "sentence");

                        var response = await client.PostAsync("http://pettopia.iptime.org/predict", form);
                        response.EnsureSuccessStatusCode();

                        string responseBody = await response.Content.ReadAsStringAsync();
                        var jsonResponse = JObject.Parse(responseBody);

                        if (jsonResponse.ContainsKey("predicted_emotion"))
                        {
                            return jsonResponse["predicted_emotion"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("예측 실패: " + jsonResponse["error"], "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예측 중 오류 발생: " + ex.Message, "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private void clear_btn(object sender, RoutedEventArgs e)
        {
            clearBtn.Visibility = Visibility.Collapsed;
        }

        private void OnConfirmClick(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string content = ContentTextBox.Text;

            DateTime selectedDate = DiaryCalendar.SelectedDate.HasValue ? DiaryCalendar.SelectedDate.Value : DateTime.Now;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("제목과 내용을 입력하세요.", "경고", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // 다이어리 테이블에 저장
                conn.Open();
                string query1 = "INSERT INTO diary (title, content, emotion, like_cnt, user_pk) VALUES (@Title, @Content, @Emotion, @LikeCnt, @UserId)";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                cmd1.Parameters.AddWithValue("@Title", title);
                cmd1.Parameters.AddWithValue("@Content", content);
                cmd1.Parameters.AddWithValue("@Emotion", emotion);
                cmd1.Parameters.AddWithValue("@LikeCnt", 0);
                cmd1.Parameters.AddWithValue("@UserId", View.MainPage.user_pk);
                cmd1.ExecuteNonQuery();
                long diaryPk = cmd1.LastInsertedId; // 삽입된 다이어리의 pk 가져오기
                conn.Close();

                // 공동체 테이블에 저장
                conn.Open();
                string query2 = "INSERT INTO community (date, diary_pk) VALUES (@Date, @DiaryPk)";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@DiaryPk", diaryPk); // 위에 삽입한 다이어리의 pk
                cmd2.Parameters.AddWithValue("@Date", selectedDate);
                cmd2.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("일기가 저장되었습니다.", "성공", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터베이스 오류: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void clearBtn1_Click(object sender, RoutedEventArgs e)
        {
            clearBtn1.Visibility = Visibility.Collapsed;
        }
    }
}
