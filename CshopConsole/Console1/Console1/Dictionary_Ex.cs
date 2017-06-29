using System;
using System.Collections.Generic;

namespace Console1
{
    class Dictionary_Ex
    {
        public void Main() {
            Dictionary<string, int> dt = new Dictionary<string, int>();
            dt["1"] = 1;
            dt["2"] = 2;
            dt["3"] = 3;

            Console.WriteLine("1 : "+dt["1"]);
            Console.WriteLine("2 : "+dt["2"]);
            Console.WriteLine("e : "+dt["3"]);

        }
    }
}


