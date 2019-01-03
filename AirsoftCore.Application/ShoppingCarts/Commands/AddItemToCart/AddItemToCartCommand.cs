using MediatR;

namespace AirsoftCore.Application.ShoppingCarts.Commands.AddItemToCart
{
    public class AddItemToCartCommand : IRequest<int>
    {
        public string CartId { get; set; }
        public int ProductId { get; set; }
    }
}
