using System;

namespace Radiowe
{
    class Program
    {
        static void Main(string[] args)
        {
            var network = new WirelessNetwork();
            network.AddNewPair(new User(0, 0, 0, 1), new BaseStation(5, 5, 0, 1));
            //network.AddNewPair(new User(7, 5, 1, 1), new BaseStation(9, 13, 2, 5));
            network.test();
            network.CalculateSNR();
        }
    }
}
