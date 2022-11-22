using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Data.Dtos
{
    public class ReadMovieDto
    {
        [Key]
        [Required]
        public int id { get; internal set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime ConsultHour { get; set; }
    }
}
