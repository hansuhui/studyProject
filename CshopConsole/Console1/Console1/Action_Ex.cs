using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class Action_Ex
    {
        static void temp(string name) {
            Console.WriteLine("name : {0}", name);
        }
        public void Main_Ex(string[] args)
        {
            int sum = 0;

            Action act0 = () => Console.WriteLine("name: act0");
            Action<string> act1 = new Action<string>(temp);
            Action<string, string> act2 = (name,age) => 
            {
                Console.WriteLine("name : {0}", name);
                Console.WriteLine("age : {0}", age);
            };

            Action<int, int, int> act3 = (a, b, c) => sum = a + b +c;

            act0();
            act1("act1");
            act2("act1","29");
            act3(100, 20, 3);

            Console.WriteLine("sum : {0}", sum);

        }
    }
}
