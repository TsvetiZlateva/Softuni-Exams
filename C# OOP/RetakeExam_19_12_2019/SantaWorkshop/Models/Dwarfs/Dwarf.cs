using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Instruments = new List<Instrument>();
        }

        //protected Dwarf(string name)
        //{
        //    this.Name = name;
        //    this.Energy = Energy;
        //    this.Instruments = new List<Instrument>();
        //}

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy { get; protected set; }

        public List<Instrument> Instruments { get; private set; }

        public void AddInstrument(Instrument instrument)
        {
            this.Instruments.Add(instrument);
        }

        public abstract void Work();
      
    }
}
