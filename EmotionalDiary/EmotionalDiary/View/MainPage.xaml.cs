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
using System.Data.SqlClient;
using System.Collections;
using System.CodeDom;

namespace EmotionalDiary.View
{

    public partial class MainPage : Page
    {
        private MySqlConnection conn;
        public static int user_pk = -1;
        private string phone_num = "";
        public MainPage()
        {
            InitializeComponent();
            conn = MainWindow.Conn;
            LoadUserData1();
            LoadUserData2();
            LoadUserData3();
            conn = MainWindow.Conn;
            LoadUserData4();
        }

        private void LoadUserData1()
        {

            try
            {
                phone_num = MainWindow.password;
                // 데이터베이스 연결
                string connString = "Server=localhost;Uid=root;Database=database;port=3300;pwd=1234";
                conn = new MySqlConnection(connString);

                conn.Open();
                

                string selectQuery = "SELECT pk FROM user WHERE phone_num = @phone_num";
                MySqlCommand pkCmd = new MySqlCommand(selectQuery, conn);
                pkCmd.Parameters.AddWithValue("@phone_num", phone_num);
                MySqlDataReader pkReader = pkCmd.ExecuteReader();

                if (pkReader.Read())
                {
                    user_pk = pkReader.GetInt32(0);
                }

                
                conn.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("데이터베이스 연결 오류: " + ex.Message);
            }
            finally
            {

            }
        }

        private void LoadUserData2()
        {
            conn.Open();
            

            // 사용자 정보 조회 쿼리
            string myInfoQuery = "SELECT name, birth, phone_num, address FROM user WHERE phone_num = @phone_num";
            MySqlCommand myInfoCmd = new MySqlCommand(myInfoQuery, conn);
            myInfoCmd.Parameters.AddWithValue("@phone_num", phone_num);
            MySqlDataReader myInfoReader = myInfoCmd.ExecuteReader();

            // 조회 결과를 UI에 표시
            if (myInfoReader.HasRows)
            {
                while (myInfoReader.Read())
                {
                    myName.Text = myInfoReader.GetString("name");
                    myAge.Text = myInfoReader.GetString("birth");
                    myTel.Text = myInfoReader.GetString("phone_num");
                    myAddress.Text = myInfoReader.GetString("address");
                }
            }
            
            conn.Close();
        }

        private void LoadUserData3()
        {
            conn.Open();
            string query = "SELECT to_do1, to_do2, to_do3, to_do4, to_do5, CHECK1, CHECK2, CHECK3, CHECK4, CHECK5 " +
               "FROM to_do_list " +
               "WHERE user_pk = @pk AND date = @date";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@pk", user_pk);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.AddYears(0).ToString("yyyy-MM-dd"));
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    todo1.Text = reader.GetString("to_do1");
                    todo2.Text = reader.GetString("to_do2");
                    todo3.Text = reader.GetString("to_do3");
                    todo4.Text = reader.GetString("to_do4");
                    todo5.Text = reader.GetString("to_do5");
                    check1.IsChecked = reader.GetBoolean("CHECK1");
                    check2.IsChecked = reader.GetBoolean("CHECK2");
                    check3.IsChecked = reader.GetBoolean("CHECK3");
                    check4.IsChecked = reader.GetBoolean("CHECK4");
                    check5.IsChecked = reader.GetBoolean("CHECK5");
                }
                conn.Close();
            }
        }

        private void LoadUserData4()
        {
            try
            {
                conn.Open();
                // 사용자 정보 조회 쿼리


                string myInfoQuery = "SELECT d.emotion FROM diary d JOIN community c ON d.pk = c.diary_pk WHERE d.user_pk = @pk AND DATE(c.date) = CURDATE() ORDER BY d.pk DESC LIMIT 1;";
                MySqlCommand myInfoCmd = new MySqlCommand(myInfoQuery, conn);
                
                myInfoCmd.Parameters.AddWithValue("@pk", user_pk);
                MySqlDataReader myInfoReader = myInfoCmd.ExecuteReader();

                // 조회 결과를 UI에 표시
                if (myInfoReader.HasRows)
                {
                    while (myInfoReader.Read())
                    {
                        string res = myInfoReader.GetString("emotion");
                        res = GetEmojiFromEmotion(res);

                        ToDayEmotion.Text += " " + res;
                    }
                }
                conn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }


        private void exit_buttonClick(object sender, RoutedEventArgs e)
        {
            try
            {

                string query = "";
                conn = MainWindow.Conn;
                conn.Open();
                conn.OpenAsync();

                string selectQuery = "SELECT * FROM to_do_list WHERE DATE = @date AND user_pk = @user_pk";
                MySqlCommand checkCmd = new MySqlCommand(selectQuery, conn);
                checkCmd.Parameters.AddWithValue("@date", DateTime.Now.AddYears(0).ToString("yyyy-MM-dd"));
                checkCmd.Parameters.AddWithValue("@user_pk", user_pk);
                MySqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    query = "UPDATE to_do_list SET to_do1 = @todo1, to_do2 = @todo2, to_do3 = @todo3, to_do4 = @todo4, to_do5 = @todo5, user_pk = @user_pk, DATE = @date, CHECK1 = @check1, CHECK2 = @check2, CHECK3 = @check3, CHECK4 = @check4, CHECK5 = @check5 WHERE user_pk = @user_pk  AND DATE = @date";
                }
                else
                {
                    query = "INSERT INTO to_do_list( to_do1, to_do2, to_do3, to_do4, to_do5, user_pk, date, CHECK1, CHECK2, CHECK3, CHECK4, CHECK5) VALUES (@todo1, @todo2, @todo3, @todo4, @todo5, @user_pk, @date, @check1, @check2, @check3, @check4, @check5)";
                }

                conn.CloseAsync();
                conn.Close();


                MySqlConnection connection = MainWindow.Conn;

                connection.Open();
                connection.OpenAsync();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@todo1", todo1.Text);
                cmd.Parameters.AddWithValue("@todo2", todo2.Text);
                cmd.Parameters.AddWithValue("@todo3", todo3.Text);
                cmd.Parameters.AddWithValue("@todo4", todo4.Text);
                cmd.Parameters.AddWithValue("@todo5", todo5.Text);
                cmd.Parameters.AddWithValue("@user_pk", user_pk);

                cmd.Parameters.AddWithValue("@date", DateTime.Now.AddYears(0).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@check1", check1.IsChecked.GetValueOrDefault());
                cmd.Parameters.AddWithValue("@check2", check2.IsChecked.GetValueOrDefault());
                cmd.Parameters.AddWithValue("@check3", check3.IsChecked.GetValueOrDefault());
                cmd.Parameters.AddWithValue("@check4", check4.IsChecked.GetValueOrDefault());
                cmd.Parameters.AddWithValue("@check5", check5.IsChecked.GetValueOrDefault());
                cmd.ExecuteNonQuery();
                connection.CloseAsync();
                connection.Close();
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                // 예외 처리 로직
                //MessageBox.Show($"Error occurred: {ex.Message}");
            }
        }



        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 새로운 창 생성 및 표시
            Window Game = new Game();
            Game.Show();
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
                case "혐오": //감정일기로는 상처
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
