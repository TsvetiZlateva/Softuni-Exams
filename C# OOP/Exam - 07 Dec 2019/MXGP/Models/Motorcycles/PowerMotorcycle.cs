using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;
        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, 450)
        {
        }

        //Minimum horsepower is 70 and maximum horsepower is 100.
        public override int HorsePower 
        { 
            get
            {
                return this.horsePower;
            }
            set
            {
                if (value < 70 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

    }
}
