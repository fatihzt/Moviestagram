﻿using Demo.Core.ApiKey;
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
        private readonly TMDbClient client;
        public MovieController()
        {
            client = ApiKey.GetTMDbClient();
            client.DefaultLanguage= "en-US";
        }
        
        [HttpGet("genre")]
        public async Task<IActionResult> GetAllCategory()
        {
            
            var result = await client.GetMovieGenresAsync();
            return Ok(result);
        }
        [HttpGet("{genreid}/{pageno}")]
        public async Task<IActionResult> GetMovie(int genreid,int pageno)
        {
            
            var result = await client.GetGenreMoviesAsync(genreid,pageno);
            return Ok(result);
        }
        [HttpGet("Movie/GetPopular{pageno}")]
        public async Task<IActionResult> GetPopularMovie(int pageno)
        {
            
            var rsult=await client.GetMoviePopularListAsync(null,pageno);
            return Ok(rsult);
        }
        [HttpGet("Movie/Latest")]
        public async Task<IActionResult> GetLatestMovie()
        {
            
            var result = await client.GetMovieLatestAsync();
            return Ok(result);
        }
        [HttpGet("Movie/Upcoming{pageno}")]
        public async Task<IActionResult> GetUpcomingMovies(int pageno)
        {
            
            var result = await client.GetMovieUpcomingListAsync(null, pageno);
            return Ok(result);
        }
        [HttpGet("Search/{pageno}")]
        public async Task<IActionResult> FindMovie( string query,int pageno)
        {
            var result=await client.SearchMovieAsync(query,pageno);
            return Ok(result);
        }
        [HttpGet("MovieCastById{movieid}")]
        public async Task<IActionResult> GetCastByMovieId(int movieid)
        {
            var result = await client.GetMovieCreditsAsync(movieid);
            return Ok(result);
        }
        [HttpGet("GetMovieById{movieId}")]
        public async Task<IActionResult> GetMovieById(int movieId) 
        {
            var result=await client.GetMovieAsync(movieId);
            return Ok(result);  
        }
        [HttpGet("MovieTrailer{id}")]
        public async Task<IActionResult> getTrailer(int id)
        {
            var result = await client.GetMovieVideosAsync(id);
            
            return Ok(result.Results.FirstOrDefault(v => v.Type == "Trailer"));
           
        }
    }
}
