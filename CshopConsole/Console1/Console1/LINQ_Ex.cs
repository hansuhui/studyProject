using System;
using System.Linq;


namespace Console1
{
    class Woman {
        public string name { get; set; }
        public int age { get; set; }
    }
    class LINQ_Ex
    {
        public void Main() {
            Woman[] wonameList = {
                new Woman() { name="아라",age=24 },
                new Woman() { name="민희",age=20 },
                new Woman() { name="현아",age=32 },
                new Woman() { name="수지",age=20 }
            };


            var Women_arr = from woman in wonameList
                        where woman.age > 20
                        orderby woman.age ascending
                        select new
                        {
                            title = "성인 여자",
                            name = woman.name
                        };

            foreach (var i in Women_arr) {
                Console.WriteLine("{0} : {1}", i.title, i.name);
            }

        }
    }
}


