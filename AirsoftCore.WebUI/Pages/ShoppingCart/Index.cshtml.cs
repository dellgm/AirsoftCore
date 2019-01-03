using AirsoftCore.Application.ShoppingCarts.Queries.GetShoppingCart;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace AirsoftCore.WebUI.Pages.ShoppingCart
{
    public class IndexModel : PageModel
    {
        public const string CartSessionKey = "CartId";
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ShoppingCartViewModel ShoppingCart { get; set; }
        public string CartId { get; set; }

        public async Task OnGetAsync()
        {
            ShoppingCart = await _mediator.Send(new GetShoppingCartQuery { CartId = GetCartId() });
        }

        public string GetCartId()
        {
            if (HttpContext.Session.GetString(CartSessionKey) == null)
            {
                var tempCartId = Guid.NewGuid();
                HttpContext.Session.SetString(CartSessionKey, tempCartId.ToString());
            }

            return HttpContext.Session.GetString(CartSessionKey);
        }
    }
}