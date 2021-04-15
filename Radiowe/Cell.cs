using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Radiowe.Interfaces;

namespace Radiowe
{
    public class Cell : IPrint, ICellManagment
    {
        public Cell()
        {

        }
        public Cell(Cell cell) 
        {
            this.station_ = cell.station_;
            this.InitializeCell();
            for (int i = 1; i < cell.cell_info_.Count; i++)
            {
                this.EditList(cell.cell_info_[i - 1].Item1, cell.cell_info_[i - 1].Item2, cell.cell_info_[i - 1].Item3, i);
            }
            for (int i = 0; i < cell.snr_station_.Count; i++)
            {
                this.AddToList(cell.snr_station_[i].Item1, cell.snr_station_[i].Item2);
            }
        }

        public void Print(int type)
        {
            if (type == 0)
            {
                if (station_ != null)
                {
                    Console.Write("S |");
                }
                else
                {
                    if (snr_station_.Count != 0 && (snr_station_[0].Item1) > 6d)
                    {
              
                        if (Convert.ToInt32(snr_station_[0].Item1) < 10)
                        {
                            Console.Write("0" + Convert.ToInt32(snr_station_[0].Item1) + "|");
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
            else 
            {

            }

        }


        public void Print2(int type)
        {
            if (type == 0)// wyświetlanie w siatce tylko S - stacja
            {
                if (station_ != null)
                {
                   
                }
                else
                {
                    if (cell_info_.Count != 0 && (cell_info_[0].Item2) > 6d)
                    {
                       
                        if (Convert.ToInt32(cell_info_[0].Item2) < 10)
                        {
                            Console.Write("0" + Convert.ToInt32(cell_info_[0].Item2) + "|");
                        }
                        else
                        {
                            Console.Write(Convert.ToInt32(cell_info_[0].Item2) + "|");
                        }
                    }
                    else if (cell_info_.Count != 0 && (cell_info_[1].Item2) > 6d)
                    {
                        if (Convert.ToInt32(cell_info_[1].Item2) < 10)
                        {
                            Console.Write("0" + Convert.ToInt32(cell_info_[1].Item2) + "*");
                        }
                        else
                        {
                            Console.Write(Convert.ToInt32(cell_info_[1].Item2) + "*");
                        }
                    }
                    else
                    {
                        Console.Write("__|");

                    }
                }
            }
        }
        public void PrintTest()
        {

            if (station_ != null)
            {
          
            }
            else
            {
                if (cell_info_.Count != 0 && (cell_info_[0].Item2) > 0d)
                {
                  
                    if (Convert.ToInt32(cell_info_[0].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[0].Item2) + "!");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[0].Item2) + "!");
                    }
                }
                else if (cell_info_.Count != 0 && (cell_info_[1].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[1].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[1].Item2) + "@");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[1].Item2) + "@");
                    }
                }
                else if (cell_info_.Count != 0 && (cell_info_[2].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[2].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[2].Item2) + "#");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[2].Item2) + "#");
                    }
                }
                else if (cell_info_.Count != 0 && (cell_info_[3].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[3].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[3].Item2) + "$");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[3].Item2) + "$");
                    }
                }


                else if (cell_info_.Count != 0 && (cell_info_[4].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[4].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[4].Item2) + "%");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[4].Item2) + "%");
                    }
                }



                else if (cell_info_.Count != 0 && (cell_info_[5].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[5].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[5].Item2) + "^");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[5].Item2) + "^");
                    }
                }

                else if (cell_info_.Count != 0 && (cell_info_[6].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[6].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[6].Item2) + "&");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[6].Item2) + "&");
                    }
                }

                else if (cell_info_.Count != 0 && (cell_info_[7].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[6].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[7].Item2) + "*");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[7].Item2) + "*");
                    }
                }

                else if (cell_info_.Count != 0 && (cell_info_[8].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[6].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[8].Item2) + "(");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[8].Item2) + "(");
                    }
                }

                else if (cell_info_.Count != 0 && (cell_info_[9].Item2) > 0d)
                {
                    if (Convert.ToInt32(cell_info_[9].Item2) < 10)
                    {
                        Console.Write("0" + Convert.ToInt32(cell_info_[9].Item2) + ")");
                    }
                    else
                    {
                        Console.Write(Convert.ToInt32(cell_info_[9].Item2) + ")");
                    }
                }


                else
                {
                    Console.Write("__|");

                }

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
            cell_info_[channel - 1] = new Tuple<string, double, double>(BaseName, SNR, SINR);

        }
        public void AddToList2Copy(string BaseName, double SNR, double SINR, int channel)
        {
            cell_info_.Insert(channel, Tuple.Create(BaseName, SNR, SINR));
        }
        public void EditList(string BaseName, double SNR, double SINR, int channel)
        {
            cell_info_[channel - 1] = new Tuple<string, double, double>(BaseName, SNR, SINR);
            for (int i = 0; i < cell_info_.Count; i++)
            {
                if (cell_info_[i].Item1 == BaseName)
                {
                    //Console.WriteLine("dodałem na : " + i + " nazwa " + cell_info_[i].Item1);
                }

            }

        }
        public double GetSnr(int channel)
        {
            return cell_info_[channel - 1].Item2;
        }

        public BaseStation GetBaseStation()
        {
            return station_;
        }


        private BaseStation station_;
        private List<Tuple<double, BaseStation>> snr_station_ = new List<Tuple<double, BaseStation>>();
        private double SNR_;
        private double SINR;

        private List<Tuple<string, double, double>> cell_info_ = new List<Tuple<string, double, double>>();

        public void InitializeCell()
        {
            // List<Tuple<string, double, double>> cell_info_ = new List<Tuple<string, double, double>>();

            for (int i = 0; i < 10; i++)
            {
                cell_info_.Add(Tuple.Create("default", (double)0, (double)0));
            }
        }

        public double GetSINR(int channel)
        {
            return cell_info_[channel - 1].Item3;
        }

        public string GetName(int channel)
        {
            return cell_info_[channel - 1].Item1;
        }

    }
}
