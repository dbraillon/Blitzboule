using Blitzboule_Web.Models;
using Blitzboule_Web.Providers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Repositories
{
    public static class PlayerRepository
    {
        public static void Create(Player player)
        {
            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "INSERT INTO `players` (`teamId`, `name`, `hp`, `sp`, `en`, `at`, `pa`, `bl`, `sh`, `ca`, `re`) " +
                    "VALUES (@TeamId, @Name, @Hp, @Sp, @En, @At, @Pa, @Bl, @Sh, @Ca, @Re) ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@TeamId", player.TeamId);
                    command.Parameters.AddWithValue("@Name", player.Name);
                    command.Parameters.AddWithValue("@Hp", player.Hp);
                    command.Parameters.AddWithValue("@Sp", player.Sp);
                    command.Parameters.AddWithValue("@En", player.En);
                    command.Parameters.AddWithValue("@At", player.At);
                    command.Parameters.AddWithValue("@Pa", player.Pa);
                    command.Parameters.AddWithValue("@Bl", player.Bl);
                    command.Parameters.AddWithValue("@Sh", player.Sh);
                    command.Parameters.AddWithValue("@Ca", player.Ca);
                    command.Parameters.AddWithValue("@Re", player.Re);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}