using FluentValidation_JwtToken.Models;

namespace FluentValidation_JwtToken.Service
{
    public interface IFilme
    {
         Task<List<Filme>> ObterTodosFilmes();
         Task AdicionarFilme(Filme filme);
         Filme Remove(int? id);
         Task<Filme> BuscaFilmePorId(int id);
         Task AtualizarFilme(Filme filme);
    }
}
