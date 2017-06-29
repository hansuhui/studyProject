using System;

namespace Console1
{
    class Lamda_Ex
    {
        delegate int Lamda_del1(int a, int b);
        delegate void Lamda_del2();
        public void Main()
        {
            Lamda_del1 add = (a, b) =>
            {
                return a + b;
            };
            Lamda_del2 lamda = () =>
            {
                Console.WriteLine("이것 저것 작성하면 된다");
                Console.WriteLine("람다식 예제");
            };

            Console.WriteLine("Lamda_del1 - ",add(11,22));
            lamda();

        }
            
    }

}



