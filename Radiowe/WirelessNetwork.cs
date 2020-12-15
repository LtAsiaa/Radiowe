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
        public void AddStationToSystem(BaseStation base_station)
        {
            if(base_station_system_.Count==0)
            {
                base_station_system_.Add(base_station);
                grid_.AddFirstBaseStation(base_station);
            }
            else
            {
                int counter = 0;
                foreach (var list_station in base_station_system_)
                {
                    Console.WriteLine("POROWNUJE STACJE ");
                    if (grid_.AddMoreBaseStation(list_station, base_station, base_station_system_.Count) == true)
                    {
                        counter++;
                    }
                    else break;
                }
                if (counter == base_station_system_.Count)
                {
                    Console.WriteLine("ROWNA SIE SOBIE");
                    base_station_system_.Add(base_station);
                }
                else
                {
                    Console.WriteLine("NIE DODA SIE");
                }
            }
        }
        public void AddNewBaseStation(BaseStation base_station) //tylko raz dla pierwszej -- w przyszlości można usunąć
        {
            base_station_system_.Add(base_station);
            grid_.AddFirstBaseStation(base_station);
        }

        public void Add2(BaseStation baseStation1) // sprawdzanie stara do nowej -- w przyszłości można usunąc
        {
            foreach(var list_station in base_station_system_)
            {
                //grid_.AddMoreBaseStation(list_station, baseStation1);
            }
        }
        public void test()
        {
            grid_.Print(0);
        }
        public void CalculateSNR() //testowe -- można usunąć w przyszłości
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

        private List<BaseStation> base_station_system_ = new List<BaseStation>(); // przy uruchomieniu wgrywanie stacji bazowych
        private Calculations calculations_;
        private Grid grid_;

    }
}
