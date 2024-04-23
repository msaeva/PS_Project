using DataLayer.Database;
using System.Windows.Controls;



namespace UI.Components
{
    /// <summary>
    /// Interaction logic for UsersLogs.xaml
    /// </summary>
    public partial class UsersLogs : UserControl
    {
        public UsersLogs()
        {
            InitializeComponent();
            using (var contxt = new DatabaseContext())
            {
                var records = contxt.Logs.ToList();
                logs.DataContext = records;
            }
        }
    }
}
