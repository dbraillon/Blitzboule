using Blitzboule_Web.Models;
using Blitzboule_Web.Providers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Repositories
{
    public static class UserRepository
    {
        public static User GetByLoginAndPassword(string login, string password)
        {
            User user = null;

            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "SELECT * " +
                    "FROM `users` u " +
                    "WHERE u.`login` = @login " +
                    "  AND u.`password` = @password ";

                using(MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User()
                            {
                                Id = reader.GetInt32("id"),
                                Email = reader.GetString("email"),
                                Login = reader.GetString("login"),
                                Password = reader.GetString("password")
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}