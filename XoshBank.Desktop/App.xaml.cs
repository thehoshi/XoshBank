using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using XoshBank.Persistent.SQLServer.Repositories;
using XoshBankCore.Entities.Repositories;

namespace XoshBank
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost",
                InitialCatalog = "LibraryManagement",
                IntegratedSecurity = true
            };

            string connectionString = connectionStringBuilder.ConnectionString;

            IUnitOfWork db = new MsSQLUnitOfWork(connectionString);

        }
    }
}