using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Console1
{
    class Memory2
    {
        public void Main_Ex(string[] args)
        {
            var list = new List<SimpleSum2>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new SimpleSum2(3));
            }
        }
    }

    class SimpleSum2
    {
        public Func<int> GetSum;

        public SimpleSum2(int max)
        {

            /*
               거대한 뱅ㄹ은 메모리를엄청나게 잡아 먹지만, 
               열거 객체는 데이터 자체를 저장하는게 아니라 필요한 
               데이터를 반복해서 가져오는 방법을 사용 하기 때문에
               배열 보다는 메모리를 압박하지 않는다.
             */

            IEnumerable<int> enumAll = Enumerable.Range(0, max);
            //Console.WriteLine(enumAll.Sum());
            GetSum = () => { return enumAll.Sum(); };
        }
    }
}
