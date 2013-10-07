using Blitzboule_Web.Models;
using Blitzboule_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Managers
{
    public static class PlayerManager
    {
        public static Player[] GeneratePlayers(Team team)
        {
            List<Player> players = new List<Player>();

            players.Add(new Player(Position.LF, team));
            players.Add(new Player(Position.RF, team));
            players.Add(new Player(Position.MF, team));
            players.Add(new Player(Position.LD, team));
            players.Add(new Player(Position.RD, team));
            players.Add(new Player(Position.GL, team));

            foreach (Player player in players)
            {
                PlayerRepository.Create(player);
            }

            return players.ToArray();
        }
    }
}