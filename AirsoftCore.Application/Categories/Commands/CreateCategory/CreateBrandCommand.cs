using MediatR;

namespace AirsoftCore.Application.Categories.Commands.CreateCategory
{
    public class CreateBrandCommand : IRequest<int>
    {
        public string Descr { get; set; }
    }
}
