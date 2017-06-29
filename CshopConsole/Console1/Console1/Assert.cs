using System;
using System.Diagnostics;
using System.Linq;


namespace Console1
{
    class Assert
    {
        public void Main()
        {
            int[] winners = { 1,2,3,4,5 };
            foreach (var s in winners)
            {
                //프로그램이 멈춘다. 일종의 디버깅 기능
                Trace.Assert(false, "Test");
                
            }
        }
    }
}


