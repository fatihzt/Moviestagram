﻿using Demo.Core.ApiKey;
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
        [HttpGet("{genreid}/{pageno}")]
        public async Task<IActionResult> GetTVSeries(int genreid,int pageno)
        {
            var result = client.DiscoverTvShowsAsync().WhereGenresInclude(new List<int>() { genreid });
            SearchContainer<SearchTv> container = await result.Query("tr-TR", pageno);

            return Ok(container.Results);
        }
        [HttpGet("Popular{pageno}")]
        public async Task<IActionResult> GetPopularTv(int pageno)
        {
            var result = await client.GetTvShowPopularAsync(pageno);
            return Ok(result);
        }
        [HttpGet("Tv/Latest")]
        public async Task<IActionResult> GetLatestTv()
        {
            var result=await client.GetLatestTvShowAsync();
            return Ok(result);
        }
        [HttpGet("Search/{pageno}")]
        public async Task<IActionResult> FindTvShow( string query, int pageno)
        {
            var result=await client.SearchTvShowAsync(query, pageno);
            return Ok(result);
        }
        [HttpGet("CastByTvId{tvId}")]
        public async Task<IActionResult>UpcomingTv(int tvId)
        {
            var result=await client.GetTvShowCreditsAsync(tvId);
            return Ok(result);
        }
        [HttpGet("TvById{tvId}")]
        public async Task<IActionResult>GetTvById(int tvId)
        {
            var result = await client.GetTvShowAsync(tvId);
            return Ok(result);
        }
        

    }
}
