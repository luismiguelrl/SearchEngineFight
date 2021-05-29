namespace Tranzact.SeachFight.SearchEngine.Application.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Result;

    public interface ISearchAplication
    {
        Task<List<SearchResult>> GetSearchEngine(List<string> query);
    }
}
