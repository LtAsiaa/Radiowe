using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace WpfApp1
{
    class AzureMySql
    {
        static async Task Main(string[] args)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "YOUR-SERVER.mysql.database.azure.com",
                Database = "YOUR-DATABASE",
                UserID = "USER@YOUR-SERVER",
                Password = "PASSWORD",
                SslMode = MySqlSslMode.Required,
            };
        }
    }
}
