using System;
using System.Collections.Generic;
using System.Text;
using Radiowe.Interfaces;
namespace Radiowe
{
    public class User : ILocationManagment
    {
        public Tuple<int, int> location_;
        int antenna_gain_;
        int channel_number_;

        public User(int x, int y, int antenna_gain, int channel_number)
        {
            location_ = new Tuple<int, int>(x, y);
            antenna_gain_ = antenna_gain;
            channel_number_ = channel_number;
        }
        public int GetLocationX()
        {
            return location_.Item1;
        }
        public int GetLocationY()
        {
            return location_.Item2;
        }
        public int GetAntenaGain()
        {
            return antenna_gain_;
        }
    }
}

