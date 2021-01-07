using System;
using System.Collections.Generic;
using System.Data;
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
                    // {} pobieranie danych i wrzucanie do grid_

                    DataTable fromdb_table1 = new DataTable("Name_1");
                    DataTable fromdb_table2 = new DataTable("Name_2");
                    DataTable fromdb_table3 = new DataTable("Name_3");
                    DataTable fromdb_table4 = new DataTable("Name_4");
                    DataTable fromdb_table5 = new DataTable("Name_5");
                    DataTable fromdb_table6 = new DataTable("Name_6");
                    DataTable fromdb_table7 = new DataTable("Name_7");
                    DataTable fromdb_table8 = new DataTable("Name_8");
                    DataTable fromdb_table9 = new DataTable("Name_9");
                    DataTable fromdb_table10 = new DataTable("Name_10");
                    DataTable fromdb_table11 = new DataTable("SNR_1");
                    DataTable fromdb_table12 = new DataTable("SNR_2");
                    DataTable fromdb_table13 = new DataTable("SNR_3");
                    DataTable fromdb_table14 = new DataTable("SNR_4");
                    DataTable fromdb_table15 = new DataTable("SNR_5");
                    DataTable fromdb_table16 = new DataTable("SNR_6");
                    DataTable fromdb_table17 = new DataTable("SNR_7");
                    DataTable fromdb_table18 = new DataTable("SNR_8");
                    DataTable fromdb_table19 = new DataTable("SNR_9");
                    DataTable fromdb_table20 = new DataTable("SNR_10");
                    DataTable fromdb_table21 = new DataTable("SINR_1");
                    DataTable fromdb_table22 = new DataTable("SINR_2");
                    DataTable fromdb_table23 = new DataTable("SINR_3");
                    DataTable fromdb_table24 = new DataTable("SINR_4");
                    DataTable fromdb_table25 = new DataTable("SINR_5");
                    DataTable fromdb_table26 = new DataTable("SINR_6");
                    DataTable fromdb_table27 = new DataTable("SINR_7");
                    DataTable fromdb_table28 = new DataTable("SINR_8");
                    DataTable fromdb_table29 = new DataTable("SINR_9");
                    DataTable fromdb_table30 = new DataTable("SINR_10");


                    DataColumn column1;
                    column1 = new DataColumn();
                    column1.DataType = System.Type.GetType("System.Int32");
                    column1.ColumnName = "lokalizacjaX";
                    DataColumn column2;
                    column2 = new DataColumn();
                    column2.DataType = System.Type.GetType("System.Int32");
                    column2.ColumnName = "lokalizacjaY";
                    DataColumn columnName;
                    columnName = new DataColumn();
                    columnName.DataType = System.Type.GetType("System.String");
                    columnName.ColumnName = "NazwaStacji";
                    DataColumn columnSNR;
                    columnSNR = new DataColumn();
                    columnSNR.DataType = System.Type.GetType("System.Double");
                    columnSNR.ColumnName = "SNR";
                    DataColumn columnSINR;
                    columnSINR = new DataColumn();
                    columnSINR.DataType = System.Type.GetType("System.Double");
                    columnSINR.ColumnName = "SINR";

                    fromdb_table1.Columns.Add(column1);
                    fromdb_table1.Columns.Add(column2);
                    fromdb_table1.Columns.Add(columnName);
                    fromdb_table2.Columns.Add(column1);
                    fromdb_table2.Columns.Add(column2);
                    fromdb_table2.Columns.Add(columnName);
                    fromdb_table3.Columns.Add(column1);
                    fromdb_table3.Columns.Add(column2);
                    fromdb_table3.Columns.Add(columnName);
                    fromdb_table3.Columns.Add(column1);
                    fromdb_table3.Columns.Add(column2);
                    fromdb_table3.Columns.Add(columnName);
                    fromdb_table4.Columns.Add(column1);
                    fromdb_table4.Columns.Add(column2);
                    fromdb_table4.Columns.Add(columnName);
                    fromdb_table5.Columns.Add(column1);
                    fromdb_table5.Columns.Add(column2);
                    fromdb_table5.Columns.Add(columnName);
                    fromdb_table6.Columns.Add(column1);
                    fromdb_table6.Columns.Add(column2);
                    fromdb_table6.Columns.Add(columnName);
                    fromdb_table7.Columns.Add(column1);
                    fromdb_table7.Columns.Add(column2);
                    fromdb_table7.Columns.Add(columnName);
                    fromdb_table8.Columns.Add(column1);
                    fromdb_table8.Columns.Add(column2);
                    fromdb_table8.Columns.Add(columnName);
                    fromdb_table9.Columns.Add(column1);
                    fromdb_table9.Columns.Add(column2);
                    fromdb_table9.Columns.Add(columnName);
                    fromdb_table10.Columns.Add(column1);
                    fromdb_table10.Columns.Add(column2);
                    fromdb_table10.Columns.Add(columnName);

                    fromdb_table11.Columns.Add(column1);
                    fromdb_table11.Columns.Add(column2);
                    fromdb_table11.Columns.Add(columnSNR);
                    fromdb_table12.Columns.Add(column1);
                    fromdb_table12.Columns.Add(column2);
                    fromdb_table12.Columns.Add(columnSNR);
                    fromdb_table13.Columns.Add(column1);
                    fromdb_table13.Columns.Add(column2);
                    fromdb_table13.Columns.Add(columnSNR);
                    fromdb_table14.Columns.Add(column1);
                    fromdb_table14.Columns.Add(column2);
                    fromdb_table14.Columns.Add(columnSNR);
                    fromdb_table15.Columns.Add(column1);
                    fromdb_table15.Columns.Add(column2);
                    fromdb_table15.Columns.Add(columnSNR);
                    fromdb_table16.Columns.Add(column1);
                    fromdb_table16.Columns.Add(column2);
                    fromdb_table16.Columns.Add(columnSNR);
                    fromdb_table17.Columns.Add(column1);
                    fromdb_table17.Columns.Add(column2);
                    fromdb_table17.Columns.Add(columnSNR);
                    fromdb_table18.Columns.Add(column1);
                    fromdb_table18.Columns.Add(column2);
                    fromdb_table18.Columns.Add(columnSNR);
                    fromdb_table19.Columns.Add(column1);
                    fromdb_table19.Columns.Add(column2);
                    fromdb_table19.Columns.Add(columnSNR);
                    fromdb_table20.Columns.Add(column1);
                    fromdb_table20.Columns.Add(column2);
                    fromdb_table20.Columns.Add(columnSNR);

                    fromdb_table21.Columns.Add(column1);
                    fromdb_table21.Columns.Add(column2);
                    fromdb_table21.Columns.Add(columnSINR);
                    fromdb_table22.Columns.Add(column1);
                    fromdb_table22.Columns.Add(column2);
                    fromdb_table22.Columns.Add(columnSINR);
                    fromdb_table23.Columns.Add(column1);
                    fromdb_table23.Columns.Add(column2);
                    fromdb_table23.Columns.Add(columnSINR);
                    fromdb_table24.Columns.Add(column1);
                    fromdb_table24.Columns.Add(column2);
                    fromdb_table24.Columns.Add(columnSINR);
                    fromdb_table25.Columns.Add(column1);
                    fromdb_table25.Columns.Add(column2);
                    fromdb_table25.Columns.Add(columnSINR);
                    fromdb_table26.Columns.Add(column1);
                    fromdb_table26.Columns.Add(column2);
                    fromdb_table26.Columns.Add(columnSINR);
                    fromdb_table27.Columns.Add(column1);
                    fromdb_table27.Columns.Add(column2);
                    fromdb_table27.Columns.Add(columnSINR);
                    fromdb_table28.Columns.Add(column1);
                    fromdb_table28.Columns.Add(column2);
                    fromdb_table28.Columns.Add(columnSINR);
                    fromdb_table29.Columns.Add(column1);
                    fromdb_table29.Columns.Add(column2);
                    fromdb_table29.Columns.Add(columnSINR);
                    fromdb_table30.Columns.Add(column1);
                    fromdb_table30.Columns.Add(column2);
                    fromdb_table30.Columns.Add(columnSINR);

                    // zaciąganie danych z db to lokalnych datatable
                    // potem uzupełnienie grida obliczeń
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
                            //grid_[i, j].AddToList2(station.name_, station.GetPower()+station.GetGain(), station.GetPower() + station.GetGain(), station.channel_); // -1, -1
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

            }
           
        }


       public bool AddMoreBaseStation(BaseStation station_in_sys, BaseStation station_new, int count)  //  nowa funkcja na dodawanie kolejnych stacji
        {
            
            if (CheckUserParameter(station_new) == false) return false;
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
                        double temp_2w = calculations_.CalculateFSPL(2.4);
                        double temp_22w = calculations_.CalculateFSPL2(2.4);
                        double temp_3w = calculations_.CalculateReceiverPower(station_in_sys.GetPower(), station_in_sys.GetGain(), station_in_sys.antenna_gain_receiver_);
                        double temp_4w = calculations_.CalculateI_(station_new.GetPower(), station_new.GetGain(), station_in_sys.antenna_gain_receiver_);
                        double temp_5w = calculations_.CalculateNoise(station_in_sys.band_);//pasmo
                        double channel_diff = Math.Abs(station_in_sys.channel_ - station_new.channel_);
                        Console.WriteLine("channel diff" + channel_diff);
                        double temp6w = calculations_.CalculateSINR(channel_diff); // tu juz wychodzi nowa wartość SINR'u 
                        Console.WriteLine("Stara wartość SINR:" + grid_[i, j].GetSINR(station_in_sys.channel_));
                        Console.WriteLine("Nowa wartość SINR: " + temp6w);
                        double newSinr = calculations_.ToReplaceSINR(grid_[i, j].GetSINR(station_in_sys.channel_), temp6w); 
                        double diff = calculations_.ToReplaceSINR(grid_[i, j].GetSINR(station_in_sys.channel_), newSinr); // nowa wartość sinru (po odjeciu)
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
                    double temp_2w = calculations_.CalculateFSPL(2.4);
                    double temp_3w = calculations_.CalculateReceiverPower(station_new.GetPower(), station_new.GetGain(), station_new.antenna_gain_receiver_); //0 - zysk anteny uzytkownika - gui musi dodać (GUI)
                    double temp_4w = calculations_.CalculateNoise(station_new.band_);//pasmo
                    double SNRw = calculations_.CalculateSNR_Receiver();
                    if (i == station_new.GetLocationX() && j == station_new.GetLocationY())
                    {
                        grid_temp_[i, j].AddToList2(station_new.name_, -1, -1, station_new.channel_);
                       // grid_temp_[i, j].AddToList2(station_new.name_,station_new.GetPower()+station_new.GetGain(), station_new.GetPower() + station_new.GetGain(), station_new.channel_); // -1, -1
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

                DataTable todb_table1 = new DataTable("Name_1");
                DataTable todb_table2 = new DataTable("Name_2");
                DataTable todb_table3 = new DataTable("Name_3");
                DataTable todb_table4 = new DataTable("Name_4");
                DataTable todb_table5 = new DataTable("Name_5");
                DataTable todb_table6 = new DataTable("Name_6");
                DataTable todb_table7 = new DataTable("Name_7");
                DataTable todb_table8 = new DataTable("Name_8");
                DataTable todb_table9 = new DataTable("Name_9");
                DataTable todb_table10 = new DataTable("Name_10");
                DataTable todb_table11 = new DataTable("SNR_1");
                DataTable todb_table12 = new DataTable("SNR_2");
                DataTable todb_table13 = new DataTable("SNR_3");
                DataTable todb_table14 = new DataTable("SNR_4");
                DataTable todb_table15 = new DataTable("SNR_5");
                DataTable todb_table16 = new DataTable("SNR_6");
                DataTable todb_table17 = new DataTable("SNR_7");
                DataTable todb_table18 = new DataTable("SNR_8");
                DataTable todb_table19 = new DataTable("SNR_9");
                DataTable todb_table20 = new DataTable("SNR_10");
                DataTable todb_table21 = new DataTable("SINR_1");
                DataTable todb_table22 = new DataTable("SINR_2");
                DataTable todb_table23 = new DataTable("SINR_3");
                DataTable todb_table24 = new DataTable("SINR_4");
                DataTable todb_table25 = new DataTable("SINR_5");
                DataTable todb_table26 = new DataTable("SINR_6");
                DataTable todb_table27 = new DataTable("SINR_7");
                DataTable todb_table28 = new DataTable("SINR_8");
                DataTable todb_table29 = new DataTable("SINR_9");
                DataTable todb_table30 = new DataTable("SINR_10");

                DataColumn column1;
                column1 = new DataColumn();
                column1.DataType = System.Type.GetType("System.Int32");
                column1.ColumnName = "lokalizacjaX";
                DataColumn column2;
                column2 = new DataColumn();
                column2.DataType = System.Type.GetType("System.Int32");
                column2.ColumnName = "lokalizacjaY";
                DataColumn columnName;
                columnName = new DataColumn();
                columnName.DataType = System.Type.GetType("System.String");
                columnName.ColumnName = "NazwaStacji";
                DataColumn columnSNR;
                columnSNR = new DataColumn();
                columnSNR.DataType = System.Type.GetType("System.Double");
                columnSNR.ColumnName = "SNR";
                DataColumn columnSINR;
                columnSINR = new DataColumn();
                columnSINR.DataType = System.Type.GetType("System.Double");
                columnSINR.ColumnName = "SINR";

                todb_table1.Columns.Add(column1);
                todb_table1.Columns.Add(column2);
                todb_table1.Columns.Add(columnName);
                todb_table2.Columns.Add(column1);
                todb_table2.Columns.Add(column2);
                todb_table2.Columns.Add(columnName);
                todb_table3.Columns.Add(column1);
                todb_table3.Columns.Add(column2);
                todb_table3.Columns.Add(columnName);
                todb_table3.Columns.Add(column1);
                todb_table3.Columns.Add(column2);
                todb_table3.Columns.Add(columnName);
                todb_table4.Columns.Add(column1);
                todb_table4.Columns.Add(column2);
                todb_table4.Columns.Add(columnName);
                todb_table5.Columns.Add(column1);
                todb_table5.Columns.Add(column2);
                todb_table5.Columns.Add(columnName);
                todb_table6.Columns.Add(column1);
                todb_table6.Columns.Add(column2);
                todb_table6.Columns.Add(columnName);
                todb_table7.Columns.Add(column1);
                todb_table7.Columns.Add(column2);
                todb_table7.Columns.Add(columnName);
                todb_table8.Columns.Add(column1);
                todb_table8.Columns.Add(column2);
                todb_table8.Columns.Add(columnName);
                todb_table9.Columns.Add(column1);
                todb_table9.Columns.Add(column2);
                todb_table9.Columns.Add(columnName);
                todb_table10.Columns.Add(column1);
                todb_table10.Columns.Add(column2);
                todb_table10.Columns.Add(columnName);

                todb_table11.Columns.Add(column1);
                todb_table11.Columns.Add(column2);
                todb_table11.Columns.Add(columnSNR);
                todb_table12.Columns.Add(column1);
                todb_table12.Columns.Add(column2);
                todb_table12.Columns.Add(columnSNR);
                todb_table13.Columns.Add(column1);
                todb_table13.Columns.Add(column2);
                todb_table13.Columns.Add(columnSNR);
                todb_table14.Columns.Add(column1);
                todb_table14.Columns.Add(column2);
                todb_table14.Columns.Add(columnSNR);
                todb_table15.Columns.Add(column1);
                todb_table15.Columns.Add(column2);
                todb_table15.Columns.Add(columnSNR);
                todb_table16.Columns.Add(column1);
                todb_table16.Columns.Add(column2);
                todb_table16.Columns.Add(columnSNR);
                todb_table17.Columns.Add(column1);
                todb_table17.Columns.Add(column2);
                todb_table17.Columns.Add(columnSNR);
                todb_table18.Columns.Add(column1);
                todb_table18.Columns.Add(column2);
                todb_table18.Columns.Add(columnSNR);
                todb_table19.Columns.Add(column1);
                todb_table19.Columns.Add(column2);
                todb_table19.Columns.Add(columnSNR);
                todb_table20.Columns.Add(column1);
                todb_table20.Columns.Add(column2);
                todb_table20.Columns.Add(columnSNR);

                todb_table21.Columns.Add(column1);
                todb_table21.Columns.Add(column2);
                todb_table21.Columns.Add(columnSINR);
                todb_table22.Columns.Add(column1);
                todb_table22.Columns.Add(column2);
                todb_table22.Columns.Add(columnSINR);
                todb_table23.Columns.Add(column1);
                todb_table23.Columns.Add(column2);
                todb_table23.Columns.Add(columnSINR);
                todb_table24.Columns.Add(column1);
                todb_table24.Columns.Add(column2);
                todb_table24.Columns.Add(columnSINR);
                todb_table25.Columns.Add(column1);
                todb_table25.Columns.Add(column2);
                todb_table25.Columns.Add(columnSINR);
                todb_table26.Columns.Add(column1);
                todb_table26.Columns.Add(column2);
                todb_table26.Columns.Add(columnSINR);
                todb_table27.Columns.Add(column1);
                todb_table27.Columns.Add(column2);
                todb_table27.Columns.Add(columnSINR);
                todb_table28.Columns.Add(column1);
                todb_table28.Columns.Add(column2);
                todb_table28.Columns.Add(columnSINR);
                todb_table29.Columns.Add(column1);
                todb_table29.Columns.Add(column2);
                todb_table29.Columns.Add(columnSINR);
                todb_table30.Columns.Add(column1);
                todb_table30.Columns.Add(column2);
                todb_table30.Columns.Add(columnSINR);

                DataRow row;


                for (int i = 0; i < kSize; i++)
                {
                    for (int j = 0; j < kSize; j++)
                    {
                        row = todb_table1.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(1);
                        todb_table1.Rows.Add(row);

                        row = todb_table2.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(2);
                        todb_table2.Rows.Add(row);

                        row = todb_table3.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(3);
                        todb_table3.Rows.Add(row);

                        row = todb_table4.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(4);
                        todb_table4.Rows.Add(row);

                        row = todb_table5.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(5);
                        todb_table5.Rows.Add(row);

                        row = todb_table6.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(6);
                        todb_table6.Rows.Add(row);

                        row = todb_table7.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(7);
                        todb_table7.Rows.Add(row);

                        row = todb_table8.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(8);
                        todb_table8.Rows.Add(row);

                        row = todb_table9.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(9);
                        todb_table9.Rows.Add(row);

                        row = todb_table10.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnName] = grid_[i, j].GetName(10);
                        todb_table10.Rows.Add(row);

                        row = todb_table11.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(1);
                        todb_table11.Rows.Add(row);

                        row = todb_table12.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(2);
                        todb_table12.Rows.Add(row);

                        row = todb_table13.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(3);
                        todb_table13.Rows.Add(row);

                        row = todb_table14.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(4);
                        todb_table14.Rows.Add(row);

                        row = todb_table15.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(5);
                        todb_table15.Rows.Add(row);

                        row = todb_table16.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(6);
                        todb_table16.Rows.Add(row);

                        row = todb_table17.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(7);
                        todb_table17.Rows.Add(row);

                        row = todb_table18.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(8);
                        todb_table18.Rows.Add(row);

                        row = todb_table19.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(9);
                        todb_table19.Rows.Add(row);

                        row = todb_table20.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSnr(10);
                        todb_table20.Rows.Add(row);

                        row = todb_table21.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(1);
                        todb_table21.Rows.Add(row);

                        row = todb_table22.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(2);
                        todb_table22.Rows.Add(row);

                        row = todb_table23.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(3);
                        todb_table23.Rows.Add(row);

                        row = todb_table24.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(4);
                        todb_table24.Rows.Add(row);

                        row = todb_table25.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(5);
                        todb_table25.Rows.Add(row);

                        row = todb_table26.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(6);
                        todb_table26.Rows.Add(row);

                        row = todb_table27.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(7);
                        todb_table27.Rows.Add(row);

                        row = todb_table28.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(8);
                        todb_table28.Rows.Add(row);

                        row = todb_table29.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(9);
                        todb_table29.Rows.Add(row);

                        row = todb_table30.NewRow();
                        row[column1] = i;
                        row[column2] = j;
                        row[columnSNR] = grid_[i, j].GetSINR(10);
                        todb_table30.Rows.Add(row);

                    }
                }

                return true;
                Console.WriteLine("tutaj");
            }

            return true;




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
        private int count2 = 0;
       private Cell[,] grid_;
        private Cell[,] grid_temp_= new Cell[kSize, kSize];
       private const int kSize=30;
       private Calculations calculations_;
    }
}
