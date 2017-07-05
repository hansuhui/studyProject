using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using HtmlAgilityPack;
using System.Net;
using System.IO;


namespace Lotto_form
{
    class LottoBase
    {
        Lotto_Request Request = new Lotto_Request();

        public List<string> GetNum100()
        {
            //최근 100회차 요청
            foreach (var s in Enumerable.Range(1, 10))
            {
                Request.GetList_allWin(s.ToString());
            }

            return Request.Number_100;


        }


        public List<statByNumber> GetStat()
        {

            Request.GetList_statByNumber();
            return Request.statByNumber;

        }
        public List<Lotto_100> GetLotto100()
        {
            return Request.Lotto_100;
        }

        public Lotto_Winner GetLotto_Winner()
        {
            Request.GetList_GetResult();

            Lotto_Winner Winner = new Lotto_Winner();
            Winner.WinNum_Arr = Request.WinNum_Arr;
            Winner.WinNum_string = Request.WinNum_string;
            Winner.WinNum_Turn = Request.WinNum_Turn;
            Winner.Bouns = Request.Bouns;
            return Winner;
        }


        


    }

    public class Lotto_Request
    {
        public List<statByNumber> statByNumber = new List<statByNumber>();
        public List<string> Number_100 = new List<string>();
        public List<Lotto_100> Lotto_100 = new List<Lotto_100>();
        public string WinNum_string = "";
        public string[] WinNum_Arr;
        public string WinNum_Turn = "";
        public string Bouns = "";



        public void GetList_allWin(string Page)
        {
            Uri url = new Uri("http://nlotto.co.kr/gameResult.do?method=allWin");
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebRequestObject.Method = "POST";
            WebRequestObject.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";


            String postData = "nowPage=" + Page + "";
            byte[] sendData = UTF8Encoding.UTF8.GetBytes(postData);  // 인코딩 UTF-8
            WebRequestObject.ContentLength = sendData.Length;

            Stream dataStream = WebRequestObject.GetRequestStream();
            dataStream.Write(sendData, 0, sendData.Length);
            dataStream.Close();



            WebResponse response = WebRequestObject.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string html = reader.ReadToEnd();
            response.Close();


            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var tr = doc.DocumentNode.Element("html").Element("body").Element("section").Element("article").Element("article")
                .Element("div").Element("table").Element("tbody").Elements("tr").ToList();

            tr.RemoveAt(0);

            foreach (var s in tr)
            {
                string text = s.Element("td").InnerText;
                var td = s.Elements("td").ToList();
                if (td.Count == 8)
                {
                    Lotto_100 Data = new Lotto_100();
                    Data.No = td[0].InnerText.Trim();
                    Data.Data = td[1].InnerText.Trim();
                    Lotto_100.Add(Data);

                    foreach (var num in Data.Data.Split(','))
                    {
                        Number_100.Add(num.Trim());
                    }
                }
            }
        }

        public void GetList_statByNumber()
        {
            Uri url = new Uri("http://nlotto.co.kr/gameResult.do?method=statByNumber");
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebRequestObject.Method = "POST";
            WebRequestObject.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";


            Stream dataStream = WebRequestObject.GetRequestStream();
            WebResponse response = WebRequestObject.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string html = reader.ReadToEnd();
            response.Close();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var tr = doc.DocumentNode.Element("html").Element("body").Element("section").Element("article").Element("article")
                .Element("div").Element("table").Element("tbody").Elements("tr").ToList();
            tr.RemoveAt(0);





            foreach (var s in tr)
            {
                string text = s.Element("td").InnerText;
                var td = s.Elements("td").ToList();
                if (td.Count == 3)
                {

                    statByNumber Data = new statByNumber();
                    string Number = td[0].Element("img").Attributes[1].Value;
                    Number = Number.Substring(0, Number.Length - 2);
                    Data.Number = Number.Trim();
                    Data.stat = Convert.ToInt32(td[2].InnerText);
                    statByNumber.Add(Data);
                }
            }
        }

        public void GetList_GetResult()
        {
            Uri url = new Uri("http://www.nlotto.co.kr/gameResult.do?method=byWin");
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebRequestObject.Method = "POST";
            WebRequestObject.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";


            Stream dataStream = WebRequestObject.GetRequestStream();
            WebResponse response = WebRequestObject.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string html = reader.ReadToEnd();
            response.Close();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var num_img = doc.DocumentNode.Element("html").Element("body").Element("section").Element("article").Element("article").Element("div").Elements("div").ElementAt(1).Element("p").Elements("img");


            Bouns = doc.DocumentNode.Element("html").Element("body").Element("section").Element("article").Element("article").Element("div").Elements("div").ElementAt(1).Element("p").Elements("span").ElementAt(1).Element("img").Attributes.ElementAt(1).Value;

            WinNum_Turn = doc.DocumentNode.Element("html").Element("body").Element("section").Element("article").Element("article").Element("div").Elements("div").ElementAt(1).Element("h3").Element("strong").InnerText;


            foreach (var s in num_img)
            {

                if (s.Attributes.Count == 2)
                {
                    string num = s.Attributes.ElementAt(1).Value.ToString().Trim();

                    if (string.IsNullOrEmpty(WinNum_string))
                    {
                        WinNum_string = num;
                    }
                    else {
                        WinNum_string += "," + num;
                    }

                }
            }

            WinNum_Arr = WinNum_string.Split(',');

        }
    }

    public class statByNumber
    {
        public string Number { get; set; }
        public int stat { get; set; }
    }

    public class Lotto_100
    {
        public string No { get; set; }
        public string Data { get; set; }
    }

    public class Lotto_Winner
    {
        public string WinNum_string { get; set; }
        public string[] WinNum_Arr { get; set; }
        public string WinNum_Turn { get; set; }
        public string Bouns { get; set; }
        
    }


    




}
