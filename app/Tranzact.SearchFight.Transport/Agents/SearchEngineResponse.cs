using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.SearchFight.Transport.Agents
{
    public class SearchEngineResponse
    {   
        public string SearchEngine { get; set; }
        public string Query { get; set; }
        public long CountResults { get; set; }
    }
}
