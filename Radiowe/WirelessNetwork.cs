using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Radiowe
{
    public class WirelessNetwork
    {
        public WirelessNetwork()
        {
            calculations_ = new Calculations();
            grid_ = new Grid();
        }
        public void AddStationToSystem(BaseStation base_station)
        {
            if (base_station_system_.Count == 0)
            {
                base_station_system_.Add(base_station);
                //grid_.AddFirstBaseStation(base_station);
                grid_db = grid_.AddFirstBaseStation(base_station);
            }
            else
            {
                int counter = 0;
                foreach (var list_station in base_station_system_)
                {
                    Console.WriteLine("POROWNUJE STACJE ");
                    if (grid_.AddMoreBaseStation(list_station, base_station, base_station_system_.Count) == true)
                    {
                        counter++;
                    }
                    else break;
                }
                if (counter == base_station_system_.Count)
                {
                    Console.WriteLine("ROWNA SIE SOBIE");
                    base_station_system_.Add(base_station);
                    grid_db = grid_.ReturnGrid();

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
                    todb_table1.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table1.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table1.Columns.Add("Name", typeof(string));
                    todb_table2.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table2.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table2.Columns.Add("Name", typeof(string));
                    todb_table3.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table3.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table3.Columns.Add("Name", typeof(string));
                    todb_table4.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table4.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table4.Columns.Add("Name", typeof(string));
                    todb_table5.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table5.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table5.Columns.Add("Name", typeof(string));
                    todb_table6.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table6.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table6.Columns.Add("Name", typeof(string));
                    todb_table7.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table7.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table7.Columns.Add("Name", typeof(string));
                    todb_table8.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table8.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table8.Columns.Add("Name", typeof(string));
                    todb_table9.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table9.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table9.Columns.Add("Name", typeof(string));
                    todb_table10.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table10.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table10.Columns.Add("Name", typeof(string));
                    todb_table11.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table11.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table11.Columns.Add("SNR", typeof(double));
                    todb_table12.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table12.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table12.Columns.Add("SNR", typeof(double));
                    todb_table13.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table13.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table13.Columns.Add("SNR", typeof(double));
                    todb_table14.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table14.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table14.Columns.Add("SNR", typeof(double));
                    todb_table15.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table15.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table15.Columns.Add("SNR", typeof(double));
                    todb_table16.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table16.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table16.Columns.Add("SNR", typeof(double));
                    todb_table17.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table17.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table17.Columns.Add("SNR", typeof(double));
                    todb_table18.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table18.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table18.Columns.Add("SNR", typeof(double));
                    todb_table19.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table19.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table19.Columns.Add("SNR", typeof(double));
                    todb_table20.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table20.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table20.Columns.Add("SNR", typeof(double));
                    todb_table21.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table21.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table21.Columns.Add("SINR", typeof(double));
                    todb_table22.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table22.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table22.Columns.Add("SINR", typeof(double));
                    todb_table23.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table23.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table23.Columns.Add("SINR", typeof(double));
                    todb_table24.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table24.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table24.Columns.Add("SINR", typeof(double));
                    todb_table25.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table25.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table25.Columns.Add("SINR", typeof(double));
                    todb_table26.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table26.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table26.Columns.Add("SINR", typeof(double));
                    todb_table27.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table27.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table27.Columns.Add("SINR", typeof(double));
                    todb_table28.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table28.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table28.Columns.Add("SINR", typeof(double));
                    todb_table29.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table29.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table29.Columns.Add("SINR", typeof(double));
                    todb_table30.Columns.Add("lokalizacjaX", typeof(int));
                    todb_table30.Columns.Add("lokalizacjaY", typeof(int));
                    todb_table30.Columns.Add("SINR", typeof(double));
                    DataRow row;

                    for (int i = 0; i < kSize; i++)
                    {
                        for (int j = 0; j < kSize; j++)
                        {
                            row = todb_table1.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(1);
                            todb_table1.Rows.Add(row);
                            if (grid_db[i, j].GetName(1) != "default")
                                DataBase.addName("Name1", (i + 1).ToString(), grid_db[i, j].GetName(1), j + 1);

                            row = todb_table2.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(2);
                            todb_table2.Rows.Add(row);
                            if (grid_db[i, j].GetName(2) != "default")
                                DataBase.addName("Name2", (i + 1).ToString(), grid_db[i, j].GetName(2), j + 1);

                            row = todb_table3.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(3);
                            todb_table3.Rows.Add(row);
                            if (grid_db[i, j].GetName(3) != "default")
                                DataBase.addName("Name3", (i + 1).ToString(), grid_db[i, j].GetName(3), j + 1);

                            row = todb_table4.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(4);
                            todb_table4.Rows.Add(row);
                            if (grid_db[i, j].GetName(4) != "default")
                                DataBase.addName("Name4", (i + 1).ToString(), grid_db[i, j].GetName(4), j + 1);

                            row = todb_table5.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(5);
                            todb_table5.Rows.Add(row);
                            if (grid_db[i, j].GetName(5) != "default")
                                DataBase.addName("Name5", (i + 1).ToString(), grid_db[i, j].GetName(5), j + 1);

                            row = todb_table6.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(6);
                            todb_table6.Rows.Add(row);
                            if (grid_db[i, j].GetName(6) != "default")
                                DataBase.addName("Name6", (i + 1).ToString(), grid_db[i, j].GetName(6), j + 1);

                            row = todb_table7.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(7);
                            todb_table7.Rows.Add(row);
                            if (grid_db[i, j].GetName(7) != "default")
                                DataBase.addName("Name7", (i + 1).ToString(), grid_db[i, j].GetName(7), j + 1);

                            row = todb_table8.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(8);
                            todb_table8.Rows.Add(row);
                            if (grid_db[i, j].GetName(8) != "default")
                                DataBase.addName("Name8", (i + 1).ToString(), grid_db[i, j].GetName(8), j + 1);

                            row = todb_table9.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(9);
                            todb_table9.Rows.Add(row);
                            if (grid_db[i, j].GetName(9) != "default")
                                DataBase.addName("Name9", (i + 1).ToString(), grid_db[i, j].GetName(9), j + 1);

                            row = todb_table10.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["Name"] = grid_db[i, j].GetName(10);
                            todb_table10.Rows.Add(row);
                            if (grid_db[i, j].GetName(10) != "default")
                                DataBase.addName("Name10", (i + 1).ToString(), grid_db[i, j].GetName(10), j + 1);

                            row = todb_table11.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(1);
                            todb_table11.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(1) != 0)
                                DataBase.addName("Snr1", (i + 1).ToString(), grid_db[i, j].GetSnr(1).ToString().Replace('.', ','), j + 1);

                            row = todb_table12.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(2);
                            todb_table12.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(2) != 0)
                                DataBase.addName("Snr2", (i + 1).ToString(), grid_db[i, j].GetSnr(2).ToString().Replace('.', ','), j + 1);

                            row = todb_table13.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(3);
                            todb_table13.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(3) != 0)
                                DataBase.addName("Snr3", (i + 1).ToString(), grid_db[i, j].GetSnr(3).ToString().Replace('.', ','), j + 1);

                            row = todb_table14.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(4);
                            todb_table14.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(4) != 0)
                                DataBase.addName("Snr4", (i + 1).ToString(), grid_db[i, j].GetSnr(4).ToString().Replace('.', ','), j + 1);

                            row = todb_table15.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(5);
                            todb_table15.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(5) != 0)
                                DataBase.addName("Snr5", (i + 1).ToString(), grid_db[i, j].GetSnr(5).ToString().Replace('.', ','), j + 1);

                            row = todb_table16.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(6);
                            todb_table16.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(6) != 0)
                                DataBase.addName("Snr6", (i + 1).ToString(), grid_db[i, j].GetSnr(6).ToString().Replace('.', ','), j + 1);

                            row = todb_table17.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(7);
                            todb_table17.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(7) != 0)
                                DataBase.addName("Snr7", (i + 1).ToString(), grid_db[i, j].GetSnr(7).ToString().Replace('.', ','), j + 1);

                            row = todb_table18.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(8);
                            todb_table18.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(8) != 0)
                                DataBase.addName("Snr8", (i + 1).ToString(), grid_db[i, j].GetSnr(8).ToString().Replace('.', ','), j + 1);

                            row = todb_table19.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(9);
                            todb_table19.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(9) != 0)
                                DataBase.addName("Snr9", (i + 1).ToString(), grid_db[i, j].GetSnr(9).ToString().Replace('.', ','), j + 1);

                            row = todb_table20.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SNR"] = grid_db[i, j].GetSnr(10);
                            todb_table20.Rows.Add(row);
                            if (grid_db[i, j].GetSnr(10) != 0)
                                DataBase.addName("Snr10", (i + 1).ToString(), grid_db[i, j].GetSnr(10).ToString().Replace('.', ','), j + 1);

                            row = todb_table21.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(1);
                            todb_table21.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(1) != 0)
                                DataBase.addName("Sinr1", (i + 1).ToString(), grid_db[i, j].GetSINR(1).ToString().Replace('.', ','), j + 1);

                            row = todb_table22.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(2);
                            todb_table22.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(2) != 0)
                                DataBase.addName("Sinr2", (i + 1).ToString(), grid_db[i, j].GetSINR(2).ToString().Replace('.', ','), j + 1);

                            row = todb_table23.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(3);
                            todb_table23.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(3) != 0)
                                DataBase.addName("Sinr3", (i + 1).ToString(), grid_db[i, j].GetSINR(3).ToString().Replace('.', ','), j + 1);

                            row = todb_table24.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(4);
                            todb_table24.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(4) != 0)
                                DataBase.addName("Sinr4", (i + 1).ToString(), grid_db[i, j].GetSINR(4).ToString().Replace('.', ','), j + 1);

                            row = todb_table25.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(5);
                            todb_table25.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(5) != 0)
                                DataBase.addName("Sinr5", (i + 1).ToString(), grid_db[i, j].GetSINR(5).ToString().Replace('.', ','), j + 1);

                            row = todb_table26.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(6);
                            todb_table26.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(6) != 0)
                                DataBase.addName("Sinr6", (i + 1).ToString(), grid_db[i, j].GetSINR(6).ToString().Replace('.', ','), j + 1);

                            row = todb_table27.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(7);
                            todb_table27.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(7) != 0)
                                DataBase.addName("Sinr7", (i + 1).ToString(), grid_db[i, j].GetSINR(7).ToString().Replace('.', ','), j + 1);

                            row = todb_table28.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(8);
                            todb_table28.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(8) != 0)
                                DataBase.addName("Sinr8", (i + 1).ToString(), grid_db[i, j].GetSINR(8).ToString().Replace('.', ','), j + 1);

                            row = todb_table29.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(9);
                            todb_table29.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(9) != 0)
                                DataBase.addName("Sinr9", (i + 1).ToString(), grid_db[i, j].GetSINR(9).ToString().Replace('.', ','), j + 1);

                            row = todb_table30.NewRow();
                            row["lokalizacjaX"] = i;
                            row["lokalizacjaY"] = j;
                            row["SINR"] = grid_db[i, j].GetSINR(10);
                            todb_table30.Rows.Add(row);
                            if (grid_db[i, j].GetSINR(10) != 0)
                                DataBase.addName("Sinr10", (i + 1).ToString(), grid_db[i, j].GetSINR(10).ToString().Replace('.', ','), j + 1);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("NIE DODA SIE");
                }
            }
        }
        public void AddNewBaseStation(BaseStation base_station) //tylko raz dla pierwszej -- w przyszlości można usunąć
        {
            base_station_system_.Add(base_station);
            grid_.AddFirstBaseStation(base_station);
        }

        public void Add2(BaseStation baseStation1) // sprawdzanie stara do nowej -- w przyszłości można usunąc
        {
            foreach (var list_station in base_station_system_)
            {
                //grid_.AddMoreBaseStation(list_station, baseStation1);
            }
        }
        public void test()
        {
            grid_.Print(0);
        }
        public void CalculateSNR() //testowe -- można usunąć w przyszłości
        {
            double temp1 = calculations_.CalculateFSPL(2.4, 1);
            double temp2 = calculations_.CalculateReceiverPower(20, 0, 0);
            double temp3 = calculations_.CalculateNoise(10000000);
            double SNR = temp2 - temp3;
            Console.WriteLine("FSPL: " + temp1);
            Console.WriteLine("PRX: " + temp2);
            Console.WriteLine("noise" + temp3);
            Console.WriteLine(SNR);
        }

        private List<BaseStation> base_station_system_ = new List<BaseStation>(); // przy uruchomieniu wgrywanie stacji bazowych
        private Calculations calculations_;
        private Grid grid_;
        public Cell[,] grid_db;
        public int kSize = 200;

    }
}
