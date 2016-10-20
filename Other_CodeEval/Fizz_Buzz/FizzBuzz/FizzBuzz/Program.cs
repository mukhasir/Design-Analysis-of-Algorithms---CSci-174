using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Other_CodeEval\Fizz_Buzz\input.txt"))
            {
                if (Data != "")
                {
                    string[] DataSplit = Data.Split(' ');
                    int op1 = int.Parse(DataSplit[0]);
                    int op2 = int.Parse(DataSplit[1]);
                    string Final = string.Empty;
                    for (int i = 1; i <= int.Parse(DataSplit[2]); i++)
                    {
                        if (i % op1 == 0 && i % op2 == 0)
                        {
                            Final += "FB ";
                        }
                        else if (i % op1 == 0)
                        {
                            Final += "F ";
                        }
                        else if (i % op2 == 0)
                        {
                            Final += "B ";
                        }
                        else
                        {
                            Final += i.ToString() + " ";
                        }
                    }
                    Console.WriteLine(Final.TrimEnd());
                }
            }
        }
    }
}
