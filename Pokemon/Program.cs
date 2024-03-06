using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Pokemon;

namespace Pokemon
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Search> search = new List<Search>();
            Console.WriteLine("Pokemond neve: ");
            Console.WriteLine("Megjelenés: ");
            await pokemonseeach();
            foreach (Search kereses in search)
            {
                Console.WriteLine($"{kereses.Name} - {kereses.Stats}");
            }
            Console.ReadLine();
        }

        private static async Task pokemonseeach()
        {
            List<Search> search = new List<Search>();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon/ditto/");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
