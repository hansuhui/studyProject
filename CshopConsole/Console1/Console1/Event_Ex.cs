using System;

namespace Console1
{
    class Event_Ex
    {
        public delegate void EvnetDel(int a);
        public event EvnetDel eventdel;
        static void EvenNaber(int Num) { Console.WriteLine("EvenNaber-" + Num); }
        public void Main()
        {
            eventdel = new EvnetDel(EvenNaber);
            foreach (int i in new int[] { 11, 22, 33, 44 }) {
                eventdel(i);
            }


        }
            
    }

}



