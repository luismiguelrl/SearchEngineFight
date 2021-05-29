namespace Tranzact.SeachFight.SearchEngine.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Tranzact.SeachFight.SearchEngine.Application.Contracts;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Contracts;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Result;

    public class SearchAplication : ISearchAplication
    {
        private readonly IEnumerable<IExternalSearchClient> _externalSearchClients;
        private readonly List<Task<SearchResult>> taskList;

        public SearchAplication(IEnumerable<IExternalSearchClient> externalSearchClients)
        {
            _externalSearchClients = externalSearchClients;
            taskList = new List<Task<SearchResult>>();
        }
        public async Task<List<SearchResult>> GetSearchEngine(List<string> query)
        {
            List<SearchResult> results = new List<SearchResult>();

            foreach (var language in query)
            {
                foreach (var client in _externalSearchClients)
                {
                    var result = await client.GetCountSearchResultsAsync(language);
                    results.Add(result);
                }
            }

            return results;
        }
    }
}
