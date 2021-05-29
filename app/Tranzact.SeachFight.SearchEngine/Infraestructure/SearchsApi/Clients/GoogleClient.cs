namespace Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Clients
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.Configuration;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Contracts;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Model;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Result;

    public class GoogleClient : IExternalSearchClient
    {
        private readonly HttpClient _httpClient;
        private readonly ExternalClientConfiguration externalClientConfiguration;

        public GoogleClient(HttpClient httpClient,
            IOptionsMonitor<ExternalClientConfiguration> options)
        {
            externalClientConfiguration = options.Get(ExternalClientConfiguration.GoogleApiSearch);
            httpClient.BaseAddress = new Uri(externalClientConfiguration.Url
                + "?key=" + externalClientConfiguration.ApiKey
                + "&cx=" + externalClientConfiguration.SearchEngineId
                + "&q=");
            _httpClient = httpClient;
        }

        public async Task<SearchResult> GetCountSearchResultsAsync(string searchQuery)
        {
            var result = await _httpClient.GetFromJsonAsync<GoogleSearchResult>(_httpClient.BaseAddress + searchQuery);

            return new SearchResult
            {
                SearchEngine = "Google",
                Query = searchQuery,
                CountResults = long.Parse(result.SearchInformation.TotalResults)
            };
        }
    }
}
