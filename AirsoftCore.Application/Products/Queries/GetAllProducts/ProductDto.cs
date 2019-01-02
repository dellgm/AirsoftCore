namespace AirsoftCore.Application.Products.Queries.GetAllProducts
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Descr { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public short Stock { get; set; }

        public string ProductGroupDescr { get; set; }

        public string ProductTypeDescr { get; set; }

        public string BrandDescr { get; set; }

        public byte[] Image { get; set; }

        //public void CreateMappings(Profile configuration)
        //{
        //    configuration.CreateMap<Product, ProductDto>()
        //        .ForMember(pDTO => pDTO.SupplierCompanyName, opt => opt.MapFrom(p => p.Supplier != null ? p.Supplier.CompanyName : string.Empty))
        //        .ForMember(pDTO => pDTO.CategoryName, opt => opt.MapFrom(p => p.Category != null ? p.Category.CategoryName : string.Empty));
        //}
    }
}
