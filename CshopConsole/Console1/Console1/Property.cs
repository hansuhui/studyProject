using System;
using System.Linq;
using System.Collections.Generic;

namespace Console1
{
    class MyClass
    {
        public int num1 { set; get; }
        public int num2 { set; get; }
        public string name { set; get; }
        public int sum
        {
            get { return num1 + num2; } // 읽기 전용
        }

        void Main()
        {
            //객체 생성시에 프로퍼티에 변수 추기화(매개변수는 ,로 구분)
            MyClass class1 = new MyClass();
            class1.num1 = 10;
            class1.name = "프로퍼티";
            class1.num2 = 20;
            Console.WriteLine(class1.sum);
        }
    }
}


