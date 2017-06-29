using System;
using System.Linq;


namespace Console1
{
    class Person
    {
        public string sex { get; set; }
        public string name { get; set; }
    }
    class LINQ_Ex3
    {
        public void Main()
        {
            Person[] PersonList = {
                    new Person() { sex="여자",name="아라"},
                    new Person() { sex="남자",name="성희"},
                    new Person() { sex="여자",name="현아"},
                    new Person() { sex="남자",name="혁이"}
                };


            var Person_arr = from person in PersonList
                             group person by person.sex == "남자" into data
                             select new
                             {
                                 sexCheck = data.Key
                                 , people = data
                              };

            foreach (var i in Person_arr)
            {
                if (i.sexCheck)
                {
                    Console.WriteLine("<남자 리스트>");
                    foreach (var m in i.people)
                    {
                        Console.WriteLine("이름 :" + m.name);
                    }

                }
                else {
                    Console.WriteLine("<남자 리스트>");
                    foreach (var m in i.people)
                    {
                        Console.WriteLine("이름 :" + m.name);
                    }
                }
            }

        }
    }
}


