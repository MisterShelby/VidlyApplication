using AutoMapper;
using VidlyApplication.Models;
using VidlyApplication.Dtos;

namespace VidlyApplication.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //dto to domain

            Mapper.CreateMap<CustomerDto, Customer>().
                ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>().
                ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}