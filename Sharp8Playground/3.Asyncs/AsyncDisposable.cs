using System;
using System.Threading.Tasks;

namespace Sharp8Playground._3.Asyncs
{
    class AsyncResource : IAsyncDisposable
    {
        public async Task PerformWorkAsync()
        {
            Console.WriteLine("Performing work asynchronously...");
            await Task.Delay(2000);
            Console.WriteLine("... done");
        }

        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("Disposing asynchronously...");
            await Task.Delay(2000);
            Console.WriteLine("... done");
        }
    }

    class AsyncUtil
    {
        public static async Task Main()
        {
            using await (var resource = new AsyncResource())
            {
                await resource.PerformWorkAsync();
            }
            Console.WriteLine("After the using await statement");
        }
    }
}
