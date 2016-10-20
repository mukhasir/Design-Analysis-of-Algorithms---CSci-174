using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MaxValue
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string LineData in File.ReadLines(@"E:\Fall 2015\Design Analysis of Algorithms\Assignment 4\input.txt"))
            {
                if (LineData != "")
                {
                    string[] Data = LineData.Split(';');
                    string[] Values = Data[1].Split(' ');
                    int j = 0;
                    int n = Convert.ToInt32(Data[0]);
                    int FinalValue = 0;
                    int maxValue = 0;
                    while (j <= (Values.Length - Convert.ToInt32(Data[0])))
                    {
                        FinalValue = 0;
                        for (int i = j; i < n; i++)
                        {
                            FinalValue += Convert.ToInt32(Values[i]);
                        }
                        if (FinalValue > maxValue)
                        {
                            maxValue = FinalValue;
                        }
                        j++;
                        n++;
                    }
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}
