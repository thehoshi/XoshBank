using System.Data.SqlClient;
using System.Windows;
using XoshBank.Core.Repositories;
using XoshBank.Desktop.Views;
using XoshBank.Persistent.SQLServer.Repositories;
using XoshBank.ViewModels;
using XoshBank.Views;

namespace XoshBank
{ 
    public partial class App : Application
    { 
        public App()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                InitialCatalog = "XoshBank",
                TrustServerCertificate = true
            };

            string connectionString = connectionStringBuilder.ConnectionString;

            IUnitOfWork unitOfWork = new MsSQLUnitOfWork(connectionString);

            MainWindow mainWindow = new MainWindow();
            MainPageViewModel mainPageViewModel = new MainPageViewModel(unitOfWork);
            mainWindow.DataContext = mainPageViewModel;
            mainWindow.Show();

        }
    }
}