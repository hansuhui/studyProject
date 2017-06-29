using System;
using System.Collections;

namespace Console1
{
    class Queue_Ex
    {
        public void Main() {
            Queue que = new Queue();

            que.Enqueue(10); //10
            que.Enqueue(20); //10 20
            que.Enqueue(30); //10 20 30
            que.Dequeue();   //20 30

            que.Enqueue(4.4); //20 30 4.4
            que.Dequeue();   //30 4.4
            que.Enqueue("ABC"); //30 4.4 ABC

            while (que.Count > 0)
                Console.WriteLine(que.Dequeue());

        }
    }
}


