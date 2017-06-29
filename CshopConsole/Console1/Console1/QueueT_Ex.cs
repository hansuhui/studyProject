using System;
using System.Collections.Generic;

namespace Console1
{
    class QueueT_Ex
    {
        public void Main() {
            Queue<int> que = new Queue<int>();

            que.Enqueue(10); //10
            que.Enqueue(20); //10 20
            que.Enqueue(30); //10 20 30
            que.Dequeue();   //20 30

            que.Enqueue(4); //20 30 4 
            que.Dequeue();   //30 4
            Queue<string> que2 = new Queue<string>();
            que2.Enqueue("ABC"); 

            while (que.Count > 0)
                Console.WriteLine(que.Dequeue());

            while (que2.Count > 0)
                Console.WriteLine(que2.Dequeue());

        }
    }
}


