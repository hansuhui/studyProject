using System;
using System.Xml.Linq;


namespace Console1
{
    class XElement_Ex
    {
        public void Main_Ex(string[] args)
        {
            int? sum = 0;
            var doc = XDocument.Parse("<root><a>1</a><a>2</a><a>3</a></root>");

            foreach (var elememt in doc.Descendants("a")) {
                var val = (int?)elememt;
                if (val != null) {
                    Console.WriteLine(val);
                    sum += val;
                }
            }

            Console.WriteLine("합계 {0}",sum);

        }
    }
    
}
