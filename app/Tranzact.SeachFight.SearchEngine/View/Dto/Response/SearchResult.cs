namespace Tranzact.SeachFight.SearchEngine.Infraestructure.SearchsApi.Result
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SearchResult
    {        
        public string SearchEngine { get; set; }
        public string Query { get; set; }
        public long CountResults { get; set; }
    }
}
