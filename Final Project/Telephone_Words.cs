using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Telephone_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Final Project\Telephone_Words\input.txt"))
            {
                char[] value = Data.ToCharArray();
                string keys = string.Empty;
                List<string> Telephone_Values = new List<string>();
                foreach(char c in value)
                {
                    switch(c)
                    {
                        case '0':
                            MakeLoop(ref Telephone_Values, "0");
                            break;
                        case '1':
                            MakeLoop(ref Telephone_Values, "1");
                            break;
                        case '2':
                            MakeLoop(ref Telephone_Values, "abc");
                            break;
                        case '3':
                            MakeLoop(ref Telephone_Values, "def");
                            break;
                        case '4':
                            MakeLoop(ref Telephone_Values, "ghi");
                            break;
                        case '5':
                            MakeLoop(ref Telephone_Values, "jkl");
                            break;
                        case '6':
                            MakeLoop(ref Telephone_Values, "mno");
                            break;
                        case '7':
                            MakeLoop(ref Telephone_Values, "pqrs");
                            break;
                        case '8':
                            MakeLoop(ref Telephone_Values, "tuv");
                            break;
                        case '9':
                            MakeLoop(ref Telephone_Values, "wxyz");
                            break;
                    }
                }
                Telephone_Values.Sort();
                foreach(string s in Telephone_Values)
                {
                    keys += s + ",";
                }
                Console.WriteLine(keys.Substring(0,keys.Length-1));
            }
        }
        public static void MakeLoop(ref List<string> Telephone_Values, string value)
        {
            int i = 0;
            int Count = Telephone_Values.Count;
            if (Telephone_Values.Count > 0)
            {
                for (int k = 0; k < Count; k++)
                {
                    if (value.Length > 1)
                    {
                        foreach (char va in value)
                        {
                            Telephone_Values.Add(Telephone_Values[k] + va);
                        }
                    }
                    else
                    {
                        Telephone_Values.Add(Telephone_Values[k] + value);
                    }
                    i++;
                }
                Telephone_Values.RemoveRange(0, i);
            }
            else
            {
                if (value.Length > 1)
                {
                    foreach (char va in value)
                    {
                        Telephone_Values.Add(va.ToString());
                    }
                }
                else
                {
                    Telephone_Values.Add(value);
                }
            }
        }
    }
}
