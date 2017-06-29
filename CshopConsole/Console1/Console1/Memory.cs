using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Console1
{
    class Memory
    {
        public void Main_Ex(string[] args)
        {
            var list = new List<SimpleSum>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new SimpleSum(1000));
            }
        }
    }


    class SimpleSum
    {
        private int[] array;
        private int sum;

        private void calc()
        {
            sum = array.Sum();
        }

        public SimpleSum(int max)
        {
            array = Enumerable.Range(0, max).ToArray();
            calc();
            /*
             Out of memory 예외가 발생 할때 
             배열이 계속 데이터를 저장하고 있기 때문에 더 이상 필요하지 않을때 
             null 대입해서 더는 필요하지 않다는 것을 시스템에 알려주어서
             배열을 참조하는 변수를 가비지 컬렉션이 회수 할수 있게 한다.
              */
            array = null;
        }

    }
}
