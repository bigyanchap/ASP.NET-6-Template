using AutoMapper;
using cartApp.DTO;
using cartApp.Entities;

namespace cartApp.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ProductDTO, Product>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
