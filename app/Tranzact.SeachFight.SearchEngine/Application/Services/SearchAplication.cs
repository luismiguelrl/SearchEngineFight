namespace Tranzact.SearchFight.SearchEngine.Application.Services
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Contracts;
    using Tranzact.SearchFight.SearchEngine.Application.Contracts;
    using Tranzact.SearchFight.SearchEngine.Domain.Contracts;
    using Tranzact.SearchFight.SearchEngine.Domain.Services;
    using Tranzact.SearchFight.SearchEngine.Infraestructure.Configuration;
    using Tranzact.SearchFight.SearchEngine.Infraestructure.SearchsApi.Result;
    using Tranzact.SearchFight.SearchEngine.View.Dto.Request;

    public class SearchAplication : ISearchAplication
    {
        private readonly IEnumerable<IExternalSearchClient> _externalSearchClients;
        private readonly List<Task<SearchResult>> taskList;
        private readonly ISearchDomain searchDomain;
        public SearchAplication(IEnumerable<IExternalSearchClient> externalSearchClients, ISearchDomain searchDomain)
        {
            _externalSearchClients = externalSearchClients;
            taskList = new List<Task<SearchResult>>();
            this.searchDomain = searchDomain;
        }

        public async Task<List<SearchResult>> GetSearchEngine(List<string> query)
        {
            List<SearchResult> results = new List<SearchResult>();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var language in query)
            {
                var tasks = _externalSearchClients.Select(async client =>
                    results.Add(await client.GetCountSearchResultsAsync(language)));

                await Task.WhenAll(tasks);
            }
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;
            Trace.WriteLine($"Total miliseconds ===================> {elapsed}");

            return results;
        }
        public SearchExecuteEngineResult ExecuteSearchFight(List<SearchEngineRequest> request)
        {
            if (request == null || request.Count == 0)
                return new SearchExecuteEngineResult
                {
                    result = "The search is empty... "
                };

            return new SearchExecuteEngineResult
            {
                result = searchDomain.ExecuteSearchFight(request)
            };
        }
    }
}