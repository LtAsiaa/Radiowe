using System;
using System.Collections.Generic;
using System.Text;

namespace Radiowe
{
    class User
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
    }
}

