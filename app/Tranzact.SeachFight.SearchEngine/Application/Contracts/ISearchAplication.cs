namespace Tranzact.SeachFight.SearchEngine.Application.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Result;

    public interface ISearchAplication
    {
        Task<List<SearchResult>> GetSearchEngine(List<string> query);
    }
}
