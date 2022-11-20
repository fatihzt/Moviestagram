using Demo.Core.ApiKey;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("ActionMovie")]
        public async Task<IActionResult> GetActionMovie()
        {
            client.DefaultLanguage = "tr-TR";
            var result = await client.GetGenreMoviesAsync(28);
            return Ok(result);
        }
        [HttpGet("Movie/AnimationMovie")]
        public async Task<IActionResult> GetAnimationMovie()
        {
            client.DefaultLanguage = "tr-TR";
            var result = await client.GetGenreMoviesAsync(16);
            return Ok(result);
        }
    }
}
