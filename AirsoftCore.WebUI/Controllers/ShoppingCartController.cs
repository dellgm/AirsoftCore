using AirsoftCore.Application.ShoppingCarts.Commands.AddItemToCart;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AirsoftCore.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private string ShoppingCartId
        {
            get
            {
                return GetCartId();
            }
        }

        private string GetCartId()
        {
            string cartSessionKey = "CartId";

            if (HttpContext.Session.GetString(cartSessionKey) == null)
            {
                var tempCartId = Guid.NewGuid();
                HttpContext.Session.SetString(cartSessionKey, tempCartId.ToString());
            }

            return HttpContext.Session.GetString(cartSessionKey);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var result = await _mediator.Send(new AddItemToCartCommand { CartId = ShoppingCartId, ProductId = id });

            return RedirectToPage("/ShoppingCart/Index", new { cartId = ShoppingCartId });
        }
    }
}