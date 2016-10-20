using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Spiral_Printing
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Final Project\Spiral_Printing\input_text.txt"))
            {
                string[] DataValues = Data.Split(';');
                int rows = Convert.ToInt16(DataValues[0]);
                int columns = Convert.ToInt16(DataValues[1]);
                string[] Numbers = DataValues[2].Split(' ');
                string[][] Matrix = new string[rows][];
                int counter = 0;
                for(int i=0;i<rows;i++)
                {
                    Matrix[i] = new string[columns];
                    for(int j=0;j<columns;j++)
                    {
                        Matrix[i][j] = Numbers[counter];
                        counter++;
                    }
                }
                int Start_RowIndex = 0, End_RowIndex = rows, Start_ColumnIndex = 0 , End_ColumnIndex = columns;
                int z;
                string FinalResult = string.Empty;
                while(Start_RowIndex < End_RowIndex && Start_ColumnIndex < End_ColumnIndex)
                {
                    /* Display the first row from the remaining rows */
                    for (z = Start_ColumnIndex; z < End_ColumnIndex; z++)
                    {
                        FinalResult += Matrix[Start_RowIndex][z] + " ";
                    }
                    Start_RowIndex++;

                    /* Display the last column from the remaining columns */
                    for (z = Start_RowIndex; z < End_RowIndex; z++)
                    {
                        FinalResult += Matrix[z][End_ColumnIndex - 1] + " ";
                    }
                    End_ColumnIndex--;
                    /* Display the last row from the remaining rows */
                    if (Start_RowIndex < End_RowIndex)
                    {
                        for (z = End_ColumnIndex - 1; z >= Start_ColumnIndex; z--)
                        {
                            FinalResult += Matrix[End_RowIndex - 1][z] + " ";
                        }
                        End_RowIndex--;
                    }

                    /* Display the first column from the remaining columns */
                    if (Start_ColumnIndex < End_ColumnIndex)
                    {
                        for (z = End_RowIndex - 1; z >= Start_RowIndex; z--)
                        {
                            FinalResult += Matrix[z][Start_ColumnIndex] + " ";
                        }
                        Start_ColumnIndex++;
                    } 
                }
                Console.WriteLine(FinalResult.TrimEnd());
            }
        }
    }
}

