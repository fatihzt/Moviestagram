using Demo.Business.Abstract;
using Demo.Business.Request.FavoriteList.MovieList;
using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("CreationMovieList")]
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
        [HttpGet("GetListByUserId{userId}")]
        public IActionResult GetListById(int userId)
        {
            var result=_movieFavoriteListService.GetAll(l=>l.UserId == userId,path=>path.Include(l=>l.User));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _movieFavoriteListService.Delete(new() { Id= id });
            return Ok(result);
        }
        [HttpGet("GetAllMovieList")]
        public IActionResult GetAll()
        {
            var result=_movieFavoriteListService.GetAll();
            return Ok(result);
        }

    }
}
