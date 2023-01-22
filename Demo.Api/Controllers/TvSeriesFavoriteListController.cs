using Demo.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvSeriesFavoriteListController : ControllerBase
    {
        private readonly ITvSeriesFavoriteListService _tvSeriesFavoriteListService;
        public TvSeriesFavoriteListController(ITvSeriesFavoriteListService tvSeriesFavoriteListService)
        {
            _tvSeriesFavoriteListService = tvSeriesFavoriteListService;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _tvSeriesFavoriteListService.Delete(new() { Id= id });
            return Ok(result);
        }
        [HttpGet("GetAllTvList")]
        public IActionResult GetAll()
        {
            var result=_tvSeriesFavoriteListService.GetAll();
            return Ok(result);
        }
    }
}
