using AirsoftCore.Application.Exceptions;
using AirsoftCore.Domain.Entities;
using AirsoftCore.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly AirsoftDbContext _context;

        public UpdateProductCommandHandler(AirsoftDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            entity.ProductGroupId = request.ProductGroupId;
            entity.ProductTypeId = request.ProductTypeId;
            entity.BrandId = request.BrandId;
            entity.Descr = request.Descr;
            entity.Model = request.Model;
            entity.Price = request.Price;
            entity.Stock = request.Stock;
            entity.Image = request.Image;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
