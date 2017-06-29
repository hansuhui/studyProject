using System;
using System.Linq;


namespace Console1
{
    class LINQ_Ex4
    {
        public void Main()
        {
            int[] ar = { 5, 2, -1, 1, 4 };
            int[] arWithtountMinus = ar.Where(c => c >= 0).ToArray(); //음수를 제거 한다.

            //LINQ를 사용해서 가급적 루프 없이 처리하는게 중요하다.
            //로직과 루프를 가능한 분리할 것 
            Console.WriteLine(
                "결과 :{0}",
                arWithtountMinus.Select((n, i) => new Tuple<int, int>(n, i)).Aggregate((sum, next) => {
                    var r = sum.Item1 + next.Item1;
                    Console.WriteLine("{0}번째 처리. 현재 합계 {1}", next.Item2, r);
                    return new Tuple<int, int>(r, next.Item2);
            }).Item1);


 
        }
    }
}


