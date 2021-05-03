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


        /// <summary>
        /// Add a new animal
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        /// <summary>
        /// Removes the corpses
        /// </summary>
        private void RemoveAnimals()
        {
            if (pendingDeadAnimals.Count == 0)
                return;

            for (int i = 0; i < pendingDeadAnimals.Count; i++)
            {
                Animals.Remove(pendingDeadAnimals[i]);
            }

            if (pendingDeadAnimals.Count > 0) // no need to clear if empty already
                pendingDeadAnimals.Clear();
        }


        /// <summary>
        /// Checks and updates Alive status
        /// </summary>
        public void CheckAnimals()
        {
            if (Animals.Count == 0)
                return;
            foreach (Animal animal in Animals)
            {
                if (animal.alive == false || animal.Energy <= 0) 
                { 
                    pendingDeadAnimals.Add(animal); 
                }
            }
            RemoveAnimals();
        }

        /// <summary>
        /// Feed all animals
        /// </summary>
        public void FeedingTime()
        {
            if (Animals.Count == 0)
                return;
            foreach (Animal animal in Animals)
            {
                animal.Eat();
            }
        }

        /// <summary>
        /// Feeds all animals if animalTypeString is null
        /// else feed just the one type.
        /// </summary>
        /// <param name="animalTypeString"></param>
        public void FeedingTime(string animalTypeString = null)
        {
            if (Animals.Count == 0)
                return;
            foreach (Animal animal in Animals)
            {
                if (animalTypeString != null && animal.GetType().Name == animalTypeString)
                {
                    animal.Eat();
                }
            }
        }

        /// <summary>
        /// Uses the engery of all animals
        /// </summary>
        public void UseEnergy()
        {
            if (Animals.Count == 0)
                return;
            foreach (Animal animal in Animals)
            {
                animal.UseEnergy();
            }
        }
    }
}
