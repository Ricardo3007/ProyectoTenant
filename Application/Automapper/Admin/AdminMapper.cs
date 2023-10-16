using AutoMapper;
using multitenant.Application.DTO.Admin;
using multitenant.Domain.Entities.MultAdmin;

namespace multitenant.Application.Automapper.Admin
{
    public class AdminMapper:Profile
    {
        public  AdminMapper()
        {
            CreateMap<Organizations, OrganizationsDTO>()
                .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(orig => orig.Id))
                .ForMember(dest => dest.NameDTO, opt => opt.MapFrom(orig => orig.Name))
                .ForMember(dest => dest.slugtenantDTO, opt => opt.MapFrom(orig => orig.slugtenant));

            CreateMap<OrganizationsDTO, Organizations>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(orig => orig.IdDTO))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(orig => orig.NameDTO))
                .ForMember(dest => dest.slugtenant, opt => opt.MapFrom(orig => orig.slugtenantDTO));


            CreateMap<Users, UsersDTO>()
                .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(orig => orig.Id))
                .ForMember(dest => dest.EmailDTO, opt => opt.MapFrom(orig => orig.Email))
                .ForMember(dest => dest.PasswordDTO, opt => opt.MapFrom(orig => orig.Password));

            CreateMap<UsersDTO, Users>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(orig => orig.IdDTO))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(orig => orig.EmailDTO))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(orig => orig.PasswordDTO));
        }
    }
}
