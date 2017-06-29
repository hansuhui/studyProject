

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using Newtonsoft.Json;
using System.Collections.Generic;

//
namespace JsMemberPush
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void radioButton_Type_Checked(object sender, RoutedEventArgs e)
        {
            textBox_Token.Text = "";
            textBox_Token.IsReadOnly = true;
            
        }

        private void radioButton_Type1_Checked(object sender, RoutedEventArgs e)
        {
            textBox_Token.Text = "";
            textBox_Token.IsReadOnly = false;
        }

        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_ReSet_Click(object sender, RoutedEventArgs e)
        {
            radioButton_Type.IsChecked = true;
            textBox_Token.Text = "";
            textBox_Title.Text = "";
            textBox_Msg.Text = "";
        }

        private void button_submit_Click(object sender, RoutedEventArgs e)
        {
            bool Check = true;
            List<TextBox> TextBox = new List<TextBox>();

            if ((bool)!radioButton_Type.IsChecked)
            {
                //TextBox.Add(textBox_Token);
            }

            TextBox.Add(textBox_Title);
            TextBox.Add(textBox_Msg);
            

            if (TextBoxCheck(TextBox)) Check = false;


            if (Check)
            {
                string message = textBox_Msg.Text;
                string title = textBox_Title.Text;
                List<string> Tokens = new List<string>();

                Dictionary<string, object> postData = new Dictionary<string, object>();
                postData.Add("notification", new { title = title, body = message , icon = "https://www.google.co.kr/images/branding/googlelogo/2x/googlelogo_color_120x44dp.png" });
                postData.Add("data", new { Test = "테스트" });

                //전체일때
                if ((bool)radioButton_Type.IsChecked)
                {
                    //1~1,000개 까지 가능
                    Tokens.Add("Tokens");
                    Tokens.Add("Tokens");
                    postData.Add("registration_ids", Tokens);
                    GoPush(postData);
                }
                //개인일때
                else
                {
                    string Token = textBox_Token.Text;
                    postData.Add("to", Token);
                    GoPush(postData);
                }
            }
        }



        void GoPush(object postData)
        {

            //서버키
            string GoogleAppID = "User_Key";

            string resultStr = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8;";
            request.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));

            //Linq to json
            string contentMsg = JsonConvert.SerializeObject(postData);

            Byte[] byteArray = Encoding.UTF8.GetBytes(contentMsg);
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                resultStr = reader.ReadToEnd();
                Debug.WriteLine("response: " + resultStr);
                reader.Close();
                responseStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                resultStr = ex.Message;
                Debug.WriteLine(ex.Message);
            }

            MessageBox.Show(resultStr, "결과");
        }


        public bool TextBoxCheck(List<TextBox> List)
        {
            bool check = false;

            foreach (TextBox s in List)
            {
                if (string.IsNullOrEmpty(s.Text))
                {
                    MessageBox.Show(s.ToolTip + "을(를) 입력해 주세요.", "에러", MessageBoxButton.OK, MessageBoxImage.Error);
                    s.Focus();
                    check = true;
                    break;
                }

            }

            return check;

        }
    }


}
