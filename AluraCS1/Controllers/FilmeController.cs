using System;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]

	public class FilmeController : ControllerBase
	{
		private static List<Filme> filmes = new List<Filme>();

		[HttpPost]

		public void AddFilme([FromBody] Filme filme)
		{
			filme.id += 1;
			filmes.Add(filme);
		}

		[HttpGet]

		public IEnumerable<Filme> RecuperaFilme()
		{
			return filmes;
		}
	}
}

