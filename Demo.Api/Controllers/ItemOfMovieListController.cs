using Demo.Business.Abstract;
using Demo.Business.Request.ItemOfList.IOLMovie;
using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOfMovieListController : ControllerBase
    {
        private readonly IItemOfMovieListService _itemOfMovieListService;
        public ItemOfMovieListController(IItemOfMovieListService itemOfMovieListService)
        {
            _itemOfMovieListService = itemOfMovieListService;
        }
        [HttpPost("AddMovieToList")]
        public IActionResult AddItem(IOLMovieCreateRequest dto)
        {
            ItemOfMovieList entity = new() { FavoriteListId= dto.FavoriteListId,MovieId=dto.MovieId};
            var result=_itemOfMovieListService.Add(entity);
            return Ok(result);
        }
        [HttpGet("ItemsByListId{listid}")]
        public IActionResult GetById(int listid) 
        {
            var result = _itemOfMovieListService.GetAll(f => f.FavoriteListId == listid);
            return Ok(result);
        }
    }
}
