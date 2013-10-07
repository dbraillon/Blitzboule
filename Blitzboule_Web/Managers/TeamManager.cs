using Blitzboule_Web.Models;
using Blitzboule_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Managers
{
    public static class TeamManager
    {
        public static void GenerateComputers(int divisionId)
        {
            for (int i = 0; i < 5; i++)
            {
                Team team = new Team();
                team.DivisionId = divisionId;
                team.Name = String.Concat("Computer ", divisionId, i);
                team.IsHuman = false;

                TeamRepository.Create(team);

                team.Players = PlayerManager.GeneratePlayers(team);
            }
        }
    }
}