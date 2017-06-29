using System;
using System.Threading.Tasks;


namespace Console1
{
    //비동기 루프
    class async
    {
        private static async Task countDown()
        {
            for (int i = 9; i >= 0; i--)
            {
                Console.WriteLine(i);
                await Task.Delay(1000);
            }

        }

        public void Main_Ex(string[] args)
        {
            var a = countDown();
            var b = countDown();
            Task.WaitAll(a, b);
        }
    }
}
