using MXGP.Models.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository: Repository<Race>
    {
        public override List<Race> Models => new List<Race>();
        public override Race GetByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
