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
        public void AddNewPair(User user,BaseStation base_station)
        {
            user_station_in_system_.Add(Tuple.Create(user, base_station));
            grid_.AddStationS(base_station.GetLocationX(), base_station.GetLocationY(), base_station);
            grid_.AddUser(user.GetLocationX(), user.GetLocationY(), user);
        }
        public void test()
        {
            grid_.Print(0);
        }
        public void CalculateSNR()
        {
            double temp1= calculations_.CalculateFSPL2(0.02, 0.8);
            double temp2 = calculations_.CalculateReceiverPower(20, 0, 0);
            double temp3 = calculations_.CalculateNoise(20000000);
            double SNR = temp2 - temp3;
            Console.WriteLine("FSPL: " + temp1);
            Console.WriteLine("PRX: " + temp2);
            Console.WriteLine("noise" + temp3);
            Console.WriteLine(SNR);
        }


        private List<Tuple<User, BaseStation>> user_station_in_system_ = new List<Tuple<User, BaseStation>>();
        private Calculations calculations_;
        private Grid grid_;

    }
}
