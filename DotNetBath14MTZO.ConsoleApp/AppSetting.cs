using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.ConsoleApp
{
    public static class AppSetting
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder { get; } = new SqlConnectionStringBuilder()
        { 
            DataSource=".",
            InitialCatalog="WalletDb",
            UserID="sa",
            Password="mtzoo@123",
            TrustServerCertificate=true
        };
    }
}
