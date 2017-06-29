using System;
using System.Collections.Generic;

namespace Console1
{
    class StackT_Ex
    {
        public void Main() {
            Stack<int> stack = new Stack<int>();

            stack.Push(10); //10
            stack.Push(20); //10 20
            stack.Push(30); //10 20 30
            stack.Pop();   //10 20 
            stack.Pop();   //10 


            Stack<string> stack2= new Stack<string>();
            stack2.Push("셋");
            stack2.Push("Set");

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());

            while (stack2.Count > 0)
                Console.WriteLine(stack2.Pop());

        }
    }
}


