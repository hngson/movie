using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscapePlan.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<MovieListModel>> Get()
        {
            var data = await _movieService.GetAllAsync();
            return data;
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<MovieDetailModel> GetAsync(string id)
        {
            var data = await _movieService.GetByIdAsync(id);
            return data;
        }

        // POST: api/Movie
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
