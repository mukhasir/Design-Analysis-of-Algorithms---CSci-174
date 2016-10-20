using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> charcount = new Dictionary<string, int>();
            foreach (string LineData in File.ReadLines(@"E:\Fall 2015\Design Analysis of Algorithms\Assignment 1\BeautifulStrings\TestData.txt"))//args[0]
            {
                if (LineData != "")
                {
                    foreach (char c in LineData.ToLower())
                    {
                        if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                        {
                            if (charcount.ContainsKey(c.ToString()))
                            {
                                charcount[c.ToString()] = charcount[c.ToString()] + 1;
                            }
                            else
                            {
                                charcount.Add(c.ToString(), 1);
                            }
                        }
                    }
                    int startvalue = 26;
                    int finalvalue = 0;
                    foreach (var item in charcount.OrderByDescending(i => i.Value))
                    {
                        finalvalue += startvalue * item.Value;
                        startvalue--;
                    }
                    charcount.Clear();
                    Console.WriteLine(finalvalue.ToString());
                }
            }
        }
    }
}
