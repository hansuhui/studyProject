using System;
using System.Linq;


namespace Console1
{
  
    class InSu_Ex
    {


        private static void dumpPersons(int s = 0, int s2 = 0, int s3 =0 , int s4 = 0) {
             Console.WriteLine("s = {0},s2 = {1},s3 = {2},s4 = {3}", s, s2, s3, s4);
        }
        public void Main()
        {
            //직접 지정 가능
            dumpPersons(10 ,s4 : 10);
        }
    }
}


