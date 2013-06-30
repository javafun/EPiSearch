using System;
using System.Collections.Generic;
using System.Linq;

namespace EPiSearch
{
    public class SearchResults
    {
        public SearchResults()
        {
            Results = new List<SearchItem>();
        }

        public IEnumerable<SearchItem> Results { get; set; }

        public int TotalCount { get; set; }
    }
}
