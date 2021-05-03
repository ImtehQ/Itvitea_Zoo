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
            Energy = startingEnergy;
        }
    }
}
