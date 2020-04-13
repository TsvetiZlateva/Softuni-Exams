using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle:Gun
    {
        private const int bulletsPerBarrel = 50;
        private const int totalBullets = 500;
        public Rifle(string name) : base(name, bulletsPerBarrel, totalBullets)
        {

        }

        //The rifle can shoot with 5 bullets. общо 550 патрона?
        public override int Fire()
        {
            //todo check if TotalBullets = 0
            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = 50;
                this.TotalBullets -= 50;
            }

            this.BulletsPerBarrel -= 5;

            return 5;
        }
    }
}
