using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        public Instrument(int power)
        {
            this.Power = power;
        }
        public int Power { get; private set; }

        public bool IsBroken()
        {
            if (this.Power==0)
            {
                return true;
            }

            return false;
        }

        public void Use()
        {
            this.Power -= 10;
            if (this.Power < 0)
            {
                this.Power = 0;
            }
        }
    }
}
