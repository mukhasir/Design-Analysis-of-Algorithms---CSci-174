using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataRecovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> Values = new Dictionary<int, string>();
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Other_CodeEval\Data_Recovery\input.txt"))
            {
                if (Data != "")
                {
                    string[] DataValues = Data.Split(';');
                    string[] Words = DataValues[0].Split(' ');
                    string[] number = DataValues[1].Split(' ');
                    int val = 0;
                    for (int i = 0; i < (Words.Length - 1); i++)
                    {
                        Values.Add(int.Parse(number[i].ToString()), Words[i]);
                    }
                    for (int j = 1; j < Words.Length;j++)
                    {
                        if (!number.Contains(j.ToString()))
                        {
                            val = j;
                        }
                        else
                        {
                            if (val == 0)
                            {
                                val = Words.Length;
                            }
                        }
                    }
                    Values.Add(val, Words[Words.Length - 1]);
                    var items = from pair in Values
                                orderby pair.Key
                                select pair;
                    string FinalValue = string.Empty;
                    foreach (KeyValuePair<int, string> ValueFinal in items)
                    {
                        FinalValue += ValueFinal.Value + " ";
                    }
                    Console.WriteLine(FinalValue.TrimEnd());
                    Values.Clear();
                }
            }
        }
    }
}
