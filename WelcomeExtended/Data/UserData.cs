using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> _users;
        private int _nextId;
        
        public UserData() { 
            this._users = new List<User>();
            this._nextId = 0;
       } 

        public void AddUser(User user)
        {
           user.Id = this._nextId++;
            this._users.Add(user);
        }
        public void DeleteUser(User user)
        {
            this._users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach(var user in this._users)
            {
                if (user.Name == name) return true;
            }
            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users
                .Where(x => x.Name == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        }
        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users where user.Name == name && user.Password == password select user.Id;
            return ret != null ? true : false;
        }

        public User GetUser(string name, string password)
        {
            return _users.FirstOrDefault(u => u.Name == name && u.Password == password);
        }

        public void SetActive(string name, DateTime expirationDate)
        {
            var user = _users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                user.Expires = expirationDate;
            }
            else
            {
                // Handle case where user is not found
                Console.WriteLine($"User '{name}' not found.");
            }
        }
        public  void AssignUserRole(string name, string role)
        {
            var user = this._users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                if (Enum.TryParse<UserRolesEnum>(role, out var parsedRole))
                {
                    user.Role = parsedRole;
                }
                else
                {
                    Console.WriteLine($"Invalid role: {role}");
                }
            }
            else
            {
                Console.WriteLine($"User '{name}' not found.");
            }
        }


    }
}
