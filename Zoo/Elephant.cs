using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public sealed class Elephant : Animal
    {
        public Elephant(string name)
        {
            Name = name;
            startingEnergy = 100; //Overwrite for Lion
            consumingEnergy = 5; //Overwrite for Lion
            foodUnits = 50; //Overwrite for Lion
            Energy = startingEnergy;
        }
    }
}
