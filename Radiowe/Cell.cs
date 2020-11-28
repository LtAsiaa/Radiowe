using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Radiowe.Interfaces;

namespace Radiowe
{
    class Cell: IPrint, ICellManagment
    {
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
        public BaseStation GetBaseStation()
        {
            return station_;
        }

        private BaseStation station_;
        private List<Tuple<double, BaseStation>> snr_station_=new List<Tuple<double, BaseStation>>();
        private double SNR_;

    }
}
