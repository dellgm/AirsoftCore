namespace AirsoftCore.Application.Products.Queries.GetProduct
{
    public class ProductViewModel /*: IHaveCustomMapping*/
    {
        public string Descr { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public short Stock { get; set; }

        public int ProductGroupDescr { get; set; }

        public int ProductTypeDescr { get; set; }

        public int BrandDescr { get; set; }

        public byte[] Image { get; set; }

        public bool Discontinued { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        //public void CreateMappings(Profile configuration)
        //{
        //    configuration.CreateMap<Product, ProductViewModel>()
        //        .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
        //        .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>())
        //        .ForMember(pDTO => pDTO.SupplierCompanyName, opt => opt.MapFrom(p => p.Supplier != null ? p.Supplier.CompanyName : string.Empty))
        //        .ForMember(pDTO => pDTO.CategoryName, opt => opt.MapFrom(p => p.Category != null ? p.Category.CategoryName : string.Empty));
        //}

        //class PermissionsResolver : IValueResolver<Product, ProductViewModel, bool>
        //{
        //    // TODO: inject your services and helper here
        //    public PermissionsResolver()
        //    {

        //    }

        //    public bool Resolve(Product source, ProductViewModel dest, bool destMember, ResolutionContext context)
        //    {
        //        return false;
        //    }
        //}
    }
}