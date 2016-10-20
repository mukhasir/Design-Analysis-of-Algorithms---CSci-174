using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Assignment 8\Input.txt"))
            {
                string[] DataValues = Data.Split(';');
                string str1 = DataValues[0];
                string str2 = DataValues[1];
                int[,] arr = new int[str1.Length + 1, str2.Length + 1];
                for (int i = str1.Length - 1; i >= 0; i--)
                {
                    for (int j = str2.Length - 1; j >= 0; j--)
                    {
                        if (str1[i] == str2[j])
                            arr[i , j] = arr[i + 1 , j + 1] + 1;
                        else
                            arr[i,j] = Math.Max(arr[i + 1 , j], arr[i , j + 1]);
                    }
                }

                int k = 0, l = 0;
                StringBuilder sb = new StringBuilder();
                while (k < str1.Length && l < str2.Length)
                {
                    if (str1[k] == str2[l])
                    {
                        sb.Append(str1[k]);
                        k++;
                        l++;
                    }
                    else if (arr[k + 1,l] >= arr[k,l + 1])
                        k++;
                    else
                        l++;
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
