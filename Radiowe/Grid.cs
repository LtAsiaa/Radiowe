﻿using System;
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
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
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

            if (CheckUserParameter(station) == false) return;

            //first_ = true;


            // DODAWANIE PIERWSZEJ STACJI DO SYSTEMU // tutaj raczej nie będzie sprawdzania first (to będzie w wireless network)
            if (first_)
            {
               // grid_[x, y].AddStation(station);
                for (int i = 0; i < kSize; i++)
                {
                    for (int j = 0; j < kSize; j++)
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
                for (int i = 0; i < kSize; i++)
                {
                    for (int j = 0; j < kSize; j++)
                    {
                        grid_[i, j].Print2(0);
                    }
                    Console.WriteLine("");
                }

            }
           
        }


       public void AddMoreBaseStation(BaseStation station_in_sys, BaseStation station_new)  //  nowa funkcja na dodawanie kolejnych stacji
        {

            if (CheckUserParameter(station_new) == false) return;
            // dodawanie temp macierzy
            grid_temp_ = new Cell[kSize, kSize];
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    grid_temp_[i, j] = (Cell)grid_[i, j].Clone();
                }
            }


            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
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
                        double temp6w = calculations_.CalculateSINR(channel_diff); // tu juz wychodzi nowa wartość SINR'u 

                        double newSinr = calculations_.ToReplaceSINR(grid_[i, j].GetSINR(station_in_sys.channel_), temp6w); 
                        double diff = calculations_.ToReplaceSINR(grid_[i, j].GetSINR(station_in_sys.channel_), newSinr); 
                        if(diff>=6)
                        {
                            grid_temp_[i, j].EditList(station_in_sys.name_, grid_temp_[i, j].GetSnr(station_in_sys.channel_), diff, station_in_sys.channel_);
                        }
                        else
                        {
                            Console.WriteLine("Interferencja destruktywna jest zbyt duża - stacja nie może zostać dodana do systemu");
                            return;
                        }
                        

                    }
                    
                    //double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    //double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                    //double SNRw = calculations_.CalculateSNR_Receiver();

                }
               
            }
            //sprawdznie w druga strone
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    double temp_1w = calculations_.CalculateTheDistace(station_new.GetLocationX(), station_new.GetLocationY(), i, j);
                    double temp_2w = calculations_.CalculateFSPL(2.4);
                    double temp_3w = calculations_.CalculateReceiverPower(station_new.GetPower(), station_new.GetGain(), station_new.antenna_gain_receiver_); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    double temp_4w = calculations_.CalculateNoise(station_new.band_);//pasmo
                    double SNRw = calculations_.CalculateSNR_Receiver();
                    if (i == station_new.GetLocationX() && j == station_new.GetLocationY())
                    {
                        grid_temp_[i, j].AddToList2(station_new.name_, -1, -1, station_new.channel_);
                    }
                    else
                        grid_temp_[i, j].AddToList2(station_new.name_, SNRw, SNRw, station_new.channel_);

                }
            }
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    if (grid_temp_[i, j].GetSINR(station_new.channel_) > 6)
                    {
                        double temp_1w = calculations_.CalculateTheDistace(station_new.GetLocationX(), station_new.GetLocationY(), i, j);
                        double temp_11w = calculations_.CalculateTheDistace2(station_in_sys.GetLocationX(), station_in_sys.GetLocationY(), i, j);
                        double temp_2w = calculations_.CalculateFSPL(2.4);
                        double temp_22w = calculations_.CalculateFSPL2(2.4);
                        double temp_3w = calculations_.CalculateReceiverPower(station_new.GetPower(), station_new.GetGain(), station_new.antenna_gain_receiver_);
                        double temp_4w = calculations_.CalculateI_(station_in_sys.GetPower(), station_in_sys.GetGain(), station_new.antenna_gain_receiver_);
                        double temp_5w = calculations_.CalculateNoise(station_new.band_);//pasmo
                        double channel_diff = Math.Abs(station_new.channel_ - station_in_sys.channel_);
                        double temp6w = calculations_.CalculateSINR(channel_diff); // tu juz wychodzi nowa wartość SINR'u 

                        double newSinr = calculations_.ToReplaceSINR(grid_temp_[i, j].GetSINR(station_new.channel_), temp6w);
                        double diff = calculations_.ToReplaceSINR(grid_temp_[i, j].GetSINR(station_new.channel_), newSinr);
                        if (diff >= 6)
                        {
                            grid_temp_[i, j].EditList(station_new.name_, grid_temp_[i, j].GetSnr(station_new.channel_), diff, station_new.channel_);
                        }
                        else
                        {
                            Console.WriteLine("Interferencja destruktywna jest zbyt duża - stacja nie może zostać dodana do systemu");
                            return;
                        }


                    }

                    //double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    //double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                    //double SNRw = calculations_.CalculateSNR_Receiver();

                }

            }










            Console.WriteLine("Użytkownik może zostać dodany do systemu");
            //zapisz kopie jako orginał
            for (int x = 0; x < kSize; x++)
            {
                for (int z = 0; z < kSize; z++)
                {
                    grid_temp_[x, z].Print2(0);
                }
                Console.WriteLine();
            }
            Console.WriteLine("tutaj");
            
        }
        public bool CheckUserParameter(BaseStation station)
        {
            // SPRAWDZANIE CZY STACJA MA WYSTARCZAJĄCĄ MOC
            double temp_1 = calculations_.CalculateTheDistace(0, 0, 1, 0);
            double temp_2 = calculations_.CalculateFSPL(2.4);
            double temp_3 = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), station.antenna_gain_receiver_); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
            double temp_4 = calculations_.CalculateNoise(station.band_);//pasmo
            double SNR = calculations_.CalculateSNR_Receiver();
            if (SNR < 6)
            {
                Console.WriteLine("złe dane - użytkownik dostaje informację, że nie może zostać wpuszczony do systemu");
                return false;
            }
            return true;
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
       private const int kSize=30;
       private Calculations calculations_;
    }
}