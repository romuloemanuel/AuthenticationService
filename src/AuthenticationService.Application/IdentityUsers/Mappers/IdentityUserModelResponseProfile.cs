using AuthenticationService.Application.IdentityUsers.Responses;
using AuthenticationService.Domain.Models;
using AutoMapper;

namespace AuthenticationService.Application.IdentityUsers.Mappers
{
    public class IdentityUserModelResponseProfile : Profile
    {
        public IdentityUserModelResponseProfile()
        {
            CreateMap<TokenModel, TokenResponse>()
                .ForPath(x => x.Token, y => y.MapFrom(src => src.Token))
                .ForPath(x => x.Expiration, y => y.MapFrom(src => src.Expiration));
        }
    }
}
