using Blitzboule_Web.Models;
using Blitzboule_Web.Providers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Repositories
{
    public static class TeamRepository
    {
        public static Team GetByUser(User user)
        {
            Team team = null;

            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "SELECT * " +
                    "FROM `teams` t " +
                    "WHERE t.`Id` = @TeamId ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@TeamId", user.TeamId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            team = new Team()
                            {
                                Id = reader.GetInt32("Id"),
                                DivisionId = reader.GetInt32("DivisionId"),
                                Name = reader.GetString("Name"),
                                IsHuman = reader.GetBoolean("IsHuman")
                            };
                        }
                    }
                }
            }

            return team;
        }
    }
}