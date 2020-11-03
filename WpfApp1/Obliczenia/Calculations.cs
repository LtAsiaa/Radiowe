using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    class Calculations
    {
        private double the_distance_;
        private double FSPL_;

        public Calculations() { }
        public void CalculateTheDistace(double x_b, double y_b, double x_u, double y_u)
        {
            the_distance_ = Math.Sqrt(Math.Pow(x_b-x_u,2)+ Math.Pow(y_b - y_u, 2));
        }
        public void CalculateFSPL(double band)
        {
            FSPL_ = 32.44d + 20 * Math.Log10(the_distance_) + 20 * Math.Log10(band);
        }
    }
}
