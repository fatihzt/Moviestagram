using Demo.Business.Abstract;
using Demo.Business.Request.ItemOfList.IOLTv;
using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOfTvListController : ControllerBase
    {
        private readonly IItemOfTvListService _itemOfTvListService;
        public ItemOfTvListController(IItemOfTvListService itemOfTvListService)
        {
            _itemOfTvListService = itemOfTvListService;
        }
        [HttpPost("AddItemOnList")]
        public IActionResult AddItem(IOLTvCreateRequest dto)
        {
            ItemOfTvList entity = new() { FavoriteListId= dto.FavoriteListId,TvId=dto.TvId };
            var result=_itemOfTvListService.Add(entity);
            return Ok(result);
        }
        [HttpGet("GetItemByListId{id}")]
        public IActionResult GetItemByListId(int id)
        {
            var result=_itemOfTvListService.GetAll(i=>i.FavoriteListId==id);
            return Ok(result);
        }
    }
}
