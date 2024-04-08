using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public int _id;
        private string _name;
        private string _password;
        private UserRolesEnum _role;
        private String _faculty_number;
        private DateTime _expires;

        public User() { }  

        public User(string name, string password,String faculty_number, UserRolesEnum role)
        {
            _name = name;
            _faculty_number = faculty_number;
            _password = password;
            _role = role; 
        }
        public User(string name, string password, UserRolesEnum role)
        {
            _name = name;
            _password = password;
            _role = role;
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value.ToUpper(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

    
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public UserRolesEnum Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
    }
}
