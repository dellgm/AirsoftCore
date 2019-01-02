using AirsoftCore.Application.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AirsoftCore.WebUI.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ProductsListViewModel Products { get; private set; }

        public async Task OnGetAsync()
        {
            Products = await _mediator.Send(new GetAllProductsQuery());
        }
    }
}