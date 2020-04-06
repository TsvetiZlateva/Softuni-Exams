using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;
        private bool canParticipate = false;

        public Rider(string name)
        {
            this.Name = name;
            this.NumberOfWins = 0;
            this.CanParticipate = this.canParticipate;
            this.Motorcycle = null;
        }

        public string Name
        { 
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length<5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                return this.canParticipate;
            }
            private set
            {
                if (this.Motorcycle != null)
                {
                    this.canParticipate = true;
                }
            }
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(ExceptionMessages.MotorcycleInvalid);
            }
            this.Motorcycle = motorcycle;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }
    }
}
