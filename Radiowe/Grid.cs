using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Radiowe.Interfaces;
namespace Radiowe
{
    public class Grid : IPrint
    {
        public  Grid()
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
            //return grid_;
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
        public Cell[,] AddFirstBaseStation(BaseStation station) // starczy przesyłanie samego base station
        {

            double SNR;
            int channel = station.channel_;
            // leftBorder_ = 0;
            // rightBorder_ = 1000;

           // if (CheckUserParameter(station) == false) return;

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
                        double temp_2w = calculations_.CalculateFSPL(2.4,1);
                        double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), station.antenna_gain_receiver_); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                        double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                        double SNRw = calculations_.CalculateSNR_Receiver();
                        if (i == station.GetLocationX() && j == station.GetLocationY())
                        {
                            ///grid_[i, j].AddToList2(station.name_, -1, -1, station.channel_);
                            grid_[i, j].AddToList2(station.name_, station.GetPower()+station.GetGain(), station.GetPower() + station.GetGain(), station.channel_); // -1, -1
                        }
                        else if (SNRw >= 6)
                        {
                            grid_[i, j].AddToList2(station.name_, SNRw, SNRw, station.channel_);
                          //  grid_[i, j].PrintTest();
                        }
                        
                        //Console.WriteLine("i: " + i + " j: " + j + " SNR " + SNRw);
                    }
                }
                first_ = false;
                for (int i = 0; i < kSize; i++)
                {
                    for (int j = 0; j < kSize; j++)
                    {
                        grid_[i, j].PrintTest();
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("pierwsza stacja");

                return grid_;
            }
            return null;
           
        }


       public bool AddMoreBaseStation(BaseStation station_in_sys, BaseStation station_new, int count)  //  nowa funkcja na dodawanie kolejnych stacji
        {
            
            //if (CheckUserParameter(station_new) == false) return false;
            // dodawanie temp macierzy
            
           
            if(count2 == 0) {
                Console.WriteLine("KOPIUJEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE:");
                grid_temp_ = new Cell[kSize, kSize];
                for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    grid_temp_[i, j] = new Cell(grid_[i, j]) ;
                }
            }
                Console.WriteLine("Print temp kopia:");
                for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    grid_temp_[i, j].PrintTest();
                }
                Console.WriteLine();
                    
                }
                Console.WriteLine("Print temp orginał:");
                for (int i = 0; i < kSize; i++)
                {
                    for (int j = 0; j < kSize; j++)
                    {
                        grid_[i, j].PrintTest();
                    }
                    Console.WriteLine();

                }
            }
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    if (grid_[i,j].GetSINR(station_in_sys.channel_) > 6 && grid_[i, j].GetName(station_in_sys.channel_) == station_in_sys.name_)
                    {
                        
                        Console.WriteLine("KOLEJNA ITERACJA");
                        double temp_1w = calculations_.CalculateTheDistace(station_in_sys.GetLocationX(), station_in_sys.GetLocationY(), i, j);
                        double temp_11w = calculations_.CalculateTheDistace2(station_new.GetLocationX(), station_new.GetLocationY(), i, j);
                        double temp_2w = calculations_.CalculateFSPL(2.4,1);
                        if (i == station_in_sys.GetLocationX() && j == station_in_sys.GetLocationY())
                        {
                            temp_2w = calculations_.CalculateFSPL(2.4, 0);
                        }
                        double temp_22w = calculations_.CalculateFSPL2(2.4,1);
                        double temp_3w = calculations_.CalculateReceiverPower(station_in_sys.GetPower(), station_in_sys.GetGain(), station_in_sys.antenna_gain_receiver_);
                      //  if (i == station_in_sys.GetLocationX() && j == station_in_sys.GetLocationY())
                      //  {
                      //      temp_3w = station_in_sys.GetPower()+ station_in_sys.GetGain()+ station_in_sys.antenna_gain_receiver_-4;
                      //  }
                        double temp_4w = calculations_.CalculateI_(station_new.GetPower(), station_new.GetGain(), station_in_sys.antenna_gain_receiver_);
                        double temp_5w = calculations_.CalculateNoise(station_in_sys.band_);//pasmo
                        double channel_diff = Math.Abs(station_in_sys.channel_ - station_new.channel_);
                        Console.WriteLine("channel diff" + channel_diff);
                        double oldSinr = grid_temp_[i, j].GetSINR(station_in_sys.channel_);
                        double temp6w = calculations_.CalculateSINR(channel_diff); // tu juz wychodzi nowa wartość SINR'u 
                        Console.WriteLine("Stara wartość SINR:" + grid_[i, j].GetSINR(station_in_sys.channel_));
                        Console.WriteLine("Nowa wartość SINR: " + temp6w);
                        double newSinr = calculations_.ToReplaceSINR(grid_[i, j].GetSINR(station_in_sys.channel_), temp6w); 
                        double diff = calculations_.ToReplaceSINR(grid_[i, j].GetSINR(station_in_sys.channel_), newSinr); // nowa wartość sinru (po odjeciu)
                        if (channel_diff > 2)
                        {
                            diff = oldSinr;
                        }
                        if(diff>=6)//!
                        {
                            Console.WriteLine("edytycja siatki pierwsza pętla"+" diff "+diff );
                            grid_temp_[i, j].EditList(station_in_sys.name_, grid_temp_[i, j].GetSnr(station_in_sys.channel_), diff, station_in_sys.channel_);
                        }
                        else
                        {
                            Console.WriteLine("Interferencja destruktywna jest zbyt duża - stacja nie może zostać dodana do systemu 1 petla"+" i "+i+" j "+j + " diff " + diff);
                            Console.WriteLine("wartości sinru" + " grid_[i, j].GetSINR(station_in_sys.channel_) " + grid_[i, j].GetSINR(station_in_sys.channel_) + " newSinr " + newSinr + " diff " + diff);
                            Console.WriteLine("newSinr " + " grid_[i, j].GetSINR(station_in_sys.channel_) " + grid_[i, j].GetSINR(station_in_sys.channel_) + " temp6w " + temp6w + " diff " + diff);
                            count2 = 0;
                            return false;
                        }
                        

                    }
                    
                    //double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    //double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                    //double SNRw = calculations_.CalculateSNR_Receiver();

                }
               
            }

            Console.WriteLine("Print temp kopia po piwerwszym przejsciu:");
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    grid_temp_[i, j].PrintTest();
                }
                Console.WriteLine();
            }
            Console.WriteLine("punkt prerwania");

            //sprawdznie w druga strone
            // tutaj dodawanie stacji nowej to grid_tempa
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    double temp_1w = calculations_.CalculateTheDistace(station_new.GetLocationX(), station_new.GetLocationY(), i, j);
                    double temp_2w = calculations_.CalculateFSPL(2.4,1);
                    double temp_3w = calculations_.CalculateReceiverPower(station_new.GetPower(), station_new.GetGain(), station_new.antenna_gain_receiver_); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    double temp_4w = calculations_.CalculateNoise(station_new.band_);//pasmo
                    double SNRw = calculations_.CalculateSNR_Receiver();
                    if (i == station_new.GetLocationX() && j == station_new.GetLocationY())
                    {
                        ///grid_temp_[i, j].AddToList2(station_new.name_, -1, -1, station_new.channel_);
                        grid_temp_[i, j].AddToList2(station_new.name_,station_new.GetPower()+station_new.GetGain(), station_new.GetPower() + station_new.GetGain(), station_new.channel_); // -1, -1
                    }
                    else if (SNRw >= 6)
                    {
                        grid_temp_[i, j].AddToList2(station_new.name_, SNRw, SNRw, station_new.channel_);
                    }
                        //grid_temp_[i, j].AddToList2(station_new.name_, SNRw, SNRw, station_new.channel_);
                        
                }
            }

            Console.WriteLine("Print temp kopia po dodaniu do tempa station_new:");
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    grid_temp_[i, j].PrintTest();
                }
                Console.WriteLine();
            }
            Console.WriteLine("punkt prerwania2");


            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    if (grid_temp_[i, j].GetSINR(station_new.channel_) > 6 && grid_temp_[i,j].GetName(station_new.channel_) == station_new.name_) //! 
                    {
                        double temp_1w = calculations_.CalculateTheDistace(station_new.GetLocationX(), station_new.GetLocationY(), i, j);
                        double temp_11w = calculations_.CalculateTheDistace2(station_in_sys.GetLocationX(), station_in_sys.GetLocationY(), i, j);
                        double temp_2w = calculations_.CalculateFSPL(2.4,1);
                        if (i == station_new.GetLocationX() && j == station_new.GetLocationY())
                        {
                            temp_2w = calculations_.CalculateFSPL(2.4, 0);
                        }
                        double temp_22w = calculations_.CalculateFSPL2(2.4,1);
                        double temp_3w = calculations_.CalculateReceiverPower(station_new.GetPower(), station_new.GetGain(), station_new.antenna_gain_receiver_);
                        double temp_4w = calculations_.CalculateI_(station_in_sys.GetPower(), station_in_sys.GetGain(), station_new.antenna_gain_receiver_);
                        double temp_5w = calculations_.CalculateNoise(station_new.band_);//pasmo
                        double channel_diff = Math.Abs(station_new.channel_ - station_in_sys.channel_);
                        double oldSinr = grid_temp_[i, j].GetSINR(station_new.channel_);
                        double temp6w = calculations_.CalculateSINR(channel_diff); // tu juz wychodzi nowa wartość SINR'u 
                        double newSinr = calculations_.ToReplaceSINR(grid_temp_[i, j].GetSINR(station_new.channel_), temp6w);
                        double diff = calculations_.ToReplaceSINR(grid_temp_[i, j].GetSINR(station_new.channel_), newSinr);
                        if (channel_diff > 2)
                        {
                            diff = oldSinr;
                        }
                        if (diff >= 6)
                        {
                            Console.WriteLine("edytycja listy druga pętla");
                            grid_temp_[i, j].EditList(station_new.name_, grid_temp_[i, j].GetSnr(station_new.channel_), diff, station_new.channel_);
                        }
                        else
                        {
                            Console.WriteLine("Interferencja destruktywna jest zbyt duża - stacja nie może zostać dodana do systemu 2petla");
                            count2 = 0;
                            return false;
                        }


                    }

                    //double temp_3w = calculations_.CalculateReceiverPower(station.GetPower(), station.GetGain(), 0); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    //double temp_4w = calculations_.CalculateNoise(station.band_);//pasmo
                    //double SNRw = calculations_.CalculateSNR_Receiver();

                }

            }

            Console.WriteLine("Print temp kopia po drugim przejściu:");
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    grid_temp_[i, j].PrintTest();
                }
                Console.WriteLine();
            }
            Console.WriteLine("punkt prerwania3");






            count2++;

            Console.WriteLine("count "+ count+" count 2 "+ count2+" SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
            if (count==count2)
            {
                Console.WriteLine("Użytkownik może zostać dodany do systemu xDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                //zapisz kopie jako orginał
                Console.WriteLine("orginał");
                for (int x = 0; x < kSize; x++)
                {
                    for (int z = 0; z < kSize; z++)
                    {
                        grid_[x, z].PrintTest();
                    }
                    Console.WriteLine();
                }

               
                Console.WriteLine("kopia ");
                for (int x = 0; x < kSize; x++)
                {
                    for (int z = 0; z < kSize; z++)
                    {
                        grid_temp_[x, z].PrintTest();
                    }
                    Console.WriteLine();
                }
                grid_ = grid_temp_;
                Console.WriteLine("nowy orginał");
                for (int x = 0; x < kSize; x++)
                {
                    for (int z = 0; z < kSize; z++)
                    {
                        grid_[x, z].PrintTest();
                    }
                    Console.WriteLine();
                }
                count2 = 0;
                return true;
                Console.WriteLine("tutaj");
            }
            return true; 

        }
        public bool CheckUserParameter(BaseStation station)
        {
            // SPRAWDZANIE CZY STACJA MA WYSTARCZAJĄCĄ MOC
            double temp_1 = calculations_.CalculateTheDistace(0, 0, 1, 0);
            double temp_2 = calculations_.CalculateFSPL(2.4,1);
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
        public Cell[,] ReturnGrid()
        {
            return grid_;
        }

        public bool first_ = true;
        private int leftBorder_;
        private int rightBorder_;
        private bool condition_;
       private int size_;
        private int last_;
       private int amount_of_base_stations_=0;
        private int count2 = 0;
       public Cell[,] grid_;
        public Cell[,] grid_temp_= new Cell[kSize, kSize];
       private const int kSize=200;
       private Calculations calculations_;
    }
}
