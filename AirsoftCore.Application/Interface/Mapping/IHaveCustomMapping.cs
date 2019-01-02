using AutoMapper;

namespace AirsoftCore.Application.Interface.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
