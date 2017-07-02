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

        public List<string>  GetNum100()
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
        public List<Lotto_100> GetLotto100() {
            return Request.Lotto_100;
        }


    }

    public class Lotto_Request
    {
        public List<statByNumber> statByNumber = new List<statByNumber>();
        public List<string> Number_100 = new List<string>();
        public List<Lotto_100> Lotto_100 = new List<Lotto_100>();
        

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
                        Number_100.Add(num);
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
                    Data.Number = Number;
                    Data.stat = Convert.ToInt32(td[2].InnerText);
                    statByNumber.Add(Data);
                }
            }
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


}
