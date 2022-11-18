using System;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]

	public class FilmeController : ControllerBase
	{
		private static List<Movie> movies = new List<Movie>();

		[HttpPost]

		public void CreateMovie([FromBody] Movie movie)
		{
            movie.id += 1;
            movies.Add(movie);
        }

        [HttpGet]

		public IEnumerable<Movie> GetAllMovies()
		{
			return movies;
		}

        [HttpGet("{id}")]

        public Movie GetMovieById(int id)
		{
			return movies.FirstOrDefault(movie => movie.id == id);
		}
	}
}

