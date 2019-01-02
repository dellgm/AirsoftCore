using AirsoftCore.Application.Categories.Models;
using System.Collections.Generic;

namespace AirsoftCore.Application.Categories.Queries.GetAllCategories
{
    public class BrandsListViewModel
    {
        public IEnumerable<BrandDto> Brands { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
