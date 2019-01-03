using AirsoftCore.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Application.ShoppingCarts.Queries.GetShoppingCart
{
    public class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, ShoppingCartViewModel>
    {
        private readonly AirsoftDbContext _context;
        private readonly IMapper _mapper;

        public GetShoppingCartQueryHandler(AirsoftDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ShoppingCartViewModel> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
        {

            var viewModel = new ShoppingCartViewModel
            {
                ShoppingCartItems = _mapper.Map<IEnumerable<ShoppingCartDto>>(await _context.ShoppingCarts.Where(s => s.CartId == request.CartId).Include(p => p.Product).ToListAsync()),
                TotalPrice = await _context.ShoppingCarts.Where(c => c.CartId == request.CartId).Select(s => s.Quantity * s.Product.Price).SumAsync()
            };

            return viewModel;
        }
    }
}
