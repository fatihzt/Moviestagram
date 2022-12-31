using Demo.Business.Abstract;
using Demo.Entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMovieFavoriteListService _movieFavoriteListService;
        public AdminController(IUserService userService, IMovieFavoriteListService movieFavoriteListService)
        {
            _userService = userService;
            _movieFavoriteListService = movieFavoriteListService;
        }
        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var result = _userService.GetAll();
            return Ok(result);
        }
    }
}
