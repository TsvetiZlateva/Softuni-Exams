using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        MainPlayer mainPlayer;
        private GunRepository gunRepository;
        private List<Player> civilPlayers;
        private GangNeighbourhood gangNeighbourhood;
        public Controller()
        {
            mainPlayer = new MainPlayer();
            this.gunRepository = new GunRepository();
            this.civilPlayers = new List<Player>();
            this.gangNeighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            Gun gun;

            switch (type)
            {
                case "Pistol":
                    gun = new Pistol(name);
                    break;
                case "Rifle":
                    gun = new Rifle(name);
                    break;
                default: return "Invalid gun type!";
            }

            gunRepository.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (gunRepository.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = gunRepository.Models.First();

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            if (!this.civilPlayers.Exists(p => p.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }

            var civilPlayer = civilPlayers.Find(p => p.Name == name);
            civilPlayer.GunRepository.Add(gun);
            return $"Successfully added {gun.Name} to the Civil Player: {name}";
        }

        public string AddPlayer(string name)
        {
            CivilPlayer civilPlayer = new CivilPlayer(name);
            civilPlayers.Add(civilPlayer);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            gangNeighbourhood.Action(mainPlayer, (ICollection<IPlayer>)civilPlayers);

            if (mainPlayer.LifePoints == 100 && civilPlayers.Where(p => !p.IsAlive).ToList().Count == 0 && civilPlayers.Sum(p=>p.LifePoints)/civilPlayers.Count == 50)
            {
                return "Everything is okay!";
            }

            else /*if (mainPlayer.LifePoints != 100 || civilPlayers.Where(p => !p.IsAlive).ToList().Count != 0 || civilPlayers.Sum(p => p.LifePoints) / civilPlayers.Count != 50)*/
            {
                return "A fight happened:" + Environment.NewLine +
                        $"Tommy live points: {mainPlayer.LifePoints}!" + Environment.NewLine +
                        $"Tommy has killed: {civilPlayers.Where(p => !p.IsAlive).ToList().Count} players!" + Environment.NewLine +
                        $"Left Civil Players: {civilPlayers.Where(p => p.IsAlive).ToList().Count}!";

            }
        }
    }
}
