using Blitzboule_Web.Models;
using Blitzboule_Web.Providers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Repositories
{
    public static class DivisionRepository
    {
        public static Division ReadByLeague(League league)
        {
            Division division = null;

            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "SELECT d.* " +
                    "FROM `divisions` d, `teams` t " +
                    "WHERE d.`league` = @League " +
                    "  AND t.`divisionId` = d.`id` " +
                    "  AND ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@League", league);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            division = new Division()
                            {
                                Id = reader.GetInt32("id"),
                                League = (League)reader.GetInt32("league"),
                                Name = reader.GetString("name")
                            };
                        }
                    }
                }
            }

            return division;
        }

        internal static void Create(Team team, League league)
        {
            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "INSERT INTO `divisions` (`league`, `name`) " +
                    "VALUES (@League, @Name) ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@League", (int)league);
                    command.Parameters.AddWithValue("@Name", league + "'s division");

                    command.ExecuteNonQuery();

                    team.DivisionId = (int)command.LastInsertedId;
                }
            }
        }
    }
}