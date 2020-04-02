using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }

        //The dwarf starts crafting the present.This is only possible, 
        //if the dwarf has energy and an instrument that isn't broken.
        //At the same time the present is getting crafted, so call the GetCrafted() method for the present. 
        //Keep working until the present is done or the dwarf has energy and instruments to use.
        //If at some point the power of the current instrument reaches or drops below 0, 
        //meaning it is broken, then the dwarf should take the next instrument from its collection, if it has any left.


        public void Craft(IPresent present, IDwarf dwarf)
        {
            if (dwarf.Energy > 0 && dwarf.Instruments.Any(i => i.Power > 0))
            {
                while ((dwarf.Energy > 0 && dwarf.Instruments.Any(i => i.Power > 0))
                    || !present.IsDone())
                {
                    dwarf.Work();
                    present.GetCrafted();
                }
            }
        }
    }
}
