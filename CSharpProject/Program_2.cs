using System;
using System.Text.RegularExpressions;

namespace CSharpProject
{
    class Program_2
    {
        public static void Main(string[] args)
        {
            string Text;
            Console.Write("Enter Text: ");
            Text = Console.ReadLine();
            string[] stop_words = new string[] {"me", "we", "our", "in", "to", "by", "of", "is", "it", "for"};
            foreach (string word in stop_words)
            {
                Text = Text.Replace(word, null);
                Regex regex = new Regex("[ ]{2,}", RegexOptions.None);
                Text = regex.Replace(Text, " ");
            }
            Console.Write(Text);
        }
    }
}
