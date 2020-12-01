using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Controller
    {
        public Controller() { }
        public void GetRecord(PlaceholderInfoClass record) 
        {
            record_ = record;
        }
        public PlaceholderInfoClass RetRecord()
        {
            return record_;
        }

        public void Refresh()
        {
            if (refreshTime_ < 10000000/*last_db_update*/ && refresh_ == false)
            {
                //pull data
                //refreshTime_ = ;
                refresh_ = true;
            }
            Task.Delay(1000).ContinueWith(t => RefFalse());
            return;
        }
        public void RefFalse() { refresh_ = false; return; }
        // variables
        private PlaceholderInfoClass record_ = null;
        private bool refresh_ = false;
        private double refreshTime_ = 0;
    }
}
