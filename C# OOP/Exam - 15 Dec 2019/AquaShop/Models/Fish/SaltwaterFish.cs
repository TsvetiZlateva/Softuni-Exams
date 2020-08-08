﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish:Fish
    {
        private int size = 5;
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = size;
        }

       

        public override void Eat()
        {
            this.size += 2;
        }
    }
}