using System;
using System.Data.SqlClient;
using System.Text;
using System.Data;


namespace Radio

{
    public static class DataBase
    {
        public static SqlConnection connection;
        //static void Connect()
        //{
        //    try
        //    {
        //        String conn = string.Format("Server = {0}; Database = {3}; User ID = {1}; Password = {2};Connection Timeout=30000; multisubnetfailover = false;", "radiowesystemy.database.windows.net", "przemo", "Radiowe2020", "radiowe");

        //        //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        //        //builder.DataSource = "<your_server.database.windows.net>";
        //        //builder.UserID = "<your_username>";
        //        //builder.Password = "<your_password>";
        //        //builder.InitialCatalog = "<your_database>";

        //        using (SqlConnection connection = new SqlConnection(conn))
        //        {
        //            Console.WriteLine("\nQuery data example:");
        //            Console.WriteLine("=========================================\n");

        //            connection.Open();

        //            String sql = "SELECT name, collation_name FROM sys.databases";

        //            using (SqlCommand command = new SqlCommand(sql, connection))
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //    Console.WriteLine("\nDone. Press enter.");
        //    Console.ReadLine();
        //}
        public static bool Open()
        {
            try
            {

                String conn = string.Format("Server = {0}; Database = {3}; User ID = {1}; Password = {2};Connection Timeout=30000; multisubnetfailover = false;", "radiowesystemy.database.windows.net", "przemo", "Radiowe2020", "radiowe");

                connection = new SqlConnection(conn);

                connection.Open();
               // _p = true;
                return true;
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Nie można połączyć z serwerem baz danych.\n Skontaktuj się z Administratorem bazy danych." + ex.Message, "Radio");

              //  _p = false;
                return false;
            }
        }

        public static void Close()
        {
            connection.Close();
          //  _p = false;
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
        public static DataTable BaseTable(string TableName)
        {
            using (SqlCommand cmd = connection.CreateCommand())
            {

                cmd.CommandText = string.Format("SELECT * FROM {0}", TableName);
                DataTable dt = new DataTable();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    dt.BeginLoadData();
                    dt.Load(r);
                    dt.EndLoadData();
                }
                return dt;
            }
        }

        public static void AddUser(string NazwaUzytkownika, int LokalizacjaX, int LokalizajaY, string MocNadawcza, string ZyskAntenyO, string ZyskAntenyN, int NumerKanalu)
        {
            Command(string.Format("INSERT dbo.Users2(Nazwa,X,Y,Moc,[Zysk Nadawczej],[Zysk Odbiorczej],[Numer Kanalu]) VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6});", NazwaUzytkownika, LokalizacjaX, LokalizajaY, MocNadawcza, ZyskAntenyO, ZyskAntenyN, NumerKanalu));
        }
        public static void addName(string name, string cell, string vall, int id)
        {
            Command(string.Format("dbo.{0} set \"{1}\"='{2}' where ID= ", name, cell, vall, id));
        }
    }

}
