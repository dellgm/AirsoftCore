using AirsoftCore.Application.Categories.Models;
using AirsoftCore.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Application.Categories.Queries.GetAllCategories
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, BrandsListViewModel>
    {
        private readonly AirsoftDbContext _context;
        private readonly IMapper _mapper;

        public GetAllBrandsQueryHandler(AirsoftDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BrandsListViewModel> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            //TestBranch
            // TODO: Set view model state based on user permissions.//
            var brands = await _context.Brands.OrderBy(p => p.Descr).ToListAsync(cancellationToken);

            var model = new BrandsListViewModel
            {
                Brands = _mapper.Map<IEnumerable<BrandDto>>(brands),
                CreateEnabled = true
            };

            return model;
        }
    }
}
