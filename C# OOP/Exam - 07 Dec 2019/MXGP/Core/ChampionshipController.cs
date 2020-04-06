using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motors;
        private RaceRepository races;
        private RiderRepository riders;
        public ChampionshipController()
        {
            this.motors = new MotorcycleRepository();
            this.races = new RaceRepository();
            this.riders = new RiderRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riders.GetByName(riderName);
            var motorcycle = motors.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            else
            {
                rider.AddMotorcycle(motorcycle);
                return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
            }
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = riders.GetByName(riderName);
            var race = races.GetByName(raceName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            else
            {
                race.AddRider(rider);
                return string.Format(OutputMessages.RiderAdded, riderName, raceName);
            }
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            Motorcycle motorcycle = null; 

            switch (type)
            {
                case "SpeedMotorcycle":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                case "PowerMotorcycle":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
            }

            if (motorcycle == motors.GetByName(model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }
            else
            {
                return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
            }
        }

        public string CreateRace(string name, int laps)
        {
            Race race = new Race(name, laps);

            if (races.GetByName(name) == race)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            else
            {
                races.Add(race);
                return string.Format(OutputMessages.RaceCreated, name);
            }
        }

        public string CreateRider(string riderName)
        {
            Rider rider = new Rider(riderName);
            if (rider == riders.GetByName(riderName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }
            else
            {
                riders.Add(rider);
                return string.Format(OutputMessages.RiderCreated, riderName);
            }
        }

        public string StartRace(string raceName)
        {

            if (races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (races.GetByName(raceName).Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            else
            {

                var race = races.GetByName(raceName);
                var laps = race.Laps;

                var firstThreeRiders = race.Riders
                    .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(laps))
                    .Take(3)
                    .ToArray();

                races.Remove(race);

                return string.Format(OutputMessages.RiderFirstPosition, firstThreeRiders[0].Name, raceName)
                    + Environment.NewLine +
                    string.Format(OutputMessages.RiderSecondPosition, firstThreeRiders[1].Name, raceName)
                    + Environment.NewLine +
                    string.Format(OutputMessages.RiderThirdPosition, firstThreeRiders[2].Name, raceName);

            }
        }
    }
}
