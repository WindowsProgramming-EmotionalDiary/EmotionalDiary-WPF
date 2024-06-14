using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmotionalDiary.View
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Window
    {

        public Main()
        {
            InitializeComponent();

            MySqlConnection conn = MainWindow.Conn;
            // 초기 페이지 로드
            MainFrame.Navigate(new Uri("View/MainPage.xaml", UriKind.Relative));
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                TabItem selectedTab = ((TabControl)e.Source).SelectedItem as TabItem;
                if (selectedTab != null)
                {
                    string pageUri = selectedTab.Tag.ToString();
                    MainFrame.Navigate(new Uri(pageUri, UriKind.Relative));
                }
            }
        }
    }
}
