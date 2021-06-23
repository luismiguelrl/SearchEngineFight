using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tranzact.SearchFight.Common.Extensions;
using Tranzact.SearchFight.Transport.Agents;

namespace Tranzact.SearchFight.Logic
{
    public static class WinnerCalculate
    {
        public static string ExecuteSearchFight(List<SearchEngineResponse> searchEngineResponses)
        {
            if (searchEngineResponses == null || searchEngineResponses.Count == 0)
                return "The search is empty... ";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Empty);

            List<string> searchFightInformation = SearchFightInformation(searchEngineResponses);
            List<string> searchFightWinners = SearchFightWinners(searchEngineResponses);
            string searchFightTotalWinner = SearchFightTotalWinner(searchEngineResponses);

            searchFightInformation.ForEach(s => stringBuilder.AppendLine(s));
            stringBuilder.AppendLine(string.Empty);
            searchFightWinners.ForEach(s => stringBuilder.AppendLine(s));
            stringBuilder.AppendLine(string.Empty);
            stringBuilder.AppendLine(searchFightTotalWinner);

            return stringBuilder.ToString();
        }

        public static List<string> SearchFightInformation(List<SearchEngineResponse> searchEngineResponses)
        {
            return searchEngineResponses
                .GroupBy(r => r.Query)
                .Select(g => $"{g.Key}: {string.Join(" ", g.Select(e => $"{e.SearchEngine}: {e.CountResults}"))}")
                .ToList();
        }

        public static List<string> SearchFightWinners(List<SearchEngineResponse> searchEngineResponses)
        {
            var winners = searchEngineResponses
                .GroupBy(g => g.SearchEngine)
                .Select(g => new { result = g.OrderBy(c => c.CountResults) })
                .Select(w => w.result.LastOrDefault());

            var winner = searchEngineResponses
                .GroupBy(g => g.SearchEngine,
                r => r, (search, results) => new
                {
                    SearchEngine = search,
                    Winner = results.MaxValue(c => c.CountResults).Query
                });
            //return winner.Select(c => $"{c.SearchEngine} winner: {c.Winner}").ToList();
            return winners.Select(c => $"{c.SearchEngine} winner: {c.Query}").ToList();
        }

        public static string SearchFightTotalWinner(List<SearchEngineResponse> searchEngineResponses)
        {

            string totalwinner = searchEngineResponses
                .GroupBy(r => r.Query, r => r,
                (query, result) => new
                {
                    Query = query,
                    Total = result.Sum(t => t.CountResults)
                })
                .MaxValue(r => r.Total).Query;

            var data = searchEngineResponses
                .GroupBy(g => g.Query)
                .Select(g => new
                {
                    Query = g.Key,
                    Total = g.Sum(r => r.CountResults)
                })
                .OrderBy(w => w.Total)
                .LastOrDefault();


            //var data = searchEngineResponses
            //    .GroupBy(g => g.Query)
            //    .Select(g => new { Query = g.Key, Total = g.Sum(r => r.CountResults) })
            //    .OrderBy(r => r.Total)
            //    .LastOrDefault();

            return $"Total winner: {data.Query}";
        }
    }
}
