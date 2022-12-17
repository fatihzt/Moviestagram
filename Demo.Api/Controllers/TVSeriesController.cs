using Demo.Core.ApiKey;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.Discover;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Genres;
using TMDbLib.Objects.Search;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVSeriesController : ControllerBase
    {
        private readonly TMDbClient client=ApiKey.GetTMDbClient();
        [HttpGet("genre")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result=await client.GetTvGenresAsync();
            return Ok(result);  
        }
        //[HttpGet]
        //public IActionResult GetTVSeries(int genreid)
        //{
        //    var result = client.DiscoverTvShowsAsync(DiscoverTv);
            
        //    return Ok(result);
        //}

    }
}
