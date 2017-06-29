using System;
using System.Linq;


namespace Console1
{
    class LINQ_Ex5
    {
        public void Main()
        {
            var start = DateTime.Now;
            //var ar = Enumerable.Range(0, 10000);   //열거 : 객체 루프가 반복될때마다 수열을 생성한다. (느리다)
            var ar = Enumerable.Range(0, 10000).ToArray();  //배열 :수열을 한번 만 생성한다. (빠르다)
            int sum = 0;
            for (int i = 0; i < ar.Count(); i++) {
                sum = sum / 2 + ar.ElementAt(i);
            }

            Console.WriteLine(sum);
            Console.WriteLine(DateTime.Now - start);
        }
    }
}


