using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tranzact.SearchFight.Logic;
using Tranzact.SearchFight.Transport.Agents;

namespace Tranzact.SearchFight.Test.Aplication
{
    [TestClass]
    public class SearchEngineFightLogicTest
    {
        [TestMethod]
        public void Validate_DataWithNull()
        {
            var result = WinnerCalculate.ExecuteSearchFight(null);
            Assert.AreEqual("The search is empty... ", result);
        }

        [TestMethod]
        public void Validate_GenerateQuerysAsString()
        {            
            var result = WinnerCalculate.ExecuteSearchFight(GetDataForTesting());
            Assert.IsInstanceOfType(result, typeof(string));
            //result.Should().BeOfType<string>();
        }

        public List<SearchEngineResponse> GetDataForTesting()
        {
            return new List<SearchEngineResponse>
            {
                new SearchEngineResponse
                {
                    CountResults = 50000,
                    Query = ".net",
                    SearchEngine ="Google"
                },
                new SearchEngineResponse
                {
                    CountResults = 902300,
                    Query = "java",
                    SearchEngine ="Google"
                },
                new SearchEngineResponse
                {
                    CountResults = 454000,
                    Query = "\"java script \"",
                    SearchEngine ="Google"
                },
                new SearchEngineResponse
                {
                    CountResults = 606300,
                    Query = ".net",
                    SearchEngine ="MSN Search"
                },
                new SearchEngineResponse
                {
                    CountResults = 631110,
                    Query = "java",
                    SearchEngine ="MSN Search"
                },
                new SearchEngineResponse
                {
                    CountResults = 854000,
                    Query = "\"java script \"",
                    SearchEngine ="MSN Search"
                },
            };
        }
    }
}
