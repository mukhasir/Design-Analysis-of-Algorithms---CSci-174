using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> numbers = new Dictionary<string,int>();
            foreach(string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Other_CodeEval\input.txt"))
            {
                if (Data != "")
                {
                    string[] DataValue = Data.Split(' ');
                    string DataSpace = Data.Replace(" ","");
                    for (int i = 1; i < DataValue.Length;i++)
                    {
                        if (numbers.ContainsKey(DataValue[i]))
                        {
                            numbers[DataValue[i]] += 1;
                        }
                        else
                        {
                            numbers.Add(DataValue[i], 1);
                        }
                    }
                    var items = (from n in numbers
                                            orderby n.Value,n.Key
                                            where n.Value == 1
                                            select n);
                    int Count = items.Count();
                    int Val=0;
                    if (Count>1)
                    {
                        foreach(KeyValuePair<string,int> Values in items)
                        {
                            Val = DataSpace.IndexOf(Values.Key) +1;
                            break;
                        }
                    }
                    Console.WriteLine(Val);
                    numbers.Clear();
                }
            }
        }
    }
}
