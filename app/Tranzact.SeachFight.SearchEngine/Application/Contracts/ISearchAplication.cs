namespace Tranzact.SearchFight.SearchEngine.Application.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tranzact.SearchFight.SearchEngine.Infraestructure.SearchsApi.Result;
    using Tranzact.SearchFight.SearchEngine.View.Dto.Request;

    public interface ISearchAplication
    {
        Task<List<SearchResult>> GetSearchEngine(List<string> query);
        SearchExecuteEngineResult ExecuteSearchFight(List<SearchEngineRequest> request);
    }
}
