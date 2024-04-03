using FluentValidation;
using FluentValidation_JwtToken.Models;

namespace FluentValidation_JwtToken.Validator
{
    public class FilmeValidator:AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(filme => filme.Diretor).NotEmpty().WithMessage("Diretor Obrigatório").Length(2, 50).WithMessage("O Diretor deve ter entre 2 e 50 caracteres.");
            RuleFor(filme => filme.Titulo).NotEmpty().WithMessage("Titulo Obrigatório").Length(2, 50).WithMessage("O Titulo deve ter entre 2 e 50 cracteres.");
            RuleFor(filme => filme.Ano).NotEmpty().WithMessage("Ano Obrigatório")
                .InclusiveBetween(1800, DateTime.Now.Year).WithMessage("O ano deve estar entre 1800 e 2024");
        }
    }
}
