namespace Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Tranzact.SearchFight.SearchEngine.Infraestructure.SearchsApi.Result;

    public interface IExternalSearchClient
    {
        public string SearchEngine { get; set; }
        Task<SearchResult> GetCountSearchResultsAsync(string query);
    }
}