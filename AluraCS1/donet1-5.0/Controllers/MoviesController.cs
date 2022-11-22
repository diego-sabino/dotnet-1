using System;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;

namespace MoviesAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]

	public class FilmeController : ControllerBase
	{
		private MovieContext _context;

        public FilmeController(MovieContext context)
        {
			_context = context;
        }

		[HttpPost]

		public IActionResult CreateMovie([FromBody] CreateMovieDto movieDto)
		{
			Movie movie = new Movie
			{
				Title = movieDto.Title,
				Genre = movieDto.Genre,
				Duration = movieDto.Duration,
				Director = movieDto.Director
			};

			_context.Movies.Add(movie);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetMovieById), new { Id = movie.id }, movie);
        }

        [HttpGet]

		public IActionResult GetAllMovies()
		{
			return Ok(_context.Movies);
		}

        [HttpGet("{id}")]

        public IActionResult GetMovieById(int id)
		{
			Movie movie = _context.Movies.FirstOrDefault(movie => movie.id == id);

			if (movie != null)
			{
				ReadMovieDto movieDto = new ReadMovieDto
				{
					id = movie.id,
					Title = movie.Title,
					Genre = movie.Genre,
					Duration = movie.Duration,
					Director = movie.Director,
					ConsultHour = DateTime.Now,
				};
				return Ok(movieDto);
			}
			return NotFound();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateMovie(int id, [FromBody] ReadMovieDto movieDto)
        {
			Movie movie = _context.Movies.FirstOrDefault(movie => movie.id == id);
			if (movie == null)
            {
				return NotFound();
            }
			movie.Title = movieDto.Title;
			movie.Director = movieDto.Director;
			movie.Genre = movieDto.Genre;
			movie.Duration = movieDto.Duration;
			_context.SaveChanges();
			return NoContent();
        }

		[HttpDelete("{id}")]
		public IActionResult DeleteMovie(int id)
        {
			Movie deletedMovie = _context.Movies.FirstOrDefault(movie => movie.id == id);
			if (deletedMovie == null)
            {
				return NotFound();
            }
			_context.Remove(deletedMovie);
			_context.SaveChanges();
			return NoContent();
		}
	}
}

