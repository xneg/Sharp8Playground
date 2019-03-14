using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter15
{
    public class GeoClient
    {
        private readonly IGeoService service;

        public GeoClient(IGeoService service) => this.service = service;

        public IAsyncEnumerable<string> ListCitiesAsync() => new CityEnumerable(service);

        private class CityEnumerable : IAsyncEnumerable<string>
        {
            private readonly IGeoService service;

            public CityEnumerable(IGeoService service) => this.service = service;

            public IAsyncEnumerator<string> GetAsyncEnumerator(CancellationToken cancellationToken = default) => new CityEnumerator(service);
 
        }

        private class Enumerator : IEnumerator<int>
        {
            public int Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        private class CityEnumerator : IAsyncEnumerator<string>
        {
            private readonly IGeoService service;
            private ListCitiesResponse currentResponse;
            private int nextIndex = 0;

            public string Current
            {
                get
                {
                    string city = currentResponse.Cities[nextIndex];
                    nextIndex++;
                    return city;
                }
            }

            public CityEnumerator(IGeoService service) => this.service = service;

            public async ValueTask<bool> MoveNextAsync()
            {
                if (currentResponse != null && nextIndex >= currentResponse.Cities.Count && currentResponse.NextPageToken == null)
                {
                    return false;
                }

                if (currentResponse == null || nextIndex >= currentResponse.Cities.Count)
                {
                    do
                    {
                        string nextPageToken = currentResponse?.NextPageToken;
                        currentResponse = await service.ListCitiesAsync(new ListCitiesRequest(nextPageToken));
                        nextIndex = 0;
                    }
                    while (!currentResponse.Cities.Any() && currentResponse.NextPageToken != null);

                    return currentResponse.Cities.Any() || currentResponse.NextPageToken != null;
                }

                return true;
            }

            public ValueTask DisposeAsync()
            {
                Console.WriteLine("Disposed...");
                return new ValueTask();
            }
        }
    }
}
