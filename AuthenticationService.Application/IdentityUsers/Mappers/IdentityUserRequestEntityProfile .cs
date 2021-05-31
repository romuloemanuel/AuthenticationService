using AuthenticationService.Application.IdentityUsers.Requests;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationService.Application.IdentityUsers.Mappers
{
    public class IdentityUserRequestEntityProfile : Profile
    {
        public IdentityUserRequestEntityProfile()
        {
            CreateMap<LoginRequest, IdentityUser>()
                .ForPath(x => x.Email, y => y.MapFrom(src => src.Email))
                .ForPath(x => x.PasswordHash, y => y.MapFrom(src => src.Password));

            CreateMap<RegisterRequest, IdentityUser>()
                .ForMember(x => x.UserName, y => y.MapFrom(src => src.UserName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(src => src.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(src => src.Email))
                .ForMember(x => x.PasswordHash, y => y.MapFrom(src => src.Password));

            CreateMap<ChangePasswordRequest, IdentityUser>();
        }
    }
}
