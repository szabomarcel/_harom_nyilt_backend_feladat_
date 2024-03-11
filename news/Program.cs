using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using news;

namespace news
{
    internal class Program
    {
        static Item hirek = null;
        static async Task Main(string[] args)
        {
            List<Item> hireks = await hir();
            foreach (Item hirek in hireks)
            {
                Console.WriteLine($"{hirek.Id} - {hirek.City}");
            }
            Console.WriteLine("Vége");
            Console.ReadLine();
        }

        private static async Task<List<Item>> hir()
        {
            List<Item> hirek = new List<Item>();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://chroniclingamerica.loc.gov/search/titles/results/?terms=oakland&format=json&page=5");
            var response = await client.SendAsync(request);            
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return hirek;
        }
    }
}
