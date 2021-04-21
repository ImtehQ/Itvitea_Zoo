using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public sealed class Lion : Animal
    {
        public Lion(string name)
        {
            Name = name;
            startingEnergy = 100; //Overwrite for Lion
            consumingEnergy = 10; //Overwrite for Lion
            foodUnits = 25; //Overwrite for Lion
        }

        public override void UseEnergy()
        {
            Energy -= consumingEnergy;
            if (Energy < 0) { alive = false; }
        }

        public override void Eat()
        {
            Energy += eatingValue * foodUnits;
        }

        public override void FeedingTime()
        {
            UseEnergy();
        }
    }
}
