using System;
using System.Collections.Generic;
using System.Text;

namespace Radiowe.Interfaces
{
    interface ICellManagment
    {
        void AddStation(BaseStation station);
        void DeleteStation();
        void AddToList(double SNR, BaseStation station);
    }
}
