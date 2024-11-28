using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Tumakov
{
    internal class Program
    {

        static void Task1(params char[] s)
        {
            uint vowelsNum = 0;
            uint consNum = 0;

            foreach (char c in s)
            {
                if ("EYUIOAЁУЕЫАОЭЯИЮ".Contains(c))
                {
                    vowelsNum++;
                }
                else if ("QWRTPSDFGHJKLZXCVBNMЙЦКНГШЩЗХФВПРЛДЖЧСМТБ".Contains(c))
                {
                    consNum++;
                }
            }
            Console.WriteLine($"Количество гласных: {vowelsNum}, количество согласных: {consNum}");
        }
        static void Task1(List<char> s)
        {
            uint vowelsNum = 0;
            uint consNum = 0;

            foreach (char c in s)
            {
                if ("EYUIOAЁУЕЫАОЭЯИЮ".Contains(c))
                {
                    vowelsNum++;
                }
                else if ("QWRTPSDFGHJKLZXCVBNMЙЦКНГШЩЗХФВПРЛДЖЧСМТБ".Contains(c))
                {
                    consNum++;
                }
            }
            Console.WriteLine($"Количество гласных: {vowelsNum}, количество согласных: {consNum}");
        }
        static void Task2()
        {
            int[,] matrix1 = { { 1, 2, 3 }, { 3, 2, 1 }, { 2, 2, 2 } };
            int[,] matrix2 = { { 0, 2, 5 }, { 1, 4, 0 }, { 2, 1, 4 } };
            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrix1);
            Console.WriteLine();
            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrix2);
            Console.WriteLine();
            Console.WriteLine("Матрица полученная при перемножении двух этих матриц:");
            MatrixMultiplying(matrix1 , matrix2);
        }
        static void Task3()
        {
            Random rand = new Random();
            double[,] temperatures = new double[12, 30];
            for (int i = 0;i < temperatures.GetLength(0); i++)
            {
                for (int j = 0;j < temperatures.GetLength(1); j++)
                {
                    temperatures[i,j] = (rand.NextDouble()-0.5)*100;
                }
            }
            double[] averageTemp = new double[12];
            for (int i = 0; i < temperatures.GetLength(0); i++)
            {
                for (int j = 0; j < temperatures.GetLength(1);j++)
                {
                    averageTemp[i] += temperatures[i, j];
                }
                averageTemp[i] /= temperatures.GetLength(1);
            }
            Console.WriteLine();
            Console.WriteLine("Средняя температура в каждом месяце:");
            for (int i = 0; i < averageTemp.Length; i++)
            {
                Console.WriteLine($"{averageTemp[i]} ");
            }
        }
        static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void MatrixMultiplying(int[,] m1, int[,] m2)
        {

            int l11 = m1.GetLength(0);
            int l12 = m1.GetLength(1);

            int l21 = m2.GetLength(0);
            int l22 = m2.GetLength(1);

            if (l12 != l21) 
            {
                Console.WriteLine("Данные матрицы несовместимы для перемножения");
            }
            int[,] m = new int[l11, l22];
            for(int i = 0; i < l11; i++)
            {
                for (int j = 0;j < l22; j++)
                {
                    for (int k = 0; k < l12; k++)
                    {
                        m[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            PrintMatrix(m);
        }
        static void DZTask2()
        {
            var matrix1 = new LinkedList<LinkedList<int>>();
            matrix1.AddLast(CreateRow(1, 2, 3));
            matrix1.AddLast(CreateRow(3, 2, 1));
            matrix1.AddLast(CreateRow(2, 2, 2));

            var matrix2 = new LinkedList<LinkedList<int>>();
            matrix2.AddLast(CreateRow(0, 2, 5));
            matrix2.AddLast(CreateRow(1, 4, 0));
            matrix2.AddLast(CreateRow(2, 1, 4));

            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrix1);
            Console.WriteLine();

            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrix2);
            Console.WriteLine();

            Console.WriteLine("Матрица полученная при перемножении двух этих матриц:");
            MatrixMultiplying(matrix1, matrix2);
        }

        static LinkedList<int> CreateRow(params int[] values)
        {
            var row = new LinkedList<int>();
            foreach (var value in values)
            {
                row.AddLast(value);
            }
            return row;
        }

        static void MatrixMultiplying(LinkedList<LinkedList<int>> m1, LinkedList<LinkedList<int>> m2)
        {
            int rowsM1 = m1.Count;
            int colsM1 = m1.First.Value.Count;
            int rowsM2 = m2.Count;
            int colsM2 = m2.First.Value.Count;

            if (colsM1 != rowsM2)
            {
                Console.WriteLine("Данные матрицы несовместимы для перемножения");
                return;
            }

            var result = new LinkedList<LinkedList<int>>();

            foreach (var row in m1)
            {
                var newRow = new LinkedList<int>();
                for (int j = 0; j < colsM2; j++)
                {
                    int sum = 0;
                    var m2Column = GetColumn(m2, j);
                    int index = 0;
                    foreach (var item in row)
                    {
                        sum += item * m2Column.ElementAt(index);
                        index++;
                    }
                    newRow.AddLast(sum);
                }
                result.AddLast(newRow);
            }
            PrintMatrix(result);
        }

        static LinkedList<int> GetColumn(LinkedList<LinkedList<int>> matrix, int columnIndex)
        {
            var column = new LinkedList<int>();
            foreach (var row in matrix)
            {
                if (columnIndex < row.Count)
                {
                    column.AddLast(row.ElementAt(columnIndex));
                }
            }
            return column;
        }

        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        static void Main(string[] args)
        {
            //Упражнение 6.1
            Console.WriteLine("Упражнение 6.1");

            if (args.Length == 0) 
            {
                Console.WriteLine("Введите адрес файла");
                //return;
            }
            try
            {
                StreamReader sr = new StreamReader(args[0]);
                string s = sr.ReadToEnd();
                Console.WriteLine(s);
                Task1(s.ToCharArray());
            }
            catch 
            {
                Console.WriteLine("Ошибка при чтении файла, попробуйте ещё раз");
                //return;
            }

            //Упражнение 6.2
            Console.WriteLine("Упражнение 6.2");
            Task2();
            //Упражнение 6.3
            Console.WriteLine("Упражнение 6.3");
            Task3();

            // Домашняя работа 6.1
            Console.WriteLine("Домашняя работа 6.1");

            if (args.Length == 0)
            {
                Console.WriteLine("Введите адрес файла");
                //return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    string s = sr.ReadToEnd();
                    Console.WriteLine(s);

                    List<char> charList = new List<char>(s.ToCharArray());
                    Task1(charList);
                }
            }
            catch 
            {
                Console.WriteLine("Ошибка при чтении файла, попробуйте ещё раз");
                //return;
            }

            //Домашняя работа 6.2
            Console.WriteLine("Домашняя работа 6.2");
            DZTask2();
            

        }
    }
}
