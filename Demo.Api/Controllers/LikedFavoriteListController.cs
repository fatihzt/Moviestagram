using Demo.Business.Abstract;
using Demo.Business.Request.FavoriteList.LikedFavoriteList;
using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedFavoriteListController : ControllerBase
    {
        private readonly ILikedFavoriteListService _likedFavoriteListService;
        public LikedFavoriteListController(ILikedFavoriteListService likedFavoriteListService)
        {
            _likedFavoriteListService = likedFavoriteListService;
        }
        [HttpPost("Like")]
        public IActionResult Like(LikedFavoriteListCreateRequest dto)
        {
            LikedFavoriteList entity = new() { UserId= dto.UserId,FavoriteListId=dto.FavoriteListId };
            var result=_likedFavoriteListService.Add(entity);
            return Ok(result);
        }
        [HttpGet("{favoriteListId}")]
        public IActionResult Get(int favoriteListId)
        {
            var result=_likedFavoriteListService.GetAll(c=>c.FavoriteListId==favoriteListId);
            return Ok(result);
        }
    }
}
