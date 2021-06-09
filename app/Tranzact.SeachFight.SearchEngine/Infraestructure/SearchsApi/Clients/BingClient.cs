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

    public class BingClient : IExternalSearchClient
    {
        public string SearchEngine { get; set; } = "MSN Search";
        private readonly HttpClient _httpClient;
        private readonly ExternalClientConfiguration externalClientConfiguration;

        public BingClient(HttpClient httpClient,
            IOptionsMonitor<ExternalClientConfiguration> options)
        {
            externalClientConfiguration = options.Get(ExternalClientConfiguration.BingApiSearch);

            httpClient.BaseAddress = new Uri(externalClientConfiguration.Url);
            httpClient.DefaultRequestHeaders.Add(externalClientConfiguration.SearchEngineId, externalClientConfiguration.ApiKey);

            _httpClient = httpClient;
        }

        public async Task<SearchResult> GetCountSearchResultsAsync(string searchQuery)
        {
            var bingresult = await _httpClient.GetFromJsonAsync<BingSearchResult>(_httpClient.BaseAddress + searchQuery);

            return new SearchResult
            {
                CountResults = bingresult.webPages.totalEstimatedMatches,
                Query = searchQuery,
                SearchEngine = "MSN Search"
            };
        }
    }
}