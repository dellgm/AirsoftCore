using AirsoftCore.Application.Exceptions;
using AirsoftCore.Domain.Entities;
using AirsoftCore.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, BrandViewModel>
    {
        private readonly AirsoftDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(AirsoftDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BrandViewModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<BrandViewModel>(await _context
                .Brands.Where(c => c.BrandId == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (brand == null)
            {
                throw new NotFoundException(nameof(Brand), request.Id);
            }

            brand.EditEnabled = true;
            brand.DeleteEnabled = false;

            return brand;
        }
    }
}
