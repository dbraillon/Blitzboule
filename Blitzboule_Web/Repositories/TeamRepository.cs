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
        public static Team ReadByUser(User user)
        {
            Team team = null;

            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "SELECT * " +
                    "FROM `teams` t " +
                    "WHERE t.`id` = @TeamId ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@TeamId", user.TeamId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            team = new Team()
                            {
                                Id = reader.GetInt32("id"),
                                DivisionId = reader.GetInt32("divisionId"),
                                Name = reader.GetString("name"),
                                IsHuman = reader.GetBoolean("isHuman")
                            };
                        }
                    }
                }
            }

            return team;
        }

        public static void ReadByName(Team team)
        {
            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "SELECT * " +
                    "FROM `teams` t " +
                    "WHERE t.`name` = @Name ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Name", team.Name);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            team.Id = reader.GetInt32("id");
                        }
                    }
                }
            }
        }

        public static void Create(Team team)
        {
            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "INSERT INTO `teams` (`divisionId`, `name`, `isHuman`) " +
                    "VALUES (@DivisionId, @Name, @IsHuman) ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@DivisionId", team.DivisionId);
                    command.Parameters.AddWithValue("@Name", team.Name);
                    command.Parameters.AddWithValue("@IsHuman", team.IsHuman);

                    command.ExecuteNonQuery();

                    team.Id = (int)command.LastInsertedId;
                }
            }
        }

        public static int ReplaceComputer(Team team, League league)
        {
            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "UPDATE `teams` AS `target` " +
	                "   INNER JOIN ( " +
		            "       SELECT t.`id` " +
		            "       FROM `teams` t " +
		            "       LEFT JOIN `divisions` d ON d.`id` = t.`divisionId` " +
		            "           WHERE d.`league` = @League " +
		            "           AND t.`isHuman` = 0 " +
		            "           LIMIT 1) AS `source`  " +
                    "   ON `source`.`id` = `target`.`id` " +
                    "SET `target`.`name` = @Name, `target`.`isHuman` = 1 ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Name", team.Name);
                    command.Parameters.AddWithValue("@League", (int)league);
                    
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}