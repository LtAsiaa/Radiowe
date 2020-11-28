using System;

namespace Radiowe
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = new WirelessNetwork();
            network.AddNewBaseStation(new BaseStation(5, 5, -40, 1,1));
            network.AddNewBaseStation(new BaseStation(10, 10, -40, 1, 1));
            //network.AddNewPair(new User(7, 5, 1, 1), new BaseStation(9, 13, 2, 5));
            network.test();
            network.CalculateSNR();
        }
    }
}
