using System;

namespace Radiowe
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = new WirelessNetwork();


            network.AddNewBaseStation(new BaseStation(10, 10, 20, 5, 1,0, "pierwsza"));

            network.Add2(new BaseStation(20, 20, 25, 5, 2, 0, "druga"));
            
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
