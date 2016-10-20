using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Prefix_EXpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> Numbers = null;
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Assignment 6\input.txt"))
            {
                Numbers = new Stack<int>();
                string[] DataSplit = Data.Split(' ');
                for (int i = DataSplit.Length-1; i >= 0 ; i--)
                {
                    int n;
                    if(int.TryParse(DataSplit[i], out n))
                    {
                        Numbers.Push(n);
                    }
                    else
                    {

                    }
                }
                Console.WriteLine(Numbers.Count);
            }
        }
    }
}
