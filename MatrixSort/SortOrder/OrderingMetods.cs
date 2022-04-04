using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSort.SortOrder
{
    public interface ISortOrder
    {
        int Compare(int x, int y);
    }

    public class AscOrder : ISortOrder
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    public class DescOrder : ISortOrder
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}
