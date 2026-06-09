using AutoMapper;
using TastivalFood.Application.Dtos;
using TastivalFood.Domain.Entities;

namespace TastivalFood.Application.Mappings
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.RestaurantTypeIds,
                    opt => opt.MapFrom(src => src.RestaurantTypes.Select(rt => rt.Id).ToList()));
        }
    }
}
