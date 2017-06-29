using System;

namespace Console1
{
  
    class Generalization_Where_Ex
    {        
        public void Main() {
            Where_List<Where_Parent> list = new Where_List<Where_Parent>();
            list.array[0] = new Where_Parent();
            list.array[1] = new Where_Children();

            Console.WriteLine(list.array[0].name);
            Console.WriteLine(list.array[1].name);
        }
    }

    class Where_Parent {
        public string name { get; set; }
        public Where_Parent() { name = "부모클래스"; }
    }

    class Where_Children : Where_Parent {
        public Where_Children() { name = "자식클래스"; }
    }

    class Where_List<T> where T : Where_Parent {
        public T[] array;
        public Where_List() { array = new T[2]; }
    }
}


