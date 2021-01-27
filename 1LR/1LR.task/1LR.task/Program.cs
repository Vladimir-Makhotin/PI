using System;

namespace _1LR.task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк");
            int r = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов");
            int c = Convert.ToInt32(Console.ReadLine());
            double[,] array = FormArray(r,c);
            OutArray(array, r, c);
            OutModifiedArray(Solution(array, r, c), r, c);
        }
        static double[,] FormArray(int rows, int columns)
        {
            double [,] mas = new double[rows, columns];
            for(int i=0;i<rows;i++)
                for(int j=0;j<columns;j++)
                {
                    if(i==0&j==0)
                    {
                        mas[i, j] = 0;
                    }
                    else
                    {
                        mas[i, j] = i - Math.Log(i + j);
                    }
                    
                }
            return mas;
        }
        static void OutArray(double[,] mas, int rows, int columns)
        {
            Console.WriteLine("Исходный массив");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{Math.Round(mas[i,j],3)} \t");
                }
                Console.WriteLine();
            }
                
        }
        static double[,] Solution(double[,] mas, int rows, int columns)
        {
            int[] arr = new int[columns];
            double max = -1000;
            double t;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(mas[i,j]>max)
                    {
                        max = mas[i, j];
                        arr[i] = j;
                    }
                }
                max = -1000;
            }
                
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    if (i==j)
                    {
                        if(mas[i,j]!=max)
                        {
                            t = mas[i, j];
                            mas[i, j] = mas[i, arr[i]];
                            mas[i, arr[i]] = t;
                        }
                    }
                }
            return mas;

        }
        static void OutModifiedArray(double[,] mas, int rows, int columns)
        {
            Console.WriteLine("Измененный массив");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{Math.Round(mas[i, j], 3)} \t");
                }
                Console.WriteLine();
            }
        }
    }
}
