using System;
using System.Collections.Generic;
using System.Text;

namespace Radiowe
{
    public class WirelessNetwork
    {
        public WirelessNetwork()
        {
            calculations_ = new Calculations();
            grid_ = new Grid();
        }
        public void AddNewBaseStation(BaseStation base_station)
        {
            base_station_system_.Add(base_station);
            grid_.AddFirstBaseStation(base_station);
        }

        public void Add2(BaseStation baseStation1)
        {
            grid_.AddMoreBaseStation(base_station_system_[0], baseStation1);
        }
        public void test()
        {
            grid_.Print(0);
        }
        public void CalculateSNR() //testowe
        {
            double temp1= calculations_.CalculateFSPL(2.4);
            double temp2 = calculations_.CalculateReceiverPower(20, 0, 0);
            double temp3 = calculations_.CalculateNoise(10000000);
            double SNR = temp2 - temp3;
            Console.WriteLine("FSPL: " + temp1);
            Console.WriteLine("PRX: " + temp2);
            Console.WriteLine("noise" + temp3);
            Console.WriteLine(SNR);
        }

        private List<BaseStation> base_station_system_ = new List< BaseStation>();
        private Calculations calculations_;
        private Grid grid_;

    }
}
