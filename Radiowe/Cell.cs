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
        public void Print(int type)
        {
            if(type == 0 )// wyświetlanie w siatce tylko S - stacja U - uzytkownik
            { 
            if(station_ !=null)
                {
                    Console.Write("S |");
                }
            else if (user_ !=null)
                {
                    Console.Write("U |");
                }
            else
                {
                    if ((snr_station_[0].Item1) > 6d)
                    {
                        //Console.Write("X|");
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

        public void AddUser(User user)
        {
            user_ = user;
        }

        public void AddStation(BaseStation station)
        {
            station_ = station;
        }

        public void DeleteUser()
        {
            user_ = null;
        }

        public void DeleteStation()
        {
            station_ = null;
        }

        public void AddToList(double SNR, BaseStation station)
        {
            snr_station_.Add(Tuple.Create(SNR, station));
        }
        

        private BaseStation station_;
        private User user_;
        private List<Tuple<double, BaseStation>> snr_station_=new List<Tuple<double, BaseStation>>();
        private double SNR_;

    }
}
