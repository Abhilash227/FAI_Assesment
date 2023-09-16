using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assesment
{
    class Program
    {
        static Dictionary<string, string> dict = new Dictionary<string, string>();
        static List<string> list = new List<string>();
        static void Main(string[] args)
        {
            string num;
            int i=0;
            const string sentence = "the quick and brown fox jumps over the lazy dog";
            string[] words = sentence.Split(' ');
            //for (int n = 0; n < words.Length; n++)
            //    list.Add(words[n]);
            list = new List<string>(words);
            foreach (var item in list)
            {
                for(int j=0;j<item.Length;j++)
                {                    
                    num = i.ToString() + j.ToString();
                    if (!dict.ContainsKey(item[j].ToString()))
                        dict.Add(item[j].ToString(),num);
                }
                i++;   
            }
            Console.WriteLine("Enter the input to encode");
            Encode(Console.ReadLine().ToLower());
        }
        private static void Encode(string word)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append('-');
                }
                else
                    sb.Append(dict[word[i].ToString()] + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            Console.WriteLine(sb.ToString());
        }
    }
}