using System;
using System.Linq;
using System.Collections.Generic;

namespace Console1
{
    class OfType
    {
        //실행 예제
        //new OfType().Main_Ex(args);
        public void Main_Ex(string[] args)
        {
            Base[] Array = { new Base(), new Extended(), new Extended() };
            int i = 1;
            foreach (var itme in Array.OfType<Extended>()) {
                itme.SayIt(i++);
            }

            List<Base> list = new List<Base>();
            list.Add(new Base());
            list.Add(new Extended());
            list.Add(new Extended());

            foreach (var itme in list.OfType<Extended>())
            {
                itme.SayIt(i++);
            }
        }
    }

    class Base { }

    class Extended : Base {
        public void SayIt(int i) {
            Console.WriteLine("Extended_"+ i);
        }
    }
}
