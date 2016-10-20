using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Type_Ahead
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text_array = {"Mary", "had", "a", "little", "lamb", "its", "fleece", "was",
              "white", "as", "snow", "And", "everywhere", "that", "Mary",
              "went", "the", "lamb", "was", "sure", "to", "go", "It",
              "followed", "her", "to", "school", "one", "day", "which", "was",
              "against", "the", "rule", "It", "made", "the", "children",
              "laugh", "and", "play", "to", "see", "a", "lamb", "at", "school",
              "And", "so", "the", "teacher", "turned", "it", "out", "but",
              "still", "it", "lingered", "near", "And", "waited", "patiently",
              "about", "till", "Mary", "did", "appear", "Why", "does", "the",
              "lamb", "love", "Mary", "so", "the", "eager", "children", "cry",
              "Why", "Mary", "loves", "the", "lamb", "you", "know", "the",
              "teacher", "did", "reply"};
            bool Single = false;
            foreach (string Data in File.ReadAllLines(@"E:\Fall 2015\Design Analysis of Algorithms\Assignment 5\Input_Test.txt"))//
            {
                string[] DataValues = Data.Split(',');
                int number = int.Parse(DataValues[0].ToString());
                string checkWord = DataValues[1].Trim();
                Single = false;
                if (checkWord.Length==1)
                {
                    Single = true;
                }
                checkWord = checkWord.Replace(" ", "");               
                BuildSet(text_array, number, checkWord, Single);
            }
        }
        public static void BuildSet(string[] text_array,int number, string word, bool Single)
        {
            Dictionary<string, int> NWordList = new Dictionary<string, int>();
            string keyWord = string.Empty;
            double totalCount = 0.000;
            for (int i = 0; i <= text_array.Length - number; i++)
            {
                if(Single == true)
                {
                    if(text_array[i]==word)
                    {
                        for (int j = 0; j < number; j++)
                        {
                            keyWord += text_array[i + j];
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < number; j++)
                    {
                        keyWord += text_array[i + j];
                    }
                }
                if (keyWord != "")
                {
                    if (NWordList.ContainsKey(keyWord))
                    {
                        NWordList[keyWord] += 1;
                    }
                    else
                    {
                        NWordList.Add(keyWord, 1);
                    }
                    if (keyWord.Contains(word))
                    {
                        if (keyWord.Substring(0, word.Length) == word)
                        {
                            totalCount++;
                        }
                    }
                }
                keyWord = "";
            }
            string FinaloutPut = string.Empty;
            Dictionary<string, double> FinalResult = new Dictionary<string, double>();
            foreach (KeyValuePair<string, int> Value in NWordList)
            {
                if (Value.Key.Contains(word))
                {
                    if (Value.Key.Substring(0, word.Length) == word)
                    {
                        string Key = Value.Key.Substring(word.Length, (Value.Key.Length - word.Length));
                        double dValue = (Value.Value / totalCount);
                        FinalResult.Add(Key,dValue);
                    }
                }
            }
            var items = from pair in FinalResult
                        orderby pair.Value descending,pair.Key
                        select pair;
            foreach (KeyValuePair<string, double> ValueFinal in items)
            {
                FinaloutPut += ValueFinal.Key + "," + ValueFinal.Value.ToString("0.000") + ";";
            }
            Console.WriteLine(FinaloutPut.Substring(0,FinaloutPut.Length-1));
        }
    }
}
