using System;

namespace Console1
{
    delegate T MyDelegate3<T>(T a, T b);
    class DeleteGateT_Ex
    {
        public static void Calc<T>(T a , T b , MyDelegate3<T> dele) {
            Console.WriteLine(dele(a, b));
        }
        public static int Plus(int a, int b) { return a + b; }
        public static float Minus(float a, float b) { return a - b; }
        public static double Multiply(double a, double b) { return a * b; }
        public void Main() {
            MyDelegate3<int> s = new MyDelegate3<int>(Plus);
            MyDelegate3<float> s2 = new MyDelegate3<float>(Minus);
            MyDelegate3<double> s3 = new MyDelegate3<double>(Multiply);

            Calc(11, 22, s);  //더하기
            Calc(3.3f, 4.4f, s2); //빼기
            Calc(5.5, 6.6, s3); //곱하기
        }
    }
}


