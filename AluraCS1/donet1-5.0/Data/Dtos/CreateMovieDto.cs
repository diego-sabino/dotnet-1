using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Data.Dtos
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "O campo Title é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo Director é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        [Required(ErrorMessage = "O campo Genre é obrigatório")]
        public string Genre { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duration { get; set; }
    }
}
