using System;

namespace Console1
{
    delegate void MyDelegate4();
    class DeleteGateChain_Ex
    {
        public static void func0() {Console.WriteLine("1번");}
        public static void func1() { Console.WriteLine("2번"); }
        public static void func2() { Console.WriteLine("3번"); }
        
        public void Main() {
            MyDelegate4 dele;
            dele = new MyDelegate4(func0);
            dele += func1;
            dele += func2;

            dele();
            Console.WriteLine();

            dele -= func0;
            dele -= func2;

            dele();
            Console.WriteLine();
        }
    }
}


