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
        public static string password;

        public MainWindow()
        {
            InitializeComponent();
            Conn = new MySqlConnection("Server=localhost;Uid=root;Database=database;port=3300;pwd=1234");
            userPk = 1;
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            // 전화번호 중복 확인
            MySqlCommand checkPhoneNumCmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE phone_num = @phone_num", Conn);
            checkPhoneNumCmd.Parameters.AddWithValue("@phone_num", tel.Text);
            Conn.Open();
            int count = Convert.ToInt32(checkPhoneNumCmd.ExecuteScalar());
            Conn.Close();

            if (count > 0)
            {
                MessageBox.Show("이미 등록된 전화번호입니다.");
                return;
            }
            else
            {
                if (id.Text.Length == 0)
                {
                    MessageBox.Show("이름을 입력해주세요.");
                    return;
                }
                if (sex.Text.Length == 0)
                {
                    MessageBox.Show("성별을 입력해주세요.");
                    return;
                }
                if (birth.Text.Length == 0)
                {
                    MessageBox.Show("생년월일을 입력해주세요");
                    return;
                }
                if (tel.Text.Length == 0)
                {
                    MessageBox.Show("전화번호를 입력해주세요");
                    return;
                }
                if (address.Text.Length == 0)
                {
                    MessageBox.Show("주소를 입력해주세요");
                    return;
                }
                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO user(create_at, name, phone_num, birth, address, sex) VALUES (@create_at, @name, @phone_num, @birth, @address, @sex)", Conn);

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@create_at", DateTime.Now);
                    cmd.Parameters.AddWithValue("@name", id.Text);
                    cmd.Parameters.AddWithValue("@phone_num", tel.Text);
                    cmd.Parameters.AddWithValue("@birth", birth.Text);
                    cmd.Parameters.AddWithValue("@address", address.Text);
                    cmd.Parameters.AddWithValue("@sex", sex.Text);
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("회원가입이 완료되었습니다.");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Conn.Close();
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(login_id.Text))
            {
                MessageBox.Show("이름을 입력해주세요.");
                return;
            }

            if (string.IsNullOrEmpty(login_passward.Text))
            {
                MessageBox.Show("전화번호를 입력해주세요.");
                return;
            }

            try
            {
                string loginQuery = "SELECT * FROM user WHERE name = @name AND phone_num = @phone_num";
                MySqlCommand loginCmd = new MySqlCommand(loginQuery, Conn);
                loginCmd.Parameters.AddWithValue("@name", login_id.Text);
                loginCmd.Parameters.AddWithValue("@phone_num", login_passward.Text);

                Conn.Open();
                MySqlDataReader reader = loginCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // 로그인 성공
                    MessageBox.Show("로그인 성공!");
                    password = login_passward.Text;
                    View.Main main = new View.Main();
                    main.Show();
                    this.Close();
                }
                else
                {
                    // 로그인 실패
                    MessageBox.Show("이름 또는 전화번호가 잘못되었습니다.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

    }
}