using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public virtual List<T> Models => new List<T>();

        public void Add(T model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public abstract T GetByName(string name);
  

        public bool Remove(T model)
        {
            return this.Models.Remove(model);
        }
    }
}
