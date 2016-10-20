using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Generic_Common
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Other_CodeEval\Genric_Common\input.txt"))
            {
                char[] a = Data.ToCharArray();
                int sum = 0;
                for(int i=0;i<a.Length;i++)
                {
                    sum += int.Parse(a[i].ToString());
                }
                Console.WriteLine(sum);
            }
        }
    }
}
