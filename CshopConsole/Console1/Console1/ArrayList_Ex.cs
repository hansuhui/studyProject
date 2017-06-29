using System;
using System.Collections;

namespace Console1
{
    class ArrayList_Ex
    {
        public void Main() {
            ArrayList list = new ArrayList();
            list.Add(10); list.Add(20); list.Add(30); //10,20 ,30

            list.RemoveAt(1); // list.Remove(20) 과 같은 결과.

            list.Insert(1, 2.3f); // 10, 2.3 , 30;
            list.Add("ABC");
            list.Add("가나다");

            //컬렉션의 모든 요소는 obejct 타입으로 저장된다.
            foreach (object obj in list) {
                Console.Write("{0}", obj);
                Console.WriteLine();
            }

        }
    }
}


