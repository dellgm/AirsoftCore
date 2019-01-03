using MediatR;

namespace AirsoftCore.Application.ShoppingCarts.Queries.GetShoppingCart
{
    public class GetShoppingCartQuery : IRequest<ShoppingCartViewModel>
    {
        public string CartId { get; set; }
    }
}
