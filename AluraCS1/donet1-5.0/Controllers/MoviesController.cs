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
		[HttpPost]

		public IActionResult CreateMovie([FromBody] Movie movie)
		{
			return CreatedAtAction(nameof(GetMovieById), new { Id = movie.id }, movie);
        }

        [HttpGet]

		public IActionResult GetAllMovies()
		{
			return Ok();
		}

        [HttpGet("{id}")]

        public IActionResult GetMovieById(int id)
		{
			Movie movie = .FirstOrDefault(movie => movie.id == id);

			if (movie != null)
			{
				return Ok(movie);
			}
			return NotFound();
		}
	}
}

