using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Models;


namespace Infrastructure.Mappings
{
    public class MovieProfile : Profile, IMappingProfile
    {
        public MovieProfile()
        {
            //response mapper
            CreateMap<Movie, MovieListModel>();

            //request mapper
            CreateMap<MovieAddModel, Movie>();

        }
    }
}
