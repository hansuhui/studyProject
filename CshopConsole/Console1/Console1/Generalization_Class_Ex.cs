using System;

namespace Console1
{
    class List_Test<T> {
        public T[] arr;
        public List_Test() { arr = new T[1]; }
    }
    class Generalization_Class_Ex
    {
        
        public void Main() {
            List_Test<int> list1 = new List_Test<int>();
            list1.arr[0] = 10;

            List_Test<float> list2= new List_Test<float>();
            list2.arr[0] = 2.2f;

            List_Test<string> list3 = new List_Test<string>();
            list3.arr[0] = "일반화 클래스";

            Console.WriteLine(list1.arr[0]);
            Console.WriteLine(list2.arr[0]);
            Console.WriteLine(list3.arr[0]);
        }
    }
}


