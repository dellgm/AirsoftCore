using MediatR;

namespace AirsoftCore.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<BrandViewModel>
    {
        public int Id { get; set; }
    }
}
