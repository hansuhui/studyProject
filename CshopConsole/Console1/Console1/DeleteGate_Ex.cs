using System;
using System.Collections.Generic;

namespace Console1
{
    delegate int MyDelegate(int a, int b);
    class DeleteGate_Ex
    {
        public static int Plus(int a, int b) { return a + b; }
        public static int Minus(int a, int b) { return a - b; }
        public void Main() {
            MyDelegate s; 
             s = new MyDelegate(Plus);
            Console.WriteLine(s(11, 22));

            s = new MyDelegate(Minus);
            Console.WriteLine(s(22,11 ));
        }
    }
}


