using System;

namespace CSharpProject
{
    class Program_1
    {
        public static void Main(string[] args)
        {
 
            string Text, Word;
            int count = 0, i = 0;
            Console.Write("Enter Text: ");
            Text = Console.ReadLine();
            Console.Write("Enter Word: ");
            Word = Console.ReadLine();
            string[] stopWords = new string[] { "me", "we", "our", "in", "to", "by", "of", "is", "it", "for" };
            int flag = 0;
            foreach (string word in stopWords)
            {
                if (Word == word)
                {
                    flag = 1;
                    break;
                }
                else
                {
                    flag = 0;
                }
            }
            if(flag == 1)
            {
                Console.WriteLine("Not applicable");
            }
            else
            {
                while ((i = Text.IndexOf(Word, i)) != -1)
                {
                    i += Word.Length;
                    count++;
                }
                Console.WriteLine(count);
            }
        }
    }
}
