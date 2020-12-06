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
                    grid_[i, j].InitializeCell();
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
        public void AddFirstBaseStation(BaseStation station) // starczy przesyłanie samego base station
        {

            double SNR;
            int channel = station.channel_;
           // leftBorder_ = 0;
           // rightBorder_ = 1000;

            // SPRAWDZANIE CZY STACJA MA WYSTARCZAJĄCĄ MOC
            double temp_1 = calculations_.CalculateTheDistace(0, 0, 1, 0);
            double temp_2 = calculations_.CalculateFSPL(2.4); 
            double temp_3 = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), station.antenna_gain_receiver_); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
            double temp_4 = calculations_.CalculateNoise(station.band_);//pasmo
            SNR = calculations_.CalculateSNR_Receiver();
            if (SNR<6)
            {
                Console.WriteLine("złe dane - użytkownik dostaje informację, że nie może zostać wpuszczony do systemu");
                return;
                
            }
            //first_ = true;


            // DODAWANIE PIERWSZEJ STACJI DO SYSTEMU // tutaj raczej nie będzie sprawdzania first (to będzie w wireless network)
            if (first_)
            {
               // grid_[x, y].AddStation(station);
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        double temp_1w = calculations_.CalculateTheDistace(station.GetLocationX(), station.GetLocationY(), i, j);
                        double temp_2w = calculations_.CalculateFSPL(2.4);
                        double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), station.antenna_gain_receiver_); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                        double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                        double SNRw = calculations_.CalculateSNR_Receiver();
                        if (i == station.GetLocationX() && j == station.GetLocationY())
                        {
                            grid_[i, j].AddToList2(station.name_, -1, -1, station.channel_);
                        }
                        else
                        grid_[i, j].AddToList2(station.name_,SNRw,SNRw,station.channel_);
                        
                    }
                }
                first_ = false;
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        grid_[i, j].Print2(0);
                    }
                    Console.WriteLine("");
                }

            }
            /*
            while (!(SNR >= 6 && SNR <= 8))
            {
                last_ = leftBorder_ + (rightBorder_ - leftBorder_) / 2;
                Console.WriteLine("last_: " + last_);
                double temp1 = calculations_.CalculateTheDistace(0, 0, last_, 0);
                double temp2 = calculations_.CalculateFSPL(10); // podajemy w MHz
                double temp3 = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                double temp4 = calculations_.CalculateNoise(station.band_);//pasmo
                SNR = Convert.ToInt32(temp3 - temp4);
                Console.WriteLine("SNR: " + SNR);
                if (SNR > 6)
                {
                    leftBorder_ = last_;
                }
                else
                {
                    rightBorder_ = last_;
                }
                Console.WriteLine("leftBorder: " + leftBorder_ + "rightBorder:" + rightBorder_);
            }
            */

            /*
            condition_ = true;
                while(condition_)
                {
                last_++;
                     temp_1 = calculations_.CalculateTheDistace(0, 0, last_, 0);
                     temp_2 = calculations_.CalculateFSPL(10); // podajemy w MHz
                     temp_3 = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                     temp_4 = calculations_.CalculateNoise(station.band_);//pasmo
                    SNR = temp_3 - temp_4;
                    Console.WriteLine("SNR2: " + SNR);
                    if(SNR>6)
                    {

                    }
                    else
                    {
                    last_--;
                        condition_ = false;
                    }
                    Console.WriteLine("SNR2: " + SNR + "last_" + last_) ;
                    //grid_[x, y].AddStation(station);
                    for (int i = 0; i < 30; i++)
                    {
                        for (int j = 0; j < 30; j++)
                        {

                            double temp_1w = calculations_.CalculateTheDistace(x, y, i, j);
                            double temp_2w = calculations_.CalculateFSPL(10); // podajemy w MHz
                            double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                            double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                            double SNRw = temp_3w - temp_4w;
                            //grid_[i, j].AddToList(SNRw, station);
                        }
                    }
                }
                */

        }

        /*
        public bool TryAddNewStation(int x, int y, BaseStation station)
        {
            if (first_)
            {
                grid_[x, y].AddStation(station);
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {

                        double temp_1w = calculations_.CalculateTheDistace(x, y, i, j);
                        double temp_2w = calculations_.CalculateFSPL(2.4);
                        double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                        double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                        double SNRw = temp_3w - temp_4w;
                        grid_[i, j].AddToList(SNRw, station);
                    }
                }
                first_ = false;
                return true;
            }
            else
            {

                return false; 
            }
            
            last_+=3;
            grid_temp_=new Cell[last_*2, last_*2];
            for (int i = 0; i < last_*2; i++)
            {
                for (int j = 0; j < last_*2; j++)
                {
                    if ((x - last_ + i < 0 || y - last_ + j < 0) || (x + last_ + i > 200 || y + last_ + j > 200))
                    {
                        grid_temp_[i, j] = new Cell();
                    }
                    else
                    {
                        grid_temp_[i, j] = (Cell)grid_[x-last_ + i, y - last_ + j].Clone();
                    }
                }
            }
            grid_temp_[last_ , last_ ].AddStation(station);
            Console.WriteLine("last_: " + last_ + "last_" + last_);
            for (int i = 0; i < last_ * 2; i++)
            {
                for (int j = 0; j < last_ * 2; j++)
                {
                    double temp_1w = calculations_.CalculateTheDistace(last_, last_, i, j);
                    double temp_2w = calculations_.CalculateFSPL(10); // podajemy w MHz
                    double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
      
                    double SNRw = temp_3w - temp_4w;
                    grid_temp_[i, j].AddToList(SNRw, station);
                }
            }

            for (int i = 0; i < last_ * 2; i++)
            {
                for (int j = 0; j < last_ * 2; j++)
                {
                    //Console.WriteLine("i:" + i + "j" + j);
                    grid_temp_[i, j].Print(0);
                }
                Console.WriteLine("");
            }

            return false;
            }
            
        }
        */

       public void AddMoreBaseStation(BaseStation station_in_sys, BaseStation station_new)  //  nowa funkcja na dodawanie kolejnych stacji
        {
           

           // dodawanie temp macierzy
            grid_temp_ = new Cell[kSize, kSize];
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    grid_temp_[i, j] = (Cell)grid_[i, j].Clone();
                }
            }


            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (grid_[i,j].GetSINR(station_in_sys.channel_) > 6)
                    {
                        double temp_1w = calculations_.CalculateTheDistace(station_in_sys.GetLocationX(), station_in_sys.GetLocationY(), i, j);
                        double temp_11w = calculations_.CalculateTheDistace2(station_new.GetLocationX(), station_new.GetLocationY(), i, j);
                        double temp_2w = calculations_.CalculateFSPL(2.4);
                        double temp_22w = calculations_.CalculateFSPL2(2.4);
                        double temp_3w = calculations_.CalculateReceiverPower(station_in_sys.GetPower(), station_in_sys.GetGain(), station_in_sys.antenna_gain_receiver_);
                        double temp_4w = calculations_.CalculateI_(station_new.GetPower(), station_new.GetGain(), station_in_sys.antenna_gain_receiver_);
                        double temp_5w = calculations_.CalculateNoise(station_in_sys.band_);//pasmo
                        double channel_diff = Math.Abs(station_in_sys.channel_ - station_new.channel_);
                        double temp_6w = calculations_.CalculateSINR(channel_diff); // tu juz wychodzi nowa wartość SINR'u 
                        double newSinr = calculations_.ToReplaceSINR(grid_[i, j].GetSINR(station_in_sys.channel_), temp_6w); // roznica miedzy stara a nowa wartoscia
                        // tutaj trzeba zupdatować sinr (stara wartosc - roznica) - nie mozna bezposrednio wklejac nowej wartosci - przy dodawaniu kolejnych stacji to wazne
                        // to do 
                        // jak prosto updatowć tuple w liście?
                       

                    }
                    
                    
                    //double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    //double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                    //double SNRw = calculations_.CalculateSNR_Receiver();
                    
                }
            }

                Console.WriteLine("tutaj");
            
        }

       public int GetAmountBaseStation()
       {
           return amount_of_base_stations_;
       }
       public void IncAmountBaseStation()
       {
           amount_of_base_stations_++;
       }
        private bool first_ = true;
        private int leftBorder_;
        private int rightBorder_;
        private bool condition_;
       private int size_;
        private int last_;
       private int amount_of_base_stations_=0;
       private Cell[,] grid_;
        private Cell[,] grid_temp_;
       private const int kSize=200;
       private Calculations calculations_;
    }
}
