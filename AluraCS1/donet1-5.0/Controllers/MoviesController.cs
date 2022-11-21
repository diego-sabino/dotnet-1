﻿using System;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MoviesApi.Data;

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

		public IActionResult CreateMovie([FromBody] Movie movie)
		{
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
				return Ok(movie);
			}
			return NotFound();
		}
	}
}

