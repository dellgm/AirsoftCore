using AirsoftCore.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace AirsoftCore.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductsListViewModel>
    {
        private readonly AirsoftDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(AirsoftDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsListViewModel> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            // TODO: Set view model state based on user permissions.
            var products = await _context.Products.OrderBy(p => p.Descr).ToListAsync(cancellationToken);

            if (request.Brands != null && request.Brands.Any())
            {
                products = products.Where(t => request.Brands.Contains(t.BrandId)).ToList();
            }

            if (request.Types != null && request.Types.Any())
            {
                products = products.Where(t => request.Types.Contains(t.ProductTypeId)).ToList();
            }

            if (request.ShowOnly > 0)
            {
                products = products.Take(request.ShowOnly).ToList();
            }

            if (!string.IsNullOrEmpty(request.Search))
            {
                products = products.Where(p => p.Descr == request.Search).ToList();
            }

            var model = new ProductsListViewModel
            {
                Products = _mapper.Map<IEnumerable<ProductDto>>(products).ToPagedList(request.Page ?? 1, 25),
                CreateEnabled = true
            };

            return model;
        }
    }
}
