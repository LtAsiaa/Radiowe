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

            //var calc = new Calculations();
            //calc.ToReplaceSINR(7.935459234000717d, 6.935475209128072);

            DataBase.Open();

            int id = 1;

            ///  DataBase.addName("Name1", 2.ToString(), "nazwa", 3);

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
            // network.AddStationToSystem(new BaseStation(4, 4, 5,10, 1,0, "pierwsza")); //odkomentuj
            // network.AddStationToSystem(new BaseStation(4, 4, 10, 10, 3, 0, "pierwszaipol"));
            //network.AddStationToSystem(new BaseStation(20, 20, 5, 3, 3, 0, "druga"));
            // network.AddStationToSystem(new BaseStation(10, 20, 5, 3, 2, 0, "trzeasdasdascia"));
            // network.AddStationToSystem(new BaseStation(5, 20, 40, 10, 1, 0, "trzecia")); //odkomentuj
            // network.AddStationToSystem(new BaseStation(25, 5, 5, 3, 5, 0, "czwarta")); // odkomentuj
            //int x, int y, double antenna_gain, double power, int number_of_channel , double antenna_gain_receiver, string name , double band = 10000000
            // network.AddStationToSystem(new BaseStation(6, 6, 10, 1, 3, 0, "trzecią")); // tą powinien dodać //odkomentuj
            //Console.WriteLine("Uzytkownik moze zostac dodany do systemu"); 



            //Console.WriteLine("Uzytkownik NIE moze zostac dodany do systemu");

            /*
            if (network.AddNewBaseStation(new BaseStation(15, 15, -20, -1, 1)))
            {
                //Console.WriteLine("Uzytkownik moze zostac dodany do systemu");
            }
            else
            {
                //Console.WriteLine("Uzytkownik NIE moze zostac dodany do systemu");
            }
            */
            //network.AddNewBaseStation(new BaseStation(5, 5, 0, 2,1));

            //network.AddNewPair(new User(7, 5, 1, 1), new BaseStation(9, 13, 2, 5));
            //network.test();
            //network.CalculateSNR();
        }
    }
}
