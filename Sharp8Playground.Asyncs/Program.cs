using Chapter15;
using Sharp8Playground._3.Asyncs;
using System;
using System.Threading.Tasks;

namespace Sharp8Playground.Asyncs
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 4.1 Async disposable
            await using (var resource = new AsyncResource())
            {
                await resource.PerformWorkAsync();
            }
            Console.WriteLine("After the using await statement");

            var fakeService = new FakeGeoService();
            fakeService.AddPage("London", "Paris", "Washington");
            fakeService.AddPage(); // Empty pages are valid
            fakeService.AddPage("Nairobi", "Sydney", "New Delhi");
            fakeService.AddPage("Moscow", "Kiev");
            fakeService.AddPage(); // Empty pages are valid
            fakeService.AddPage("Madrid", "Vologda");

            // 4.2 Async iteratiors (yield return)
                        
            var asyncIterator = new AsyncIterator(fakeService);
            await foreach (var city in asyncIterator.ListCitiesAsync())
            {
                Console.WriteLine(city);
            }

            // 4.3 Async iteration (сложный вариант)

            var client = new GeoClient(fakeService);
            await foreach (var city in client.ListCitiesAsync())
            {
                Console.WriteLine(city);
            }
        }
    }
}
