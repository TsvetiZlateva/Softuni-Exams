using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        //private int energy = 100;

        public HappyDwarf(string name):base (name, 100)
        {
            //this.Energy = energy;
        }

        public override void Work()
        {
            this.Energy -= 10;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
