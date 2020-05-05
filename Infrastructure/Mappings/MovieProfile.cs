using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Models;


namespace Infrastructure.Mappings
{
    public class MovieProfile : Profile, IMappingProfile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieListModel>();
        }
    }
}
