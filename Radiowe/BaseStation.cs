using System;
using System.Collections.Generic;
using System.Text;
using Radiowe.Interfaces;
namespace Radiowe
{
    public class BaseStation : ILocationManagment
    {
        public BaseStation(int x, int y, double antenna_gain, double power, int number_of_channel, double antenna_gain_receiver, string name, double band = 10000000)
        {
            location_ = new Tuple<int, int>(x, y);
            antenna_gain_ = antenna_gain;
            power_ = power;
            band_ = band;
            channel_ = number_of_channel;
            antenna_gain_receiver_ = antenna_gain_receiver;
            name_ = name;
        }

        public string name_
        {
            get;
            private set;
        }

        public double antenna_gain_receiver_
        {
            get;
            private set;
        }
        public double band_
        {
            get;
            private set;
        }
        public int channel_
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
        public double GetPower()
        {
            return power_;
        }
        public double GetGain()
        {
            return antenna_gain_;
        }
        private Tuple<int, int> location_;
        private double antenna_gain_;
        private double power_;
    }
}