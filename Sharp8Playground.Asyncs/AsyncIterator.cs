using System.Collections.Generic;

namespace Chapter15
{
    class AsyncIterator
    {
        private readonly IGeoService service;

        public AsyncIterator(IGeoService service) => this.service = service;

        public async IAsyncEnumerable<string> ListCitiesAsync()
        {
            string pageToken = null;
            do
            {
                var request = new ListCitiesRequest(pageToken);
                var response = await service.ListCitiesAsync(request);
                foreach (var city in response.Cities)
                {
                    yield return city;
                }
                pageToken = response.NextPageToken;
            } while (pageToken != null);
        }
    }
}
