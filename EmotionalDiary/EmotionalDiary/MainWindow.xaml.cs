using System;
using System.Windows;
using System.Windows.Controls;
using MySqlConnector;

namespace EmotionalDiary
{
    public partial class MainWindow : Window
    {
        public static MySqlConnection Conn { get; private set; }
        public static int userPk;

        public MainWindow()
        {
            InitializeComponent();
            Conn = new MySqlConnection("Server=localhost;Uid=root;Database=database;port=3300;pwd=1234");
            userPk = 1;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //로그인 검증 로직을 추가.

            // 로그인 성공 시 MainWindow로 전환
            View.Main main = new View.Main();
            main.Show();
            this.Close();
        }
    }
}
