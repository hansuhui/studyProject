using System;
using System.Diagnostics;
using System.Linq;


namespace Console1
{
    class LINQ_Ex6
    {
        public void Main()
        {
            int[] winners = { 2, 1, 5, 3, 5 };
            int i = 1;
            foreach (var s in winners)
            {
                Trace.Assert(false, "Test");
                Console.WriteLine("등 번호{0}번", i);
                if (winners.Contains(i))
                    Console.WriteLine("우승했기 때문에 상금 {0}원 수여", string.Format("{0:N0}", winners.Count(c => c == i) * 1000000));
                else
                    Console.WriteLine("상금 없음");

                i++;
            }

            Console.WriteLine("");
            Console.WriteLine(" ====시상 끝====");
            Console.WriteLine("");

        }
    }
}


