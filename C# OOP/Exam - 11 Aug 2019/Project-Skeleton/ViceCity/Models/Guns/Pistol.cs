using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;
        public Pistol(string name) : base(name, bulletsPerBarrel, totalBullets)
        {

        }

        //The pistol shoots only one bullet. общо 110 патрона?
        public override int Fire()
        {
            //todo check if TotalBullets = 0
            if (this.BulletsPerBarrel==0)
            {
                this.BulletsPerBarrel = 10;
                this.TotalBullets -= 10;
            }

            this.BulletsPerBarrel -= 1;

            return 1;
        }
    }
}
