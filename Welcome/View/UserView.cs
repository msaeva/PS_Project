using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;
        
        public UserView(UserViewModel userViewModel) { 
            _viewModel = userViewModel;
        }

        public void display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User : " + _viewModel.Name);
            Console.WriteLine("Role : " + _viewModel.Role);
        }

        public void displayError()
        {
            throw new Exception("Error");
        }
    }
}
