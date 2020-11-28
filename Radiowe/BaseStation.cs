using System;
using System.Collections.Generic;
using System.Text;
using Radiowe.Interfaces;
namespace Radiowe
{
    public class BaseStation: ILocationManagment
    {
        public BaseStation(int x, int y, int antenna_gain, int power, int number_of_channel , double band = 10000000)
        {
            location_ = new Tuple<int, int>(x, y);
            antenna_gain_ = antenna_gain;
            power_ = power;
            band_ = band;
            channel_ = number_of_channel;
        }
        public double band_
        {
            get;
            private set;
        }
        public double channel_
        {
            get;
            private set;
        }
        public int GetLocationX()
        {
            return location_.Item1;
        }
        public int GetLocationY()
        {
            return location_.Item2;
        }
        public int GetPower()
        {
            return power_;
        }
        public int GetGain()
        {
            return antenna_gain_;
        }
        private Tuple<int, int> location_;
        private int antenna_gain_;
        private int power_;
    }
}