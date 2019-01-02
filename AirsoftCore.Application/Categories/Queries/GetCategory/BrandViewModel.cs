namespace AirsoftCore.Application.Categories.Queries.GetCategory
{
    public class BrandViewModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public bool EditEnabled { get; set; }
        public bool DeleteEnabled { get; set; }
        public bool CreateEnabled { get; set; }

        //public void CreateMappings(Profile configuration)
        //{
        //    configuration.CreateMap<Category, CategoryViewModel>()
        //        .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
        //        .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>());
        //}

        //class PermissionsResolver : IValueResolver<Category, CategoryViewModel, bool>
        //{
        //    // TODO: inject your services and helper here
        //    public PermissionsResolver()
        //    {

        //    }

        //    public bool Resolve(Category source, CategoryViewModel dest, bool destMember, ResolutionContext context)
        //    {
        //        return false;
        //    }
        //}
    }
}
