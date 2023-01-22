using Demo.Business.Abstract;
using Demo.Business.Request.FavoriteList.CommentedFavoriteList;
using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentedFavoriteListController : ControllerBase
    {
        private readonly ICommentedFavoriteListService _commentedFavoriteListService;
        public CommentedFavoriteListController(ICommentedFavoriteListService commentedFavoriteListService)
        {
            _commentedFavoriteListService = commentedFavoriteListService;
        }
        [HttpPost("Comment")]
        public IActionResult Comment(CommentedFavoriteListCreateRequest dto)
        {
            CommentedFavoriteList entity = new() { UserId = dto.UserId, FavoriteListId = dto.FavoriteListId, CommentBody = dto.CommentBody };
            var result = _commentedFavoriteListService.Add(entity);
            return Ok(result);
        }
        [HttpGet("{favoriteListId}")]
        public IActionResult GetAll(int favoriteListId)
        {
            var result=_commentedFavoriteListService.GetAll(f=>f.FavoriteListId==favoriteListId);
            return Ok(result);
        }
        [HttpGet("getallcontentadmincontroller")]
        public IActionResult GetAll()
        {
            var result=_commentedFavoriteListService.GetAll();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _commentedFavoriteListService.Delete(new() { Id=id});
            return Ok(result);
        }
    }
}
