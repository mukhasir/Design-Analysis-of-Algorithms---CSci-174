using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PrefixExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            List<char> Operators = new List<char>();
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Assignment 6\input_test.txt"))
            {
                if (Data != "")
                {
                    string[] DataSplit = Data.Split(' ');
                    for (int i = 0; i < DataSplit.Length; i++)
                    {
                        char c = Convert.ToChar(DataSplit[i].ToLower());
                        if (c == '*' || c == '+' || c == '/')
                        {
                            Operators.Add(c);
                        }
                        else
                        {
                            numbers.Add(double.Parse(c.ToString()));
                        }
                    }
                    double result = 0.0, num1 = 0.0, num2 = 0.0;
                    int counter = 0;
                    for (int j = Operators.Count - 1; j >= 0; j--)
                    {
                        char op = Operators[j];
                        if (counter == 0)
                        {
                            num1 = numbers[counter];
                            counter++;
                        }
                        else
                        {
                            num1 = result;
                        }
                        num2 = numbers[counter];
                        counter++;
                        switch (op)
                        {
                            case '+':
                                result = num1 + num2;
                                break;
                            case '*':
                                result = num1 * num2;
                                break;
                            case '/':
                                result = num1 / num2;
                                break;
                        }
                    }
                    Console.WriteLine(result);
                    numbers.Clear();
                    Operators.Clear();
                }
            }
        }
    }
}
