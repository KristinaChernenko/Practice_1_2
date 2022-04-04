using MatrixSort.ComprasionType;
using MatrixSort.SortOrder;

namespace MatrixSort
{
    public interface ISorting
    {
        void Sort(ref int[][] x, ISortType swapper, ISortOrder orderer);
    }

    public class BubbleSort : ISorting
    {
        protected void Swap(ref int x, ref int y)
        {
            (x, y) = (y, x);
        }

        protected void Swap(ref int[] x, ref int[] y)
        {
            int len = Math.Min(x.Length, y.Length);

            for (int i = 0; i < len; ++i)
            {
                Swap(ref x[i], ref y[i]);
            }
        }

        public void Sort(ref int[][] x, ISortType swapper, ISortOrder orderer)
        {
            for (int i = 0; i < x.Length - 1; ++i)
            {
                for (int j = i + 1; j < x.Length; ++j)
                {
                    if (swapper.NeedSwap(x[i], x[j], orderer))
                    {
                        Swap(ref x[i], ref x[j]);
                    }
                }
            }
        }
    }
}