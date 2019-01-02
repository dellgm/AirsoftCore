using MediatR;

namespace AirsoftCore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Descr { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public short Stock { get; set; }

        public int ProductGroupId { get; set; }

        public int ProductTypeId { get; set; }

        public int BrandId { get; set; }

        public byte[] Image { get; set; }
    }
}
