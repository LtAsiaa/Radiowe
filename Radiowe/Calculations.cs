using System;
using System.Collections.Generic;
using System.Text;

namespace Radiowe
{
    public class Calculations
    {
        private double the_distance_; // do stacji starej
        private double the_distance_2; //do stacji nowej
        private double FSPL_; // do stacji starej
        private double FSPL_2; // do stacji nowej
        private double N_; // szum termiczny w dBm
        private double SNR_;
        private double receiver_power; 
        private double I_; // moc nadawcza zakłócającej stacji minus fspl = moc zakłóceń odbiornika z innej stacji nadawczej
        private double N_linear; // w watach
        private double I_linear; // w watach
        private double SINR_;
        private double ACLR_;



        public Calculations() { }
        public double CalculateTheDistace(double x_b, double y_b, double x_u, double y_u)
        {
             the_distance_ = Math.Sqrt(Math.Pow(x_b - x_u, 2) + Math.Pow(y_b - y_u, 2));
            return the_distance_;
        }
        public double CalculateTheDistace2(double x_b, double y_b, double x_u, double y_u)
        {
            the_distance_2 = Math.Sqrt(Math.Pow(x_b - x_u, 2) + Math.Pow(y_b - y_u, 2));
            return the_distance_2;
        }

        public double CalculateFSPL(double bandwidth)
        {
            //  FSPL_ = 32.44d + 20 * Math.Log10(the_distance_) + 20 * Math.Log10(band);
            FSPL_ = 92.45d + 20 * Math.Log10(the_distance_) + 20 * Math.Log10(bandwidth); // distance w km, band w GHz
            return FSPL_;
        }

        public double CalculateFSPL2(double bandwidth)
        {
            //  FSPL_ = 32.44d + 20 * Math.Log10(the_distance_) + 20 * Math.Log10(band);
            FSPL_2 = 92.45d + 20 * Math.Log10(the_distance_2) + 20 * Math.Log10(bandwidth);
            return FSPL_2;
        }
        public double CalculateReceiverPower(double transmitter_power, double transmitter_gain, double receiver_gain)
        {
            receiver_power = transmitter_power - FSPL_ + transmitter_gain + receiver_gain -4; // 4 odpowiada NF (noise figure)
            return receiver_power;
        }

        public double CalculateI_(double transmitter_interference_power, double transmitter_interference_gain, double receiver_gain) // pytanie
        {
            I_ = transmitter_interference_power - FSPL_2 + transmitter_interference_gain  + receiver_gain -4; // czy tutaj tez ma być wzmocnienie odbirnika (od starej stacji)
            return I_;
        }

        public double CalculateNoise(double band)
        {
            N_ = -174 + 10 * Math.Log10(band); // szerokośc pasma musi być w Hz 
            // N_ w dBm
            return N_;
        }
        public double CalculateSNR_Receiver()
        {
            SNR_ = receiver_power - N_;
            // SNR w dB
            return SNR_;
        }
        public double CalculateSINR(double channel_diff) 
        {
            if (channel_diff == 1)
            {
                ACLR_ = 40;
                I_linear = Math.Pow(10, (I_ - ACLR_) / 10) / 1000;
            }
            else if (channel_diff == 2)
            {
                ACLR_ = 60;
                I_linear = Math.Pow(10, (I_ - ACLR_) / 10) / 1000;
            }
            else if (channel_diff == 0)
            {
                ACLR_ = 0;
                I_linear = Math.Pow(10, (I_ - ACLR_) / 10) / 1000;
            }
            else
            {
                I_linear = 0;
            }


            N_linear = Math.Pow(10, N_ / 10) / 1000;
            double suma = 10 * Math.Log10(N_linear + I_linear) + 30;
            SINR_ = receiver_power - suma;
            return SINR_;
        }

        public double ToReplaceSINR(double old_SINR, double new_SINR )
        {
            Console.WriteLine("stary sinr: " + old_SINR + " nowy sinr: " + new_SINR);
            double roznica = 10 * Math.Log10(Math.Abs(Math.Pow(10, old_SINR / 10) - Math.Pow(10, new_SINR / 10)));
            //Console.WriteLine("nowy sinr:" + new_SINR);
            //Console.WriteLine("ToReplaceSinr: " + Math.Log10(Math.Pow(10, old_SINR / 10)) + " drugi człon " + Math.Pow(10, new_SINR / 10));
            Console.WriteLine("ROZNICA: " + roznica);
            //if(Double.IsNaN(roznica))
            //{
            ////    return old_SINR;
            //}
            return roznica;
        }

        /*
        public void CalculateSINR_ACLR() // różne kanały, pytanie
        {
            // sprawdzanie w jakim kanale nadaje stacja zakłócająca; 
            //...
            //
            N_linear = Math.Pow(10, N_ / 10) / 1000;
            // dla ch+1
            I_linear = Math.Pow(10, (I_ - 40) / 10) / 1000;
            double suma = 10 * Math.Log10(N_linear + I_linear) + 30;
            SINR_ = receiver_power  - suma;
            //dla ch+2
            I_linear = Math.Pow(10, (I_ - 60) / 10) / 1000;
            suma = 10 * Math.Log10(N_linear + I_linear) + 30;
            SINR_ = receiver_power  - suma;
        }
        */

    }
}
