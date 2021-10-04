using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSharpProject
{
    public class person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
    }

    class Program_5
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();
            string jsonData = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            foreach(var i in data)
            {
                Console.WriteLine(i.Key + ": " + i.Value);
            }

        }
    }
}