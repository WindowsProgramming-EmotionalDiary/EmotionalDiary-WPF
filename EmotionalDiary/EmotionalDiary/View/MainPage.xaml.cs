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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmotionalDiary.View
{

    public partial class MainPage : Page
    {
        private MySqlConnection conn;
        public MainPage()
        {
            InitializeComponent();
            conn = MainWindow.Conn;
            LoadUserData();
        }

        private void LoadUserData()
        {

            try
            {
                string phone_num = MainWindow.password;
                // 데이터베이스 연결
                string connString = "Server=localhost;Uid=root;Database=database;port=3300;pwd=1234";
                conn = new MySqlConnection(connString);
                conn.Open();

                // 사용자 정보 조회 쿼리
                string query = "SELECT name, birth, phone_num, address FROM user WHERE phone_num = @phone_num";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@phone_num", phone_num);
                MySqlDataReader reader = cmd.ExecuteReader();

                // 조회 결과를 UI에 표시
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        myName.Text = reader.GetString("name");
                        myAge.Text = reader.GetString("birth");
                        myTel.Text = reader.GetString("phone_num");
                        myAddress.Text = reader.GetString("address");
                    }
                }
                else
                {
                    MessageBox.Show("사용자 정보가 없습니다.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("데이터베이스 연결 오류: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 새로운 창 생성 및 표시
            Window Game = new Game();
            Game.Show();
        }
    }
}
