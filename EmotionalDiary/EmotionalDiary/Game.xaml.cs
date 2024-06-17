using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace EmotionalDiary
{
    public partial class Game : Window
    {
        List<TextBlock> display_TextBlock = new List<TextBlock>();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer reaction = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();
        float displayTime;                                                //숫자 띄어줄 시간 계산 변수
        float reactionTime;                                               //반응속도 계산 변수
        int problemNum = 0;                                             //문제 개수
        int answerNum = 0;                                              //정답 개수
        float totalReactionTime = 0;                                    //반응속도 배열
        int[] rndNum = new int[16];                                     //랜덤 숫자 배열
        List<TextBlock> textBlocks = new List<TextBlock>();
        Random rnd = new Random();
        string[] answerArray = { };
        string[] inputArray = { };


        public Game()
        {
            InitializeComponent();
            textBlocks = mainGrid.Children.OfType<TextBlock>().ToList();
            timer.Interval = TimeSpan.FromSeconds(0.01);    //0.01초 단위
            reaction.Interval = TimeSpan.FromSeconds(0.01); //0.01초 단위
            timer.Tick += display_Tick;                       //
            reaction.Tick += reaction_Tick;
            SetUpGame();                                    //게임 시작
        }

        private void display_Tick(object sender, EventArgs e)
        {

            displayTime++;                                                          //시간 계산

            if ((displayTime / 100F) % 3 == 0)
            {
                timer.Stop();
                reaction.Start();
                textBlocks[rnd.Next(0, textBlocks.Count)].Visibility = Visibility.Visible;
            }

            if (problemNum == 5)           //
            {
                timer.Stop();
                reaction.Stop();
                changeScreen();
            }
        }

        private void reaction_Tick(object sender, EventArgs e)
        {
            TextBlock temp = new TextBlock();
            temp.Text = "반응 속도 : ";

            reactionTime += 1.6f;

            TimeTextBlock.Text = temp.Text + (reactionTime / 100F).ToString("0.000s");    //시간 출력
        }

        private void SetUpGame()
        {
            int i = 0;

            foreach (TextBlock textBlock in textBlocks)      //4*4 공간에 랜덤 숫자 생성(안보이게)
            {
                if (textBlock.Name != "TimeTextBlock")
                {
                    textBlock.Visibility = Visibility.Hidden;
                    rndNum[i] = rnd.Next(1, 100);
                    textBlock.Text = rndNum[i].ToString();
                    i++;
                }
            }
            timer.Start();
            totalReactionTime = 0;
            answerNum = 0;
            TimeTextBlock.Text = "숫자가 표시됩니다, 눌러주세요! \n 눌리는 숫자를 외워야 합니다!";
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point ClickPos = e.GetPosition((IInputElement)sender);


            double ClickPosX = ClickPos.X;
            double ClickPosY = ClickPos.Y;

            TextBlock textBlock = sender as TextBlock;

            textBlock.Visibility = Visibility.Hidden;

            inputArray = inputArray.Concat(new string[] { textBlock.Text }).ToArray();
            answerArray = answerArray.Concat(new string[] { textBlock.Text }).ToArray();

            reaction.Stop();
            problemNum++;
            totalReactionTime += reactionTime / 100F;

            timer.Start();
            reactionTime = 0;
        }

        private void changeScreen()
        {
            gameScreen.Visibility = Visibility.Hidden;
            answerScreen.Visibility = Visibility.Visible;
            output.Visibility = Visibility.Hidden;
        }

        private void Average()
        {
            average_response.Text = "평균 반응속도 : " + Math.Round(totalReactionTime / problemNum, 3) + "초";
        }
        private void AnswerNum()
        {
            answer_num.Text = "정답 개수 : " + answerNum + "개";
        }

        private void Try()
        {
            try_again.Visibility = Visibility.Visible;
            try_again.Text = "다시 하시겠습니까?";
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool last_enter = false;

            if (e.Key == Key.Enter)
            {
                TextBox currentTextBox = sender as TextBox;

                // 현재 TextBox의 값을 해당 변수에 저장
                if (currentTextBox != null)
                {
                    if (currentTextBox.Name == "TextBox1")
                    {
                        inputArray[0] = currentTextBox.Text;
                    }
                    else if (currentTextBox.Name == "TextBox2")
                    {
                        inputArray[1] = currentTextBox.Text;
                    }
                    else if (currentTextBox.Name == "TextBox3")
                    {
                        inputArray[2] = currentTextBox.Text;
                    }
                    else if (currentTextBox.Name == "TextBox4")
                    {
                        inputArray[3] = currentTextBox.Text;
                    }
                    else if (currentTextBox.Name == "TextBox5")
                    {
                        inputArray[4] = currentTextBox.Text;
                        last_enter = true;
                    }
                    currentTextBox.IsEnabled = false;
                }

                // 다음 컨트롤로 포커스 이동
                TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Next);
                if (Keyboard.FocusedElement is UIElement keyboardFocus)
                {
                    keyboardFocus.MoveFocus(tRequest);
                }
            }
            if (last_enter == true)
            {
                last_enter = false;
                Average();
                AnserCheck();
                AnswerNum();
                setResponseTimeAge();
                setMemoryAge();
                Try();
                //try_again.Text = inputArray[0] + " "  + inputArray[1] + " " + inputArray[2] + " " + inputArray[3] + " " + inputArray[4] + " " + answerArray[0] + "\n " + answerArray[1] + " " + answerArray[2] + " " + answerArray[3] + " " + answerArray[4];
                reaction_age.Visibility = Visibility.Visible;
                memory_age.Visibility = Visibility.Visible;
                ok.Visibility = Visibility.Visible;
                no.Visibility = Visibility.Visible;
                output.Visibility = Visibility.Visible;
            }
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            gameScreen.Visibility = Visibility.Visible;
            answerScreen.Visibility = Visibility.Hidden;
            problemNum = 0;
            totalReactionTime = 0;
            average_response.Text = string.Empty;
            TextBox1.IsEnabled = true;
            TextBox2.IsEnabled = true;
            TextBox3.IsEnabled = true;
            TextBox4.IsEnabled = true;
            TextBox5.IsEnabled = true;
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            try_again.Text = "";

            answerArray = [];
            inputArray = [];

            try_again.Visibility = Visibility.Hidden;
            ok.Visibility = Visibility.Hidden;
            no.Visibility = Visibility.Hidden;

            SetUpGame();
        }
        private void AnserCheck()
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == answerArray[i])
                {
                    answerNum++;
                }
            }
        }

        private void setResponseTimeAge()
        {
            double responseTimeAge = Math.Round(totalReactionTime / problemNum, 3);

            if (responseTimeAge <= 0.9)
            {
                responseAge.Text = "20대";
            }
            else if (responseTimeAge < 1)
            {
                responseAge.Text = "30대";
            }
            else if (responseTimeAge < 1.05)
            {
                responseAge.Text = "40대";
            }
            else if (responseTimeAge < 1.1)
            {
                responseAge.Text = "50대";
            }
            else if (responseTimeAge < 1.2)
            {
                responseAge.Text = "60대";
            }
            else if (responseTimeAge < 1.3)
            {
                responseAge.Text = "70대";
            }
            else
            {
                responseAge.Text = "80대";
            }
        }

        private void setMemoryAge()
        {
            Dictionary<int, string> ageMap = new Dictionary<int, string>()
            {
                {5, "20대"},
                {4, "40대"},
                {3, "50대"},
                {2, "60대"},
                {1, "70대"},
                {0, "80대"}
            };

            memoryAge.Text = ageMap[answerNum];
        }
    }
}
