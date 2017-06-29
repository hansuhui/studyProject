using System;
using System.Collections.Generic;

namespace Console1
{
  
    class ListT_Ex
    {        
        public void Main() {
            List<int> list1 = new List<int>();
            list1.Add(11); list1.Add(22); list1.Add(33);
            list1.RemoveAt(1);
            list1.Remove(11);
            list1.Insert(0, 44);

            foreach (var i in list1) {
                Console.WriteLine(i);
            }

            List<string> list2 = new List<string>();
            list2.Add("가"); list2.Add("나"); list2.Add("다");
            list2.RemoveAt(1);
            list2.Remove("가");
            list2.Insert(1, "라");

            foreach (var i in list2)
            {
                Console.WriteLine(i);
            }

        }
    }
}


