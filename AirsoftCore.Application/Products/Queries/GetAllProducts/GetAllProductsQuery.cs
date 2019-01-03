using MediatR;
using System.Collections.Generic;

namespace AirsoftCore.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ProductsListViewModel>
    {
        public int? Page { get; set; }
        public IList<int> Brands { get; set; }
        public IList<int> Types { get; set; }
        public int ShowOnly { get; set; }
        public string Search { get; set; }
    }
}
