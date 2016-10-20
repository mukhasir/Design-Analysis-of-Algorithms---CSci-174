using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Reverse_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Other_CodeEval\Reverse_Words\input.txt"))
            {
                if (Data != "")
                {
                    string[] WordSplit = Data.Split(' ');
                    string FinalWord = string.Empty;
                    for(int i = WordSplit.Length-1;i>=0;i--)
                    {
                        FinalWord += WordSplit[i] + " ";
                    }
                    Console.WriteLine(FinalWord.TrimEnd());
                }
            }
        }
    }
}
