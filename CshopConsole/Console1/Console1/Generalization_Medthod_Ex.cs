using System;

namespace Console1
{
    class Generalization_Medthod_Ex
    {
        static void print<T>(T value) {
            Console.WriteLine(value);
        }
        public void Main() {
            print<int>(29);
            print<float>(17.9f);
            print<string>("한수희");
        }
    }
}


