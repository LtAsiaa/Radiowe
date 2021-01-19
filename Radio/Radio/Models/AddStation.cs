using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radio.Models
{
    public class AddStation
    {
        public string nazwa { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public double moc { get; set; }
        public double zysk { get; set; }
        public int nrkanalu { get; set; }
        /*public AddStation(string nazwa, int x, int y, double moc, double zysk, int nrkanalu)
        {
            this.nazwa = nazwa;
            this.x = x;
            this.y = y;
            this.moc = moc;
            this.zysk = zysk;
            this.nrkanalu = nrkanalu;
        }*/
    }
}
