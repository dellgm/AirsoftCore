using AirsoftCore.Application.Interface.Mapping;
using AirsoftCore.Domain.Entities;
using AutoMapper;

namespace AirsoftCore.Application.Products.Queries.GetAllProducts
{
    public class ProductDto : IHaveCustomMapping
    {
        public int ProductId { get; set; }

        public string Descr { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public short Stock { get; set; }

        public string ProductGroupDescr { get; set; }

        public string ProductTypeDescr { get; set; }

        public string BrandDescr { get; set; }

        public int BrandId { get; set; }

        public int ProductTypeId { get; set; }

        public byte[] Image { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductDto>()
                .ForMember(pDTO => pDTO.ProductGroupDescr, opt => opt.MapFrom(p => p.ProductGroup != null ? p.ProductGroup.Descr : string.Empty))
                .ForMember(pDTO => pDTO.ProductTypeDescr, opt => opt.MapFrom(p => p.ProductType != null ? p.ProductType.Descr : string.Empty));
        }
    }
}
