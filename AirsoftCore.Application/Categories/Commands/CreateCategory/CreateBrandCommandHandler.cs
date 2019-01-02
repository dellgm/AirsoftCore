using AirsoftCore.Domain.Entities;
using AirsoftCore.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Application.Categories.Commands.CreateCategory
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, int>
    {
        private readonly AirsoftDbContext _context;

        public CreateBrandCommandHandler(AirsoftDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = new Brand
            {
                Descr = request.Descr
            };

            _context.Brands.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.BrandId;
        }
    }
}
