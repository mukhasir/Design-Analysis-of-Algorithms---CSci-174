using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Sudoku_Extra_Credit\input_test.txt"))
            {
                if (Data != "")
                {
                    string[] DataValues = Data.Split(';');
                    int width = int.Parse(DataValues[0].ToString());
                    string[] Numbers = DataValues[1].Trim().Split(',');
                    int counter = 0;
                    int[][] Number_Array = new int[width][];
                    for (int i = 0; i < width; i++)
                    {
                        Number_Array[i] = new int[width];
                        for (int j = 0; j < width; j++)
                        {
                            Number_Array[i][j] = int.Parse(Numbers[counter].ToString());
                            counter++;
                        }
                    }
                    int desired_sum = (width * (width + 1)) / 2;
                    if (isValidSolution(Number_Array, desired_sum, width))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
            }
        }
        public static bool isValidSolution(int[][] Number_Array, int desired_sum, int sudokuSize)
        {
            return RowsValid(sudokuSize, Number_Array) && ColumnsValid(sudokuSize, Number_Array) && GridsValid(sudokuSize, Number_Array);
        }
        public static bool RowsValid(int sudokuSize,int[][] Number_Array)
        {
            for (int i = 0; i < Number_Array.Length; i++)
            {

                bool[] numbers = new bool[sudokuSize];
                for (int j = 0; j < Number_Array.Length; j++)
                {
                    if (numbers[Number_Array[i][j] - 1])
                    {
                        return false;
                    }
                    else
                    {
                        numbers[Number_Array[i][j] - 1] = true;
                    }
                }

            }
            return true;
        }
        public static bool ColumnsValid(int sudokuSize, int[][] Number_Array)
        {
            for (int i = 0; i < Number_Array.Length; i++)
            {

                bool[] numbers = new bool[sudokuSize];
                for (int j = 0; j < Number_Array.Length; j++)
                {
                    if (numbers[Number_Array[j][i] - 1])
                    {
                        return false;
                    }
                    else
                    {
                        numbers[Number_Array[j][i] - 1] = true;
                    }
                }

            }
            return true;
        }
        public static bool GridsValid(int sudokuSize, int[][] Number_Array)
        {
            int gridCount = (int)Math.Sqrt(sudokuSize);

            for (int i = 0; i < gridCount; i++)
            {
                for (int j = 0; j < gridCount; j++)
                {
                    if (!isGridValid(sudokuSize, Number_Array, i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool isGridValid(int sudokuSize, int[][] Number_Array,int gridRow, int gridColumn)
        {
            int gridSize = (int)Math.Sqrt(sudokuSize);

            bool[] numbers = new bool[sudokuSize];
            for (int i = gridSize * gridRow; i < (gridSize * gridRow) + gridSize; i++)
            {
                for (int j = gridSize * gridColumn; j < (gridSize * gridColumn) + gridSize; j++)
                {
                    if (numbers[Number_Array[i][j] - 1])
                    {
                        return false;
                    }
                    else
                    {
                        numbers[Number_Array[i][j] - 1] = true;
                    }
                }
            }
            return true;
        }
    }
}
