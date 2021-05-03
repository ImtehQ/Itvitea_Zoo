using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public abstract class Animal
    {
        public bool alive = true;
        public string Name { get; set; }
        public int Energy { get; set; }

        //Animal stats
        public int startingEnergy;
        public int consumingEnergy;
        public int foodUnits;

        internal int eatingValue = 25;

        public void UseEnergy()
        {
            Energy -= consumingEnergy;
        }

        public void Eat()
        {
            Energy += eatingValue * foodUnits;
        }
    }
}
