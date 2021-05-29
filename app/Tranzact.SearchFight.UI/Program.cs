using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tranzact.SearchFight.Common.Extensions;
using Tranzact.SearchFight.Common.Util;
using Tranzact.SearchFight.Logic;
using Tranzact.SearchFight.Transport.Agents;

namespace Tranzact.SearchFight.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            string UrlSearchEngineApi = config["SearchEngineApi"];

            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a query to search....");
                string line = Console.ReadLine().ToString();
                args = DelimitedString.Split(line);
            }

            using var httpclient = new HttpClient();
            var querySerialized = JsonSerializer.Serialize(new { languages = args.ToList() });
            var content = new StringContent(querySerialized, Encoding.UTF8, "application/json");
            var result = await httpclient.PostAsync(UrlSearchEngineApi, content);

            if (result.IsSuccessStatusCode)
            {
                var results = result.ContentAsType<List<SearchEngineResponse>>();
                var resultFight = WinnerCalculate.ExecuteSearchFight(results);

                Console.WriteLine(resultFight);
            }
        }
    }
}