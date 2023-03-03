using Demo.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMovieFavoriteListService _movieFavoriteListService;
        private readonly ICommentedFavoriteListService _commentedFavoriteListService;
        public AdminController(IUserService userService, IMovieFavoriteListService movieFavoriteListService,ICommentedFavoriteListService commentedFavoriteListService)
        {
            _userService = userService;
            _movieFavoriteListService = movieFavoriteListService;
            _commentedFavoriteListService= commentedFavoriteListService;
        }
        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var result = _userService.GetAll();
            return Ok(result);
        }
        [HttpDelete("DeleteUserById{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool result = _userService.Delete(new() { Id= id });
            return Ok(result);
        }
        [HttpGet("GetAllComment")]
        public IActionResult GetAllComment()
        {
            var result = _commentedFavoriteListService.GetAll();
            return Ok(result);
        }
    }
}
