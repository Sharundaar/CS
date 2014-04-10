using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG44
{
    class EdgeComparer : IComparer<Edge>
    {
        int IComparer<Edge>.Compare(Edge x, Edge y)
        {
            if (x == null || y == null)
                return 0;

            if (x.Time < y.Time)
                return -1;
            if (x.Time > y.Time)
                return 1;
            return 0;
        }
    }
}
