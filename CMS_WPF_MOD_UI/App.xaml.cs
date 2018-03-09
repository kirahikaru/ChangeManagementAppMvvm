using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;
using DataLayer.Repositories;
using System.Windows;

namespace ChangeManagementAppModern
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Unit of Work Instance
        /// </summary>
        public static UnitOfWork UoW = null;
        public static OUser LoggedInUser = null;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            App.UoW = new UnitOfWork(new DatabaseContext());
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (App.UoW != null)
            {
                App.UoW.Dispose();
                App.UoW = null;
            }
        }
    }
}
