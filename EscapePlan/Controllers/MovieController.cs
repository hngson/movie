using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Common;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscapePlan.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(
            IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET: api/Movie
        [HttpGet]
        public async Task<IEnumerable<MovieListModel>> GetAsync()
        {
            var data = await _movieService.GetAllAsync();
            return data;
        }

        // GET: api/Movie
        [HttpGet("search")]
        public async Task<IEnumerable<MovieListModel>> GetPagnedListAsync(
            string keyword, string orderBy, OrderType orderType, int page, int pageSize
            )
        {
            var data = await _movieService.GetPagnedListAsync(keyword, orderBy, orderType, page, pageSize);
            return data;
        }

        // GET: api/Movie/id
        [HttpGet("{id}")]
        public async Task<MovieDetailModel> GetByIdAsync(string id)
        {
            var data = await _movieService.GetByIdAsync(id);
            return data;
        }

        // POST: api/Movie
        [HttpPost]
        public void AddMovie([FromBody] MovieAddModel model)
        {

        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _movieService.RemoveAsync(id);
        }
    }
}
