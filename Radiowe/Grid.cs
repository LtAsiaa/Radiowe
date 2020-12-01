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
        public void AddStationAndUser(int x,int y, BaseStation station, int x_u, int y_u, User user)
        {
            grid_[x, y].AddStation(station);
            grid_[x_u, y_u].AddUser(user);
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                   
                        double temp_1=calculations_.CalculateTheDistace(x, y, i, j);
                        double temp_2 = calculations_.CalculateFSPL(10); // podajemy w MHz
                        double temp_3 = calculations_.CalculateReceiverPower(20, station.GetGain(), user.GetAntenaGain()); 
                        double temp_4= calculations_.CalculateNoise(10000000);
                        double SNR = temp_3 - temp_4;
                        grid_[i, j].AddToList(SNR, station);
                    //Console.WriteLine("x: " + i + " y: " + j + " distance: " + temp_1 + " FSPL: " + temp_2 + " rec pow: " + temp_3 + " SNR: " + SNR);




                }
            }
        }
        public void AddUser(int x,int y, User user)
        {
            grid_[x, y].AddUser(user);
        }

       private Cell[,] grid_;
       private const int kSize=200;
       private Calculations calculations_;
    }
}
