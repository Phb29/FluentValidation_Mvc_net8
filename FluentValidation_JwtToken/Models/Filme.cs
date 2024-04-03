using System.ComponentModel.DataAnnotations;

namespace FluentValidation_JwtToken.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Diretor { get; set; }
        public int Ano { get; set; }
    }
}
