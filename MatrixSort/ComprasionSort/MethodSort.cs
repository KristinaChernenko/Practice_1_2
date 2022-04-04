using MatrixSort.SortOrder;

namespace MatrixSort.ComprasionType
{
    public interface ISortType
    {
        bool NeedSwap(int[] x, int[] y, ISortOrder sortOrder);
    }

    public abstract class RowSwap : ISortType
    {
        protected bool NeedSwap(int x, int y, ISortOrder sortOrder)
        {
            return sortOrder.Compare(x, y) == 1;
        }

        public abstract bool NeedSwap(int[] x, int[] y, ISortOrder sortOrder);
    }

    public class MaxValueSwap : RowSwap
    {
        public sealed override bool NeedSwap(int[] x, int[] y, ISortOrder sortOrder)
        {
            return NeedSwap(x.Max(), y.Max(), sortOrder);
        }
    }

    public class MinValueSwap : RowSwap
    {
        public sealed override bool NeedSwap(int[] x, int[] y, ISortOrder sortOrder)
        {
            return NeedSwap(x.Min(), y.Min(), sortOrder);
        }
    }

    public class SumSwap : RowSwap
    {
        public sealed override bool NeedSwap(int[] x, int[] y, ISortOrder sortOrder)
        {
            return NeedSwap(x.Sum(), y.Sum(), sortOrder);
        }
    }
}
