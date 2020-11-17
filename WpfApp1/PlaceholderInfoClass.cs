using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class PlaceholderInfoClass
    {
        public string nazwa;
        public string x;
        public string y;
        public string moc;
        public string zysk;
        public string nrkanalu;
        public PlaceholderInfoClass(string nazwa, string x, string y, string moc, string zysk, string nrkanalu)
        {
            this.nazwa = nazwa;
            this.x = x;
            this.y = y;
            this.moc = moc;
            this.zysk = zysk;
            this.nrkanalu = nrkanalu;
        }

    }

}