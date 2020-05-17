using AutoMapper;
using Infrastructure.Common;
using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(
            IMovieRepository movieRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailModel> AddAsync(MovieAddModel obj)
        {
            var entity = _mapper.Map<Movie>(obj);
            return _mapper.Map<MovieDetailModel>(await _movieRepository.AddAsync(entity));
        }

        public async Task<IEnumerable<MovieListModel>> GetAllAsync()
        {
            var entities = await _movieRepository.GetAllAsync();
            var models = _mapper.Map<List<MovieListModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<MovieListModel>> GetPagnedListAsync(
            string keyword, string orderBy, OrderType orderType, int page, int pageSize
            )
        {
            var entities = await _movieRepository.GetPagnedListAsync(keyword, orderBy, orderType, page, pageSize);
            var models = _mapper.Map<List<MovieListModel>>(entities);
            return models;
        }

        public async Task<MovieDetailModel> GetByIdAsync(string id)
        {
            var entity = await _movieRepository.GetByIdAsync(id);
            var model = _mapper.Map<MovieDetailModel>(entity);
            return model;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            return await _movieRepository.RemoveAsync(id);
        }

        public async Task<MovieDetailModel> UpdateAsync(string id, MovieUpdateModel obj)
        {
            var entity = _mapper.Map<Movie>(obj);
            return _mapper.Map<MovieDetailModel>(await _movieRepository.UpdateAsync(id, entity));
        }
    }
}
