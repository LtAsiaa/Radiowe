using System;
using System.Data;
using System.Threading;

namespace Radiowe
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = new WirelessNetwork();


            DataBase.Open();

            int id = 1;

            while (true)
            {

                try
                {
                    DataTable x = DataBase.GetData(id);
                    network.AddStationToSystem(new BaseStation(Int32.Parse(x.Rows[0][2].ToString()), Int32.Parse(x.Rows[0][3].ToString()), double.Parse(x.Rows[0][6].ToString()), double.Parse(x.Rows[0][5].ToString()), Int32.Parse(x.Rows[0][4].ToString()), double.Parse(x.Rows[0][7].ToString()), x.Rows[0][0].ToString()));
                    //X                                 Y                                       Gain                                Power                                   Chanell                                 Gainrec                                      name
                    id++;
                }
                catch
                {
                    Thread.Sleep(1000);
                }


            }
          
        }
    }
}
