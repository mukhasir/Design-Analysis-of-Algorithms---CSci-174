using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LowerCase
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Other_CodeEval\Lower_Case\input.txt"))
            {
                if (Data != "")
                {
                    Console.WriteLine(Data.ToLower());
                }
            }
        }
    }
}
