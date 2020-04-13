using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            //The main player starts shooting at all the civil players
            var civilPlayer = civilPlayers.FirstOrDefault(c=>c.IsAlive);

            //•	The main player stops shooting only if he runs out of guns or until all the civil players are dead.
            //•	If the barrel of his gun becomes empty, he reloads from his bullets stock and continues shooting with the current gun, 
            //  until he uses all of its bullets.
            while (mainPlayer.GunRepository.Models.Count != 0 || civilPlayers.Count == 0)
            {
                //•	He takes a gun from his guns.
                var gun = mainPlayer.GunRepository.Models.FirstOrDefault();


                //•	If his gun runs out of total bullets, he takes the next gun he has and continues shooting
                if (!gun.CanFire && mainPlayer.GunRepository.Models.Count != 0 && civilPlayers.Count == 0)
                {
                    mainPlayer.GunRepository.Remove(gun);
                    gun = mainPlayer.GunRepository.Models.FirstOrDefault();
                }
                else
                {
                    break;
                }

                //•	Every time he shoots, he takes life points from the civil player, 
                //  which are equal to the bullets that the current gun shoots when the trigger is pulled.
                gun.Fire();
                int takenLifePoints = gun.Fire();
                civilPlayer.TakeLifePoints(takenLifePoints);

                //•	If the civil player dies, he starts shooting at the next one.
                if (!civilPlayer.IsAlive)
                {
                    //civilPlayers.Remove(civilPlayer);
                    civilPlayer = civilPlayers.FirstOrDefault(c => c.IsAlive);
                }
            }

            while (civilPlayers.Where(p=>p.IsAlive).ToList().Count != 0)
            {
                civilPlayer = civilPlayers.FirstOrDefault(c => c.IsAlive);
                var gun = civilPlayer.GunRepository.Models.FirstOrDefault();

                if (!gun.CanFire && civilPlayer.GunRepository.Models.Count != 0 && mainPlayer.IsAlive)
                {
                    civilPlayer.GunRepository.Remove(gun);
                    gun = civilPlayer.GunRepository.Models.FirstOrDefault();
                }
                else
                {
                    break;
                }

                gun.Fire();
                int takenLifePoints = gun.Fire();
                mainPlayer.TakeLifePoints(takenLifePoints);

                // If a civil player runs out of guns, the next civil player begins shooting.
                if (civilPlayer.GunRepository.Models.Count == 0)
                {
                    //civilPlayers.Remove(civilPlayer);
                    civilPlayer = civilPlayers.FirstOrDefault(c => c.IsAlive);
                }
                // If the main player dies, the whole action ends.
                if (!mainPlayer.IsAlive)
                {
                    return;
                }
            }

        }
    }
}
