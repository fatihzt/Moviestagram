using Demo.Business.Abstract;
using Demo.Business.Request.FavoriteList.MovieList;
using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieFavoriteListController : ControllerBase
    {
        private readonly IMovieFavoriteListService _movieFavoriteListService;
        public MovieFavoriteListController(IMovieFavoriteListService movieFavoriteListService)
        {
            _movieFavoriteListService = movieFavoriteListService;
        }
        [HttpPost("Movie List Create")]
        public IActionResult CreateMovieList(MovieListCreateRequest dto)
        {//liste şeklinde id alırken sorun çıkıyor.
            MovieFavoriteList entity = new()
            {
                Name = dto.Name,
                UserId = dto.UserId,
                DateTime = dto.DateTime,
                MovieIds = dto.MovieIds,

            };
            _movieFavoriteListService.Add(entity);
            return Ok(entity);  
        }
    }
}
