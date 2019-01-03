using AirsoftCore.Domain.Entities;
using AirsoftCore.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Application.ShoppingCarts.Commands.AddItemToCart
{
    public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, int>
    {
        private readonly AirsoftDbContext _context;

        public AddItemToCartCommandHandler(AirsoftDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _context.ShoppingCarts.Where(
                c => c.CartId == request.CartId
                     && c.ProductId == request.ProductId).SingleOrDefaultAsync();

            if (cartItem == null)
            {
                cartItem = new ShoppingCart
                {
                    ProductId = request.ProductId,
                    CartId = request.CartId,
                    Quantity = 1
                };

                _context.ShoppingCarts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return cartItem.ShoppingCartId;
        }
    }
}
