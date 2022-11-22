using System;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using AutoMapper;

namespace MoviesAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]

	public class FilmeController : ControllerBase
	{
		private MovieContext _context;
		private IMapper _mapper;

        public FilmeController(MovieContext context, IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
        }

		[HttpPost]

		public IActionResult CreateMovie([FromBody] CreateMovieDto movieDto)
		{
			Movie movie = _mapper.Map<Movie>(movieDto);

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
				ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
				return Ok(movieDto);
			}
			return NotFound();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
			Movie movie = _context.Movies.FirstOrDefault(movie => movie.id == id);
			if (movie == null)
            {
				return NotFound();
            }
			_mapper.Map(movieDto, movie);
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

