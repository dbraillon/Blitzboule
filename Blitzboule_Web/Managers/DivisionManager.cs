using Blitzboule_Web.Models;
using Blitzboule_Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Managers
{
    public static class DivisionManager
    {
        public static void FindOrCreate(Team team, League league)
        {
            /// First try to replace a computer by the team
            if (TeamRepository.ReplaceComputer(team, league) > 0)
            {
                /// A computer has been found, now retrieve the team
                TeamRepository.ReadByName(team);
            }
            else
            {
                /// No computer has been found, now creating new division and add the team
                DivisionRepository.Create(team, league);
                TeamRepository.Create(team);
                team.Players = PlayerManager.GeneratePlayers(team);

                TeamManager.GenerateComputers(team.DivisionId);
            }
        }
    }
}