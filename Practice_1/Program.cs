using System;
using MatrixSort.ComprasionType;
using MatrixSort.SortOrder;
using MatrixSort;

public static class Program
{
    public static void Main(string[] args)
    {
        int[][] matrix =
        {
            new int[] { 1, 2, 3 },
            new int[] { 3, 2, 6 },
            new int[] { 5, 2, 3 },
            new int[] { 10, 2, 3 },
        };


        ISortOrder order = new AscOrder();
        ISortType type = new SumSwap();
        ISorting sort = new BubbleSort();

        ReturnType();
        ReturnOrder();

        Console.Clear();
        sort.Sort(ref matrix, type, order);
        PrintMatrix(matrix);

        Console.ReadLine();

    }

    public static ISortType ReturnType()
    {
        char option = '\n';
        string options = "Выберите тип сортировки строк матрицы:\n" +
                             "1 - По сумме элементов\n" +
                             "2 - По максимальному элементу\n" +
                             "3 - По минимальному элементу\n";

        while (true)
        {
            Console.Clear();
            Console.WriteLine(options);
            option = Console.ReadKey().KeyChar;

            switch (option)
            {
                case '1':
                    return new SumSwap();
                case '2':
                    return new MaxValueSwap();
                case '3':
                    return new MinValueSwap();
            }
        }
    }

    public static ISortOrder ReturnOrder()
    {
        char option = '\n';
        string options = "Выберите порядок сортировки\n" +
                              "1 - По возрастанию\n" +
                              "2 - По убыванию\n";

        while (true)
        {
            Console.Clear();
            Console.WriteLine(options);
            option = Console.ReadKey().KeyChar;

            switch (option)
            {
                case '1':
                    return new AscOrder();
                case '2':
                    return new DescOrder();
            }
        }
    }

    public static void PrintMatrix(int[][] matrix)
    {
        Console.WriteLine("Отсортированная матрица:");
        foreach (var row in matrix)
        {
            foreach (var value in row)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}

