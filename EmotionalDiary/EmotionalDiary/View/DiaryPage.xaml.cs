using System;
using System.Windows;
using System.Windows.Controls;
using MySqlConnector;

namespace EmotionalDiary.View
{
    public partial class DiaryPage : Page
    {
        private MySqlConnection conn;

        public DiaryPage()
        {
            InitializeComponent();
            conn = MainWindow.Conn;
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
                cmd1.Parameters.AddWithValue("@Emotion", "불안");
                cmd1.Parameters.AddWithValue("@LikeCnt", 0);
                cmd1.Parameters.AddWithValue("@UserId", MainWindow.userPk);
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
    }
}
