using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IFish> fish = new List<IFish>();
        private List<IDecoration> decoration = new List<IDecoration>();

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        //All names are unique
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }


        public int Comfort => GetComfort();

        public ICollection<IDecoration> Decorations => this.decoration;

        public ICollection<IFish> Fish => this.fish;

        public void AddFish(IFish fish)
        {
            if (this.Capacity > this.Fish.Count)
            {
                this.Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }


        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            //sb.AppendLine($"Fish: {(this.Fish.Any() ? string.Join(", ", this.Fish.Select(x => x.Name)) : "none")}");

            if (this.Fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                List<string> fishNames = new List<string>();
                foreach (var fish in this.Fish)
                {
                    fishNames.Add(fish.Name);
                }
                sb.AppendLine("Fish: " + string.Join(", ", fishNames));        
            }

            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString();
        }

        private int GetComfort()
        {
            int comfort = 0;

            foreach (var decoration in Decorations)
            {
                comfort += decoration.Comfort;
            }
            return comfort;
        }
    }
}
