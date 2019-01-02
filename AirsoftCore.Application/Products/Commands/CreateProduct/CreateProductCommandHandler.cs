using AirsoftCore.Domain.Entities;
using AirsoftCore.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirsoftCore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly AirsoftDbContext _context;

        public CreateProductCommandHandler(AirsoftDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                ProductGroupId = request.ProductGroupId,
                ProductTypeId = request.ProductTypeId,
                BrandId = request.BrandId,
                Descr = request.Descr,
                Model = request.Model,
                Price = request.Price,
                Stock = request.Stock,
                Image = request.Image
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProductId;
        }
    }
}
