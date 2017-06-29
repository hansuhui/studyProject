using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class Func2
    {
        public void Main_ex(string[] s)
        {
            Func<float> func0 = () => 0.1f;
            Func<int, float> func1 = (a) => a * 0.1f;
            Func<int, int, float> func2 = (a, b) => (a + b) * 0.1f;
            Func<int, int, int, float> func3;

            func3 = new Func<int, int, int, float>(temp);

            Console.WriteLine("func{0} 반환값 : {1}", 0, func0());
            Console.WriteLine("func{0} 반환값 : {1}", 1, func1(10));
            Console.WriteLine("func{0} 반환값 : {1}", 2, func2(10,10));
            Console.WriteLine("func{0} 반환값 : {1}", 3, func3(10, 10,10));
        }

        static float temp(int a, int b, int c)
        {
            return (a + b + c) * 0.1f;
        }
    }


}
