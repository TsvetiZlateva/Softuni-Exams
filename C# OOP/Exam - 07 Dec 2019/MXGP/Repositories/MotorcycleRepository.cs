using MXGP.Models.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : Repository<Motorcycle>
    {
        public override List<Motorcycle> Models => new List<Motorcycle>();
        public override Motorcycle GetByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Model == name);
        }
    }
}
