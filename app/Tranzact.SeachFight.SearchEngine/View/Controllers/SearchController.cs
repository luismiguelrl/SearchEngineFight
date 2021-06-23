namespace Tranzact.SearchFight.SearchEngine.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tranzact.SearchFight.SearchEngine.Application.Contracts;
    using Tranzact.SearchFight.SearchEngine.Infraestructure.SearchsApi.Result;
    using Tranzact.SearchFight.SearchEngine.View.Dto.Request;

    public class SearchController : BaseController
    {
        private readonly ISearchAplication searchAplication;

        public SearchController(ISearchAplication searchAplication)
        {
            this.searchAplication = searchAplication;
        }

        [HttpPost]
        public async Task<List<SearchResult>> SearchEngine(SearchRequest request)
        {
            return await searchAplication.GetSearchEngine(request.languages);
        }

        [HttpPost]
        public SearchExecuteEngineResult ExecuteSearchFight(List<SearchEngineRequest> request)
        {
            return searchAplication.ExecuteSearchFight(request);            
        }
    }
}
