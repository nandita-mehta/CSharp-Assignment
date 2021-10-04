using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace CSharpProject
{
    class Program_7
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();
            var data = File.ReadAllLines(filePath).Skip(1);
            foreach (var i in data)
            {
                Console.WriteLine(float.Parse(i));
            }

        }
    }
}
