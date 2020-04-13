using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private GunRepository gunRepository;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.gunRepository = new GunRepository();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }
                this.name = value;
            }
        }

        //todo calculated property ? = 0
        public bool IsAlive => this.LifePoints >= 0;

        //todo
        public IRepository<IGun> GunRepository => (IRepository<IGun>)this.gunRepository.Models;

        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            this.LifePoints -= points;
            if (this.LifePoints < 0)
            {
                this.LifePoints = 0;
            }
        }
    }
}
