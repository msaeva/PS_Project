using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
   public static class UserHelper
    {
        public static string ToString(this User user)
        {
            return $"User: {user.Name}, Role: {user.Role}, Expires: {user.Expires}";
        }
        public static string ValidateCredentials(UserData userData, string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "The name cannot be empty";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return "The password cannot be empty";
            }

            return userData.ValidateUser(name, password) ? "Credentials are valid" : "Invalid credentials";
        }

        public static User GetUser(UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
