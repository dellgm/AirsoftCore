using X.PagedList;

namespace AirsoftCore.Application.Products.Queries.GetAllProducts
{
    public class ProductsListViewModel
    {
        public IPagedList<ProductDto> Products { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
