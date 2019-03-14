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
}
