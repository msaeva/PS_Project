using static WelcomeExtended.Others.Delegates;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Others;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using Welcome.Others;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user = new User("Mariya", "password", UserRolesEnum.ADMIN);
                UserViewModel userViewModel = new UserViewModel(user);
                UserView userView = new UserView(userViewModel);
                userView.display();
                // userView.displayError();

                UserData userData = new UserData();
                User studentUser = new User("student", "123", UserRolesEnum.STUDENT);
                User studentUser2 = new User("student2", "123", UserRolesEnum.STUDENT);
                User teacher = new User("teacher", "1234", UserRolesEnum.PROFESSOR);
                User admin = new User("admin", "12345", UserRolesEnum.ADMIN);
                userData.AddUser(studentUser);
                userData.AddUser(studentUser2);
                userData.AddUser(teacher);
                userData.AddUser(admin);

                string username;
                string password;
                string validationMessage;

                do
                {
                    Console.WriteLine("Enter your username:");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    password = Console.ReadLine();

                    validationMessage = UserHelper.ValidateCredentials(userData, username, password);

                    if (validationMessage != "Credentials are valid")
                    {
                        Console.WriteLine(validationMessage);
                    }
                } while (validationMessage != "Credentials are valid");

                User foundUser = UserHelper.GetUser(userData, username, password);
                string result = UserHelper.ToString(foundUser);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
