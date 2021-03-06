﻿using AirsoftCore.Application.Exceptions;
using AirsoftCore.Domain.Entities;
using AirsoftCore.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly AirsoftDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(AirsoftDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductViewModel>(await _context
                .Products.Where(p => p.ProductId == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            product.EditEnabled = true;
            product.DeleteEnabled = false;

            return product;
        }
    }
}
