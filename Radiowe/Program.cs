using System;

namespace Radiowe
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = new WirelessNetwork();
            if(network.AddNewBaseStation(new BaseStation(10, 10, -20, 0, 1)))
            {
                //Console.WriteLine("Uzytkownik moze zostac dodany do systemu");
            }
            else
            {
                //Console.WriteLine("Uzytkownik NIE moze zostac dodany do systemu");
            }
            //network.AddNewBaseStation(new BaseStation(5, 5, 0, 2,1));
            
            //network.AddNewPair(new User(7, 5, 1, 1), new BaseStation(9, 13, 2, 5));
            //network.test();
            network.CalculateSNR();
        }
    }
}
