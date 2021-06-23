namespace Tranzact.SearchFight.SearchEngine.Domain.Contracts
{
    using System.Collections.Generic;
    using Tranzact.SearchFight.SearchEngine.View.Dto.Request;

    public interface ISearchDomain
    {
        string ExecuteSearchFight(List<SearchEngineRequest> request);
    }
}
