using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CSharpProject
{
    class Program_6
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter search query: ");
            string searchQuery = Console.ReadLine();
            string apiKey = "";
            string cx = "";
            WebRequest request = HttpWebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + searchQuery);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseFromServer = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseFromServer);
            for(int i=0;i<10; i++)
            {
                Console.WriteLine("{");
                Console.WriteLine($"Kind:'{jsonData.items[i].kind}'\nTitle:'{jsonData.items[i].title}'\nLink:'{jsonData.items[i].link}'");
                Console.WriteLine("},");
            }
        }
    }
}
