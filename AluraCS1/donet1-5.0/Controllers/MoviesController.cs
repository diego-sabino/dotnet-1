using System;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]

	public class FilmeController : ControllerBase
	{
		private static List<Movie> movies = new List<Movie>();
		private static int id = 1;	

		[HttpPost]

		public IActionResult CreateMovie([FromBody] Movie movie)
		{
            movie.id = id ++;
            movies.Add(movie);
			return CreatedAtAction(nameof(GetMovieById), new { Id = movie.id }, movie);
        }

        [HttpGet]

		public IActionResult GetAllMovies()
		{
			return Ok(movies);
		}

        [HttpGet("{id}")]

        public IActionResult GetMovieById(int id)
		{
			Movie movie = movies.FirstOrDefault(movie => movie.id == id);

			if (movie != null)
			{
				return Ok(movie);
			}
			return NotFound();
		}
	}
}

