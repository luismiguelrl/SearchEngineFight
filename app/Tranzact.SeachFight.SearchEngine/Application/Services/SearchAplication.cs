namespace Tranzact.SeachFight.SearchEngine.Application.Services
{
    using System.Collections.Generic;
    using System.Diagnostics;
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
    }
}