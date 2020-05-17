using Infrastructure.Common;
using Infrastructure.Entities;
using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IMovieService
    {
        Task<MovieDetailModel> AddAsync(MovieAddModel obj);
        Task<MovieDetailModel> UpdateAsync(string id, MovieUpdateModel obj);
        Task<bool> RemoveAsync(string id);
        Task<MovieDetailModel> GetByIdAsync(string id);
        Task<IEnumerable<MovieListModel>> GetAllAsync();
        Task<IEnumerable<MovieListModel>> GetPagnedListAsync(
            string keyword, string orderBy, OrderType orderType, int page, int pageSize
            );
    }
}
