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
                                Password = reader.GetString("password"),
                                Role = (UserRole)reader.GetInt32("role"),
                                Status = (UserStatus)reader.GetInt32("status")
                            };

                            user.TeamId = (reader["teamId"] == System.DBNull.Value) ? 0 : reader.GetInt32("teamId");
                        }
                    }
                }
            }

            return user;
        }

        public static void Insert(User user)
        {
            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "INSERT INTO `users` (`email`, `login`, `password`, `role`, `status`) " +
                    "VALUES (@Email, @Login, @Password, @Role, @Status) ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Login", user.Login);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Role", (int)user.Role);
                    command.Parameters.AddWithValue("@Status", (int)user.Status);

                    command.ExecuteNonQuery();

                    user.Id = (int)command.LastInsertedId;
                }
            }
        }

        public static void Update(User user)
        {
            using (BlitzbouleProvider provider = new BlitzbouleProvider())
            {
                string cmdText =
                    "UPDATE `users` " +
                    "SET `teamId` = @TeamId, `email` = @Email, `login` = @Login, `password` = @Password, `role` = @Role, `status` = @Status " +
                    "WHERE `id` = @Id ";

                using (MySqlCommand command = new MySqlCommand(cmdText, provider.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@TeamId", user.TeamId);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Login", user.Login);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Role", (int)user.Role);
                    command.Parameters.AddWithValue("@Status", (int)user.Status);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}