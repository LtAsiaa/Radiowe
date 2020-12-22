using System;
using System.Collections.Generic;
using System.Text;

namespace Radiowe.Interfaces
{
    interface IPrint
    {
        void Print(int type);
        Cell ReturnCell(int i, int j);
    }
}
