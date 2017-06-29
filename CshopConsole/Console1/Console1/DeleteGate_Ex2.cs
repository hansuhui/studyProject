using System;

namespace Console1
{
    delegate int MyDelegate2(int a, int b);
    class DeleteGate_Ex2
    {
        public static void Calc(int a , int b , MyDelegate2 dele) {
            Console.WriteLine(dele(a, b));
        }
        public static int Plus(int a, int b) { return a + b; }
        public static int Minus(int a, int b) { return a - b; }
        public static int Multiply(int a, int b) { return a * b; }
        public void Main() {
            MyDelegate2 s = new MyDelegate2(Plus);
            MyDelegate2 s2 = new MyDelegate2(Minus);
            MyDelegate2 s3 = new MyDelegate2(Multiply);

            Calc(11, 22, s);  //더하기
            Calc(33, 22, s2); //빼기
            Calc(11, 22, s3); //곱하기
        }
    }
}


