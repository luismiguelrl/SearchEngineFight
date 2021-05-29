using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tranzact.SeachFight.SearchEngine.Application.Contracts;
using Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Result;
using Tranzact.SeachFight.SearchEngine.View.Dto.Request;

namespace Tranzact.SeachFight.SearchEngine.Controllers
{
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
    }
}
