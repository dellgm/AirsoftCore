using System.Collections.Generic;

namespace AirsoftCore.WebUI.Filters
{
    public class ProductFilter
    {
        public IList<int> Brands { get; set; }
        public IList<int> Types { get; set; }
        public int ShowOnly { get; set; }
        public string Search { get; set; }
    }
}