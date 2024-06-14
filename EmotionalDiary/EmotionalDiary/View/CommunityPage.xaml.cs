using MySqlConnector;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EmotionalDiary.View
{
    public partial class CommunityPage : Page
    {
        private MySqlConnection conn;
        private int currentPageNumber = 1;
        private const int PageSize = 4;
        private int selectedDiaryPk;
        private bool isLiked = false;

        public CommunityPage()
        {
            InitializeComponent();
            conn = MainWindow.Conn;

            // 커뮤니티 내용 조회
            LoadCommunityData(currentPageNumber);
        }

        private void LoadNextPage(object sender, RoutedEventArgs e)
        {
            int totalNum = GetTotalCommunityItems();
            int totalPages = (int)Math.Ceiling(totalNum / (double)PageSize);

            if (currentPageNumber < totalPages)
            {
                currentPageNumber++;
                LoadCommunityData(currentPageNumber);
            }
            else
            {
                MessageBox.Show("마지막 페이지입니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private int GetTotalCommunityItems()
        {
            int totalItems = 0;

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM community";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                totalItems = Convert.ToInt32(cmd.ExecuteScalar());
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

            return totalItems;
        }

        private void LoadPreviousPage(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber--;
                LoadCommunityData(currentPageNumber);
            }
            else
            {
                MessageBox.Show("첫 번째 페이지입니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null && clickedButton.Tag != null)
            {
                int diaryPk = (int)clickedButton.Tag;
                selectedDiaryPk = diaryPk; // 선택된 다이어리 PK 저장

                heartLabel.Content = "♡";
                isLiked = false;

                try
                {
                    conn.Open();
                    string query = $"SELECT d.title, d.content, d.emotion, c.date FROM community c JOIN diary d ON c.diary_pk = d.pk WHERE d.pk = @diaryPk";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@diaryPk", diaryPk);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string title = rdr.GetString("title");
                        string content = rdr.GetString("content");
                        string emotion = rdr.GetString("emotion");
                        DateTime date = rdr.GetDateTime("date");

                        string emotionImage = GetEmojiFromEmotion(emotion); // 감정에 따른 이모지 가져오기

                        // XAML 요소 업데이트
                        TitleLabel.Content = title;
                        ContentTextBlock.Text = content;
                        EmotionImage.Content = emotionImage;
                        EmotionImage.FontSize = 30;
                        DateLabel.Content = date.ToString("yyyy.MM.dd"); // 날짜 형식 설정

                        // DetailPanel 표시
                        DetailPanel.Visibility = Visibility.Visible;
                        heartGrid.Visibility = Visibility.Visible;

                        // 하트 상태 업데이트
                        //UpdateHeartButtonState();
                    }

                    rdr.Close();
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

        private void LoadCommunityData(int pageNumber)
        {
            int offset = (pageNumber - 1) * PageSize;

            try
            {
                conn.Open();
                string query = $"SELECT c.diary_pk, d.title, d.content, d.emotion, c.date FROM community c JOIN diary d ON c.diary_pk = d.pk ORDER BY c.date DESC LIMIT {PageSize} OFFSET {offset}";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                CommunityStackPanel.Children.Clear();

                while (rdr.Read())
                {
                    int diaryPk = rdr.GetInt32("diary_pk");
                    string title = rdr.GetString("title");
                    string emotion = rdr.GetString("emotion");
                    DateTime date = rdr.GetDateTime("date");

                    string emotionImage = GetEmojiFromEmotion(emotion);

                    // 각 커뮤니티 항목을 생성
                    Button communityItemButton = new Button();
                    communityItemButton.Click += Button_Click;
                    communityItemButton.Background = Brushes.Transparent;
                    communityItemButton.BorderBrush = Brushes.Transparent;
                    communityItemButton.Tag = diaryPk;

                    StackPanel communityItem = new StackPanel();
                    communityItem.Margin = new Thickness(10);

                    Grid grid = new Grid();
                    grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9B50"));
                    grid.Height = 50;
                    grid.Width = 200;

                    TextBlock titleLabel = new TextBlock();
                    titleLabel.Text = title;
                    titleLabel.FontSize = 20;
                    titleLabel.FontWeight = FontWeights.Bold;
                    titleLabel.HorizontalAlignment = HorizontalAlignment.Center;
                    titleLabel.VerticalAlignment = VerticalAlignment.Center;
                    titleLabel.Margin = new Thickness(10, 0, 0, 0);

                    Label emotionLabel = new Label();
                    emotionLabel.Background = Brushes.White;
                    emotionLabel.Height = 50;
                    emotionLabel.Width = 200;
                    emotionLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
                    emotionLabel.FontSize = 30;
                    emotionLabel.Content = emotionImage;

                    // StackPanel에 Grid와 Label 추가
                    grid.Children.Add(titleLabel);
                    communityItem.Children.Add(grid);
                    communityItem.Children.Add(emotionLabel);

                    // 버튼에 StackPanel 추가
                    communityItemButton.Content = communityItem;

                    // 커뮤니티 스택 패널에 버튼 추가
                    CommunityStackPanel.Children.Add(communityItemButton);
                }

                rdr.Close();
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

        private void Heart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string query = "";

                if (isLiked)
                {
                    // 좋아요 취소
                    query = "UPDATE diary SET like_cnt = like_cnt - 1 WHERE pk = @diaryPk";
                    heartLabel.Content = "♡";
                    isLiked = false;
                }
                else
                {
                    // 좋아요 추가
                    query = "UPDATE diary SET like_cnt = like_cnt + 1 WHERE pk = @diaryPk";
                    heartLabel.Content = "♥";
                    isLiked = true;
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@diaryPk", selectedDiaryPk);
                cmd.ExecuteNonQuery();
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

        private string GetEmojiFromEmotion(string emotion)
        {
            switch (emotion)
            {
                case "놀람":
                    return "😲";
                case "분노":
                    return "😠";
                case "불안":
                    return "😨";
                case "상처":
                    return "🙁";
                case "슬픔":
                    return "😪";
                case "중립":
                    return "😐";
                case "행복":
                    return "😁";
                default:
                    return "";
            }
        }
    }
}
