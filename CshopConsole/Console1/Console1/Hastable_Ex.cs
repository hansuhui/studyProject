using System;
using System.Collections;

namespace Console1
{
    class Hastable_Ex
    {
        public void Main()
        {
            Hashtable ht = new Hashtable();
            ht["Apple"] = "사과";
            ht["Banana"] = "바나나";
            ht["Orange"] = "오렌지";

            Console.WriteLine(ht["Apple"]);
            Console.WriteLine(ht["Banana"]);
            Console.WriteLine(ht["Orange"]);

        }
    }
}


