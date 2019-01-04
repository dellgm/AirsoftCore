using AirsoftCore.Application.ShoppingCarts.Queries.GetShoppingCart;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AirsoftCore.WebUI.Pages.ShoppingCart
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ShoppingCartViewModel ShoppingCartViewModel { get; set; }

        public async Task OnGetAsync(string cartId)
        {
            ShoppingCartViewModel = await _mediator.Send(new GetShoppingCartQuery { CartId = cartId });
        }
    }
}