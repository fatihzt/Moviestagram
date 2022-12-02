using Demo.Core.ApiKey;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TMDbLib.Client;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly TMDbClient client =ApiKey.GetTMDbClient();
        [HttpGet("genre")]
        public async Task<IActionResult> GetAllCategory()
        {
            client.DefaultLanguage = "tr-TR";
            var result = await client.GetMovieGenresAsync();
            return Ok(result);
        }
        [HttpGet("{genreid}/{pageno}")]
        public async Task<IActionResult> GetActionMovie(int genreid,int pageno)
        {
            client.DefaultLanguage = "tr-TR";
            var result = await client.GetGenreMoviesAsync(genreid,pageno);
            return Ok(result);
        }
        
    }
}
