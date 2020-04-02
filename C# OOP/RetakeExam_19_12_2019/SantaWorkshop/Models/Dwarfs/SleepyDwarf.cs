using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        //private int energy = 50;
        public SleepyDwarf(string name) : base(name, 50)
        {
            //this.Energy = energy;
        }

        public override void Work()
        {
            this.Energy -= 15;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
