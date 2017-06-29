    using System;
    using System.Linq;


    namespace Console1
    {
        class Student
        {
            public string name { get; set; }
            public int[] score { get; set; }
        }
        class LINQ_Ex2
        {
            public void Main()
            {
                Student[] StudentList = {
                    new Student() { name="아라",score= new int[] { 88,73,66,91} },
                    new Student() { name="민희",score= new int[]{10,20,50,11}},
                    new Student() { name="현아",score= new int[]{48,73,16,31}},
                    new Student() { name="수지",score= new int[]{ 100, 100, 100,100}}
                };


                var Student_arr = from student in StudentList
                                  from score in student.score
                                  where score > 89
                                  select new
                                  {
                                      Name = student.name
                                     ,Score = score
                                  };

                foreach (var i in Student_arr)
                {
                    Console.WriteLine("{0} : {1}", i.Name, i.Score);
                }

            }
        }
    }


