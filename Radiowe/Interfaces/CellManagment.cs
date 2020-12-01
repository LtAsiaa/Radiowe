using System;
using System.Collections.Generic;
using System.Text;

namespace Radiowe.Interfaces
{
    interface ICellManagment
    {
        void AddUser(User user);
        void AddStation(BaseStation station);
        void DeleteUser();
        void DeleteStation();
        void AddToList(double SNR, BaseStation station);
    }
}
