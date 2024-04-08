using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;

        
        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Name {  get { return _user.Name; } set { _user.Name = value; } }
        public UserRolesEnum Role { get { return _user.Role; } set { _user.Role = value; } }

    }
}
