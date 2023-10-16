using AutoMapper;
using multitenant.Application.DTO.Inventario;
using multitenant.Domain.Entities.MultInventario;

namespace multitenant.Application.Automapper.Inventario
{
    public class ProductoMapper:Profile
    {
        public  ProductoMapper()
        {
            CreateMap<Products, ProductoDTO>()
                .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(orig => orig.Id))
                .ForMember(dest => dest.NameDTO, opt => opt.MapFrom(orig => orig.Name))
                .ForMember(dest => dest.EstadoDTO, opt => opt.MapFrom(orig => orig.Estado));

            CreateMap<ProductoDTO, Products>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(orig => orig.IdDTO))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(orig => orig.NameDTO))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(orig => orig.EstadoDTO));
        }
    }
}
