using System;
using System.Collections.Generic;
using System.Text;
using Radiowe.Interfaces;
namespace Radiowe
{
    public class Grid : IPrint
    {
        public Grid()
        {
            calculations_ = new Calculations();
            grid_ = new Cell[kSize, kSize];
            for(int i=0;i<kSize;i++)
            {
                for(int j=0;j<kSize;j++)
                {
                    grid_[i,j] = new Cell();
                }
            }


        }
        public void Print(int type)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    grid_[i, j].Print(type);
                }
                Console.WriteLine(" ");
            }
        }
        public void AddBaseStation(int x,int y, BaseStation station)
        {
            if (amount_of_base_stations_ == 0)
            {
                grid_[x, y].AddStation(station);
                Console.WriteLine("RAZ");
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {

                        double temp_1 = calculations_.CalculateTheDistace(x, y, i, j);
                        double temp_2 = calculations_.CalculateFSPL(10); // podajemy w MHz
                        double temp_3 = calculations_.CalculateReceiverPower(20, station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                        double temp_4 = calculations_.CalculateNoise(station.band_);//pasmo
                        double SNR = temp_3 - temp_4;
                        grid_[i, j].AddToList(SNR, station);
                        //Console.WriteLine("x: " + i + " y: " + j + " distance: " + temp_1 + " FSPL: " + temp_2 + " rec pow: " + temp_3 + " SNR: " + SNR);
                    }
                }
                IncAmountBaseStation();
            }
            else
            {
                double SNR = 10;
                //
                size_ = 200;
                last_ = size_;
                while (SNR > 6 && SNR > 7d)
                 {
                    
                    double temp_1 = calculations_.CalculateTheDistace(x, y, size_, size_);
                    double temp_2 = calculations_.CalculateFSPL(10); // podajemy w MHz
                    double temp_3 = calculations_.CalculateReceiverPower(20, station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    double temp_4 = calculations_.CalculateNoise(station.band_);//pasmo
                    SNR = temp_3 - temp_4;
                    Console.WriteLine("SNR: " + SNR);
                    if (SNR<6)
                    {
                        last_ = size_;
                        size_ >>= 1;
                        Console.WriteLine("size: " + size_+ "last:"+ last_);
                    }
                    else
                    {
                        size_ =size_+ ((last_ - size_) / 2);
                        Console.WriteLine("size: " + size_ + "ELSE");
                    }
                }

            }                
        }
       public int GetAmountBaseStation()
       {
           return amount_of_base_stations_;
       }
       public void IncAmountBaseStation()
       {
           amount_of_base_stations_++;
       }
        private int temp_;
       private int size_;
        private int last_;
       private int amount_of_base_stations_=0;
       private Cell[,] grid_;
       private const int kSize=200;
       private Calculations calculations_;
    }
}
