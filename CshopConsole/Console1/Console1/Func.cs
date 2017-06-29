
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class Func
    {
        public Func<int> GetSum;
        public int Write()
        {
            GetSum = () =>
            {
                Console.WriteLine("함수 진입");
                return Enumerable.Range(0, 100).Sum();
            };
            Console.WriteLine(GetSum());
            return GetSum();
        }

    }
}
