using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public sealed class Monkey : Animal
    {
        public Monkey(string name)
        {
            Name = name;
            startingEnergy = 60; //Overwrite for monkey
            consumingEnergy = 2; //Overwrite for monkey
            foodUnits = 10; //Overwrite for monkey
            Energy = startingEnergy;
        }
    }
}
