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
    }
}
