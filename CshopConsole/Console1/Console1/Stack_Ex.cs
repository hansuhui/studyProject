using System;
using System.Collections;

namespace Console1
{
    class Stack_Ex
    {
        public void Main() {
            Stack stack = new Stack();

            stack.Push(10); //10
            stack.Push(20); //10 20
            stack.Push(30); //10 20 30
            stack.Pop();   //10 20 
            stack.Pop();   //10 

            stack.Push(4.4); //10 4.4
            stack.Push("ABC"); //10 4.4 ABC

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());

        }
    }
}


