using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp1
{
    static partial class Base
    {
        public static SqlConnection connection;
        
        static bool _p = false;
        public static bool Polaczono
        {
            get
            {
                return _p;
            }
        }

        public static bool Open(string source, string database, string user, string password)
        {
            try
            {
                //String conn = "Server=localhost\\SQLEXPRESS; Database=sezam2000; Integrated Security = SSPI;"; // autoryzacja windows
            //   String conn = string.Format("Server = {0}; Database = {3};Integrated Security = SSPI;", source, user, password, database); // autoryzacja windows parametry z aplikacji
                String conn = string.Format("Server = {0}; Database = {3}; User ID = {1}; Password = {2};Connection Timeout=30000; multisubnetfailover = false;", source, user, password, database); // autoryzacja sieciowa z aplikacji
                //connection = new SqlConnection(conn);
                connection = new SqlConnection(conn);

                //  Console.WriteLine("State: {0}", connection.State);
                //   Console.WriteLine("ConnectionTimeout: {0}",
                //       connection.ConnectionTimeout);
                //  connection = new SqlConnection(string.Format("Server = localhost\\sqlexpress; Data Source = {0}; Initial Catalog = {3}; User ID = {1}; Password = {2}", source, user, password, database));
                //"Server = localhost\sqlexpress;"
                //   connetionString = "Data Source=ServerName;Initial Catalog=sezam2000;Integrated Security=SSPI;"
                //             < connectionStrings >
                //  < add name = "MyDbConn1"
                //       connectionString = "Server=MyServer;Database=MyDb;Trusted_Connection=Yes;" />
                //  < add name = "MyDbConn2"
                //      connectionString = "Initial Catalog=MyDb;Data Source=MyServer;Integrated Security=SSPI;" />
                //</ connectionStrings >
              

                //(string.Format("DataSource = {0}; Database = {3}; UserID = {1}; Password = {2}", source, user, password, database));
                connection.Open();
                _p = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie można połączyć z serwerem baz danych\n" + ex.Message, "Radio");

                _p = false;
                return false;
            }
        }

        public static void Close()
        {
            connection.Close();
            _p = false;
        }

        public static void Command(string ask)
        {
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand cmd = new SqlCommand(ask, connection, transaction);
            cmd.ExecuteNonQuery();

            transaction.Commit();

        }
        public static void Command(string ask, out DataTable result)
        {
            DataTable dt = new DataTable();

            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand cmd = new SqlCommand(ask, connection, transaction);

            using (SqlDataReader r = cmd.ExecuteReader())
            {
                dt.BeginLoadData();
                dt.Load(r);
                dt.EndLoadData();
            }
            transaction.Commit();
            result = dt;
        }

    }
}
