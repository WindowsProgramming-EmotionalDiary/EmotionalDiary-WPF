using MySqlConnector;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EmotionalDiary.View
{
    public partial class CommunityPage : Page
    {
        private MySqlConnection conn;
        private int currentPageNumber = 1;

        public CommunityPage()
        {
            InitializeComponent();
            conn = MainWindow.Conn;

            // 커뮤니티 내용 조회
            LoadCommunityData(1);
        }


        private void LoadNextPage(object sender, RoutedEventArgs e)
        {
            int nextPageNumber = currentPageNumber + 1;

            // 마지막 페이지인지 여부를 확인
            if (IsLastPage(nextPageNumber))
            {
                MessageBox.Show("마지막 페이지입니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                LoadCommunityData(nextPageNumber);
                currentPageNumber = nextPageNumber;
            }
        }

        private bool IsLastPage(int pageNumber)
        {
           
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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }



        private void LoadCommunityData(int pageNumber)
        {
            int pageSize = 4; // 한 페이지에 표시할 항목 수
            int offset = (pageNumber - 1) * pageSize; // 현재 페이지의 OFFSET 값

            try
            {
                conn.Open();
                string query = $"SELECT d.title, d.content, d.emotion, c.date FROM community c JOIN diary d ON c.diary_pk = d.pk ORDER BY c.date DESC LIMIT {pageSize} OFFSET {offset}";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                CommunityStackPanel.Children.Clear();

                while (rdr.Read())
                {
                    string title = rdr.GetString("title");
                    string content = rdr.GetString("content");
                    string emotion = rdr.GetString("emotion");

                    // 감정 이미지 경로 설정
                    string imagePath = $"../Image/{emotion}.png";

                    // 각 커뮤니티 항목을 생성
                    Button communityItemButton = new Button();
                    communityItemButton.Click += Button_Click; // 클릭 이벤트 추가
                    communityItemButton.Background = Brushes.Transparent; // 투명 배경 설정
                    communityItemButton.BorderBrush = Brushes.Transparent; // 투명 테두리 설정

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

                    Image emotionImage = new Image();
                    emotionImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));

                    // StackPanel에 Grid와 Image 추가
                    grid.Children.Add(titleLabel);
                    communityItem.Children.Add(grid);
                    emotionLabel.Content = emotionImage;
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

    }
}
