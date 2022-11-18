using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        public int id { get; internal set; }
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

