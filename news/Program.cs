using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace news
{
    internal class Program
    {
        static Hirek hirek = null;
        static async Task Main(string[] args)
        {
            List<Hirek> hireks = await hir();
            foreach (Hirek hirek in hireks)
            {
                Console.WriteLine($"{hirek.Title} - {hirek.Date}");
            }
            Console.WriteLine("Vége");
            Console.ReadLine();
        }

        private static async Task<List<Hirek>> hir()
        {
            List<Hirek> hirek = new List<Hirek>();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://chroniclingamerica.loc.gov/search/titles/results/?terms=oakland&format=json&page=5");
            var response = await client.SendAsync(request);            
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return hirek;
        }
    }
}
