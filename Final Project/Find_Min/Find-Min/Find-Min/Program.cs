using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Find_Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, k, a, b, c, r, m;
            int result;
            List<int> num_array = null;
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Final Project\Find_Min\input.txt"))
            {
                num_array  = new List<int>();
                string[] DataValues = Data.Split(',');
                n = int.Parse(DataValues[0].ToString());
                k = int.Parse(DataValues[1].ToString());
                a = int.Parse(DataValues[2].ToString());
                b = int.Parse(DataValues[3].ToString());
                c = int.Parse(DataValues[4].ToString());
                r = int.Parse(DataValues[5].ToString());
                num_array.Add(a);
                for(int i=1;i<k;i++)
                {
                    num_array.Add((b * num_array[i - 1] + c) % r);
                }
                for (int i = k; i < n; i++)
                {
                    result = 0;
                    while(true)
                    {
                        List<int> subList = num_array.GetRange(num_array.Count - k, num_array.Count);
                        if(subList.Contains(result))
                        {
                            result++;
                        }
                        else
                        {
                            break;
                        }
                        num_array.Add(result);
                    }
                }
                Console.WriteLine(num_array[num_array.Count-1]);
            }
        }
    }
}
