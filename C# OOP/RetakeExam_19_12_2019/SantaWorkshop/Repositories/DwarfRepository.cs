using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf> 
    {
        private List<IDwarf> models = new List<IDwarf>();
        public IReadOnlyCollection<IDwarf> Models => this.models.AsReadOnly();

        public void Add(IDwarf dwarf)
        {
            this.models.Add(dwarf);
        }

        public IDwarf FindByName(string name)
        {
            return models.FirstOrDefault(d => d.Name == name);
        }

        //Returns true if the deletion was sucessful, otherwise - false
        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
           
            //try
            //{
            //    this.models.Remove(model);
            //    return true;
            //}
            //catch 
            //{
            //    return false;
            //}
        }
    }
}
