using MXGP.Models.Riders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<Rider>
    {
        public override List<Rider> Models => new List<Rider>();
        public override Rider GetByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
