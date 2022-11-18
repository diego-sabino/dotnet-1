using System;
using System.Data.Entity;

namespace AluraCS1.Data
{
	public class MovieContext : DbContext
	{
		public MovieContext(DbContextOptions<MovieContext> opt) : base (opt)
		{

		}
	}
}

