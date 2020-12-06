using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Radiowe.Interfaces;

namespace Radiowe
{
    class Cell: IPrint, ICellManagment
    {// Id X Y 10x double liczba 10x Id_base_station 
        public Cell()
        {

        }
        public Object Clone()
        {
            return MemberwiseClone();
        }
        public void Print(int type)
        {
            if(type == 0 )// wyświetlanie w siatce tylko S - stacja
            { 
            if(station_ !=null)
                {
                    Console.Write("S |");
                }
            else
                {
                    if (snr_station_.Count!=0 &&(snr_station_[0].Item1) > 6d)
                    {
                        //Console.Write(snr_station_[0].Item1);
                        //Console.WriteLine("SNR: " + snr_station_[0].Item1);
                        if (Convert.ToInt32(snr_station_[0].Item1) < 10)
                        {
                            Console.Write("0"+Convert.ToInt32(snr_station_[0].Item1) + "|");
                        }
                        else
                            { 
                            Console.Write(Convert.ToInt32(snr_station_[0].Item1) + "|");
                        }
                    }
                    else
                    {
                        Console.Write("__|");
                    }
                        
                    
                }

             }
            else // wyświetlanie S U i SNR
            {

            }
           
        }


        public void Print2(int type)
        {
            if (type == 0)// wyświetlanie w siatce tylko S - stacja
            {
                if (station_ != null)
                {
                   // Console.Write("S |");
                }
                else
                {
                    if (cell_info_.Count != 0 && (cell_info_[0].Item2) > 6d)
                    {
                        //Console.Write(snr_station_[0].Item1);
                        //Console.WriteLine("SNR: " + snr_station_[0].Item1);
                        if (Convert.ToInt32(cell_info_[0].Item2) < 10)
                        {
                            Console.Write("0" + Convert.ToInt32(cell_info_[0].Item2) + "|");
                        }
                        else
                        {
                            Console.Write(Convert.ToInt32(cell_info_[0].Item2) + "|");
                        }
                    }
                    else
                    {
                        Console.Write("__|");
                    }


                }

            }
            else // wyświetlanie S U i SNR
            {

            }

        }


        public void AddStation(BaseStation station)
        {
            station_ = station;
        }

        public void DeleteStation()
        {
            station_ = null;
        }

        public void AddToList(double SNR, BaseStation station)
        {
            snr_station_.Add(Tuple.Create(SNR, station));
        }

        public void AddToList2(string BaseName, double SNR, double SINR, int channel)
        {
            cell_info_.Insert(channel - 1, Tuple.Create(BaseName, SNR, SINR));
        }
        public BaseStation GetBaseStation()
        {
            return station_;
        }

        private BaseStation station_;
        private List<Tuple<double, BaseStation>> snr_station_=new List<Tuple<double, BaseStation>>();
        private double SNR_;
        private double SINR;

        private List<Tuple<string, double, double>> cell_info_ = new List<Tuple<string, double, double>>();

        public void InitializeCell()
        {
           // List<Tuple<string, double, double>> cell_info_ = new List<Tuple<string, double, double>>();

            for(int i = 0; i < 10; i++)
            {
                cell_info_.Add(Tuple.Create("default",(double)0,(double)0));
            }
        }
        
        public double GetSINR(int channel)
        {
            return cell_info_[channel - 1].Item3;
        }

   
    }
}
