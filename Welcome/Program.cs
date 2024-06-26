﻿using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Mariya", "password", "121221015", Others.UserRolesEnum.STUDENT);
            User user2 = new User("Mariya", "password", Others.UserRolesEnum.ADMIN);

            UserViewModel userViewModel = new UserViewModel(user);

            UserView userView = new UserView(userViewModel);

            userView.display();
        }
    }
}
