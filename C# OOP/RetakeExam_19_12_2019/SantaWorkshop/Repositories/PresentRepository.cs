using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>

    {
        private List<IPresent> models = new List<IPresent>();
        public IReadOnlyCollection<IPresent> Models => this.models.AsReadOnly();

        public void Add(IPresent present)
        {
            this.models.Add(present);
        }

        public IPresent FindByName(string name)
        {
            return models.FirstOrDefault(d => d.Name == name);
        }

        //Returns true if the deletion was sucessful, otherwise - false
        public bool Remove(IPresent model)
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
