using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsMemberPush_Ionic
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
                string tokens = textBox_Token.Text;
                Dictionary<string, object> postData = new Dictionary<string, object>();
                postData.Add("profile", "user_profile");
                
                
                postData.Add("notification"
                    , new
                    {
                        title = title,
                        message = message,
                        payload = new { Page = "Test", Alert = "1" }
                        //,android = new {
                        //    icon = "res://drawable-hdpi/icon.png",
                        //    sound = "file://assets/sound/sound-effect.mp3"

                        //}
                    }
                    );


                //전체일때
                if ((bool)radioButton_Type.IsChecked)
                {
                    postData.Add("send_to_all", true);
                    GoPush(postData);
                }
                //개인일때
                else
                {
                    postData.Add("tokens", tokens);
                    GoPush(postData);
                }
            }
        }


        void GoPush(object postData)
        {


            string resultStr = "";
            //https://api.ionic.io/push/tokens

            string url = "https://api.ionic.io";
            url += "/push/notifications";
            //url += "/push/tokens";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8;";
            request.Headers.Add(string.Format("Authorization: Bearer {0}", "User_Key"));

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
