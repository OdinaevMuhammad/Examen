using AutoMapper;
using Domain.Entities;
using Domain.Dtos;
namespace Infrastructure.Mapper;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Movie ,MovieDto>();
    }
}
