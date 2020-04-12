using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;

                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;

                default: throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            switch (decorationType)
            {
                case "Ornament":
                    decoration = new Ornament();
                    break;

                case "Plant":
                    decoration = new Plant();
                    break;

                default: throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquaruim = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            var decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            else
            {
                aquaruim.AddDecoration(decoration);
                decorations.Remove(decoration);
                return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            //Type t = aquarium.GetType();
            //List<Aquarium> a = new List<Aquarium>();


            //foreach (var aq in aquariums)
            //{
            //    a.Add((Aquarium)aq);
            //}

            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if ((fish.GetType().Name == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium") 
                || (fish.GetType().Name == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium")) 
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fish.GetType().Name, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }
 
        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Feed();
            int fishCount = aquarium.Fish.Count;
            return string.Format(OutputMessages.FishFed, fishCount);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal decorationsPriceSum = 0;
            decimal fishPriceSum = 0;

            foreach (var decoration in aquarium.Decorations)
            {
                decorationsPriceSum += decoration.Price;
            }

            foreach (var fish in aquarium.Fish)
            {
                fishPriceSum += fish.Price;
            }

            decimal aquariumValue = decorationsPriceSum + fishPriceSum;

            return string.Format(OutputMessages.AquariumValue, aquariumName, aquariumValue);
        }


        public string Report()
        {
            string result = null;
            foreach (var aquarium in aquariums)
            {
                result += aquarium.GetInfo() + Environment.NewLine;
            }

            return result; 
        }
    }
}
