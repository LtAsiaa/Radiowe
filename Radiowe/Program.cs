using System;

namespace Radiowe
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = new WirelessNetwork();

     
            network.AddStationToSystem(new BaseStation(4, 4, 0,10, 1,0, "pierwsza"));
            network.AddStationToSystem(new BaseStation(4, 4, 0, 10, 1, 0, "pierwszaipol"));
            network.AddStationToSystem(new BaseStation(20, 20, 10, 1, 2, 0, "druga"));
           //network.AddStationToSystem(new BaseStation(10, 20, 10, 1, 1, 0, "trzecia"));
            //network.AddStationToSystem(new BaseStation(20, 5, 5, 3, 3, 0, "czwarta"));
            //int x, int y, double antenna_gain, double power, int number_of_channel , double antenna_gain_receiver, string name , double band = 10000000
            //network.AddStationToSystem(new BaseStation(5, 5, 10, 1, 2, 0, "trzecią"));
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
