using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Models
{
    public enum UserRole { Administrator, User, Unknown }
    public enum UserStatus { Normal, WithoutTeam, Unknown }

    public class User
    {
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int TeamId { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Login { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public UserRole Role { get; set; }

        [ScaffoldColumn(false)]
        public UserStatus Status { get; set; }

        [ScaffoldColumn(false)]
        public Team Team { get; set; }


        public User()
        {
            Id = 0;
            TeamId = 0;
            Email = "";
            Login = "";
            Password = "";
            Role = UserRole.Unknown;
            Status = UserStatus.Unknown;
            Team = null;
        }

        public static string UserRoleToString(UserRole userRole)
        {
            switch (userRole)
            {
                case UserRole.User:
                    return "User";
                case UserRole.Administrator:
                    return "Administrator";
                default :
                    return "Unknown";
            }
        }
        public static UserRole StringToUserRole(string userRole)
        {
            switch (userRole)
            {
                case "User":
                    return UserRole.User;
                case "Administrator":
                    return UserRole.Administrator;
                default:
                    return UserRole.Unknown;
            }
        }

        public static string UserStatusToString(UserStatus userStatus)
        {
            switch (userStatus)
            {
                case UserStatus.Normal:
                    return "Normal";
                case UserStatus.WithoutTeam:
                    return "WithoutTeam";
                default:
                    return "Unknown";
            }
        }
        public static UserStatus StringToUserStatus(string userStatus)
        {
            switch (userStatus)
            {
                case "Normal":
                    return UserStatus.Normal;
                case "WithoutTeam":
                    return UserStatus.WithoutTeam;
                default:
                    return UserStatus.Unknown;
            }
        }
    }
}