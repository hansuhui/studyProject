using System;
using System.Linq;


namespace Console1
{
    class Profile
    {
        public string name { get; set; }
        public int age { get; set; }
    }
    class Score
    {
        public string name { get; set; }
        public int math { get; set; }
        public int english { get; set; }
    }
    class LINQ_Join_Ex
    {
        public void Main()
        {
            Profile[] ProfileList = {
                    new Profile() {name="아라",age=11},
                    new Profile() {name="성희",age=22},
                    new Profile() {name="현아",age=33},
                    new Profile() {name="혁이",age=44}
                };


            Score[] ScoreList = {
                    new Score() {name="나와",math=11,english=11},
                    new Score() {name="성희",math=22,english=22},
                    new Score() {name="너의",math=33,english=33},
                    new Score() {name="혁이",math=44,english=44}
                };

            var Students_arr = from profile in ProfileList
                               join score in ScoreList on profile.name equals score.name
                             select new
                             {
                                 Name = profile.name
                                ,Age = profile.age
                                ,Math = score.math
                                ,English= score.english
                             };

            foreach (var s in Students_arr)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("===============[외부조인]=============");


            var Students_arr2 = from profile in ProfileList
                               join score in ScoreList on profile.name equals score.name into temp
                               from score in temp.DefaultIfEmpty(new Score() { math=100,english=100})
                               select new
                               {
                                   Name = profile.name,
                                   Age = profile.age,
                                   Math = score.math,
                                   English = score.english
                               };

            foreach (var s in Students_arr2)
            {
                Console.WriteLine(s);
            }

        }
    }
}


