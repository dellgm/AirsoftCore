using AirsoftCore.Application.Interface.Mapping;
using AirsoftCore.Domain.Entities;
using AutoMapper;

namespace AirsoftCore.Application.ShoppingCarts.Queries.GetShoppingCart
{
    public class ShoppingCartDto : IHaveCustomMapping
    {
        public int ShoppingCartId { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Descr { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<ShoppingCart, ShoppingCartDto>()
                .ForMember(pDTO => pDTO.Descr, opt => opt.MapFrom(p => p.Product != null ? p.Product.Descr : string.Empty))
                .ForMember(pDTO => pDTO.Price, opt => opt.MapFrom(p => p.Product != null ? p.Product.Price : 0));
        }
    }
}