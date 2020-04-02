using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs = new DwarfRepository();
        private PresentRepository presents = new PresentRepository();

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            if (dwarfType == "HappyDwarf")
            {
                var dwarf = new HappyDwarf(dwarfName);
                dwarfs.Add(dwarf);

                return String.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
            }
            if (dwarfType == "SleepyDwarf")
            {
                var dwarf = new SleepyDwarf(dwarfName);
                dwarfs.Add(dwarf);
                return String.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            Instrument instrument = new Instrument(power);
            var dwarf = dwarfs.FindByName(dwarfName);

            if (dwarf != null)
            {
                dwarf.AddInstrument(instrument);
                return String.Format(OutputMessages.InstrumentAdded, power, dwarfName);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDwarf));
            }
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            Present present = new Present(presentName, energyRequired);
            presents.Add(present);
            return String.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            //var present = presents.FindByName(presentName);
            //present.GetCrafted();
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
