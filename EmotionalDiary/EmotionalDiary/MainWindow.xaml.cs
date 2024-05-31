using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmotionalDiary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // 초기 페이지 로드
            MainFrame.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
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