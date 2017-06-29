using System;
using System.Linq;
using System.Collections.Generic;

namespace Console1
{
    class Ex1
    {
        
        public void Main_Ex(string[] args)
        {
            BaseShip[] list = { new SubMarine(30), new Cruiser(10, 20) };
            int sum = 0;
            foreach (var item in list) {
                sum += item.Males;
            }
        }

        
    }

    class BaseShip
    {
        public int Males { get; protected set; }
    }

    class SubMarine : BaseShip {
        public SubMarine(int n) {
            Males = n;
        }
    }

    class Cruiser : BaseShip {
        public int Females { get;  private set;}
        public Cruiser(int n,int f){
            Males = n;
            Females = f;
        }
    }



}
