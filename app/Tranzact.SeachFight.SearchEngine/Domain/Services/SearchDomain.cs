namespace Tranzact.SearchFight.SearchEngine.Domain.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Tranzact.SearchFight.SearchEngine.Domain.Contracts;
    using Tranzact.SearchFight.SearchEngine.Infraestructure.Configuration;
    using Tranzact.SearchFight.SearchEngine.View.Dto.Request;

    public class SearchDomain : ISearchDomain
    {
        public string ExecuteSearchFight(List<SearchEngineRequest> request)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Empty);

            List<string> searchFightInformation = SearchFightInformation(request);
            List<string> searchFightWinners = SearchFightWinners(request);
            string searchFightTotalWinner = SearchFightTotalWinner(request);

            searchFightInformation.ForEach(s => stringBuilder.AppendLine(s));
            stringBuilder.AppendLine(string.Empty);
            searchFightWinners.ForEach(s => stringBuilder.AppendLine(s));
            stringBuilder.AppendLine(string.Empty);
            stringBuilder.AppendLine(searchFightTotalWinner);

            return stringBuilder.ToString();
        }

        private List<string> SearchFightInformation(List<SearchEngineRequest> searchEngineResponses)
        {
            return searchEngineResponses
                .GroupBy(r => r.Query)
                .Select(g => $"{g.Key}: {string.Join(" ", g.Select(e => $"{e.SearchEngine}: {e.CountResults}"))}")
                .ToList();
        }

        public List<string> SearchFightWinners(List<SearchEngineRequest> searchEngineResponses)
        {
            var winner = searchEngineResponses
                .GroupBy(g => g.SearchEngine,
                r => r, (search, results) => new
                {
                    SearchEngine = search,
                    Winner = results.MaxValue(c => c.CountResults).Query
                });
            return winner.Select(c => $"{c.SearchEngine} winner: {c.Winner}").ToList();
        }

        private string SearchFightTotalWinner(List<SearchEngineRequest> searchEngineResponses)
        {
            string totalwinner = searchEngineResponses
                .GroupBy(r => r.Query, r => r,
                (query, result) => new
                {
                    Query = query,
                    Total = result.Sum(t => t.CountResults)
                })
                .MaxValue(r => r.Total).Query;

            return $"Total winner: {totalwinner}";
        }
    }
}
