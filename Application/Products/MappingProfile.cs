using AutoMapper;
using Domain;

namespace Application.Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Grade, o => o.MapFrom(s => s.VarGrade.Name))
                .ForMember(d => d.Diameter, o => o.MapFrom(s => s.VarDiameter.Name))
                .ForMember(d => d.Length, o => o.MapFrom(s => s.VarLength.Name));
        }
    }
}