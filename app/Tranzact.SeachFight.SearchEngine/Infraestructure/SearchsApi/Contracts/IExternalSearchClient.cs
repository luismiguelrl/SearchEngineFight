namespace Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Result;

    public interface IExternalSearchClient
    {
        Task<SearchResult> GetCountSearchResultsAsync(string query);
    }
}