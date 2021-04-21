using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Zoo
{
    public class ZooManager
    {
        public List<Animal> Animals = new List<Animal>();
        private List<Animal> pendingDeadAnimals = new List<Animal>();


        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        private void RemoveAnimals()
        {
            for (int i = 0; i < pendingDeadAnimals.Count; i++)
            {
                Animals.Remove(pendingDeadAnimals[i]);
            }

            if (pendingDeadAnimals.Count > 0) // no need to clear if empty already
                pendingDeadAnimals.Clear();
        }

        public void FeedingTime(string animalTypeString = null)
        {
            foreach (Animal animal in Animals)
            {
                if (animalTypeString != null && animal.GetType().ToString() != "Zoo." + animalTypeString) { }
                animal.FeedingTime();
                if (!animal.alive) { pendingDeadAnimals.Add(animal); }
            }
            RemoveAnimals();
        }

        public void UseEnergy()
        {
            foreach (Animal animal in Animals)
            {
                animal.UseEnergy();
                if (!animal.alive) { pendingDeadAnimals.Add(animal); }
            }
            RemoveAnimals();
        }
    }
}
