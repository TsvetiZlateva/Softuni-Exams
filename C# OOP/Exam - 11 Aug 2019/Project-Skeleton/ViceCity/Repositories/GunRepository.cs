using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<Gun>
    {
        private readonly List<Gun> models;

        public GunRepository()
        {
            this.models = new List<Gun>();
        }
        public IReadOnlyCollection<Gun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.models.Contains((Gun)model))
            {
                this.models.Add((Gun)model);
            }
        }

        public IGun Find(string name)
        {
            return this.models.Find(m => m.Name == name);
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove((Gun)model);
        }
    }
}
