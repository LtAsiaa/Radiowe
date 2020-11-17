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
            
            grid_= new Cell[kSize, kSize];
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
        public void AddStationS(int x,int y, BaseStation station)
        {
            grid_[x, y].AddStation(station);
        }
        public void AddUser(int x,int y, User user)
        {
            grid_[x, y].AddUser(user);
        }

       private Cell[,] grid_;
       private const int kSize=200;
    }
}
