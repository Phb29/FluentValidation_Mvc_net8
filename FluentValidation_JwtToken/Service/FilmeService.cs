using FluentValidation;
using FluentValidation_JwtToken.Db;
using FluentValidation_JwtToken.Models;
using FluentValidation_JwtToken.Validator;
using Microsoft.EntityFrameworkCore;

namespace FluentValidation_JwtToken.Service
{

    public class FilmeService : IFilme
    {
        private readonly ContextDb _context;
        private readonly FilmeValidator _validator;
        public FilmeService(ContextDb context, FilmeValidator validation)
        {
            _context = context;
            _validator = validation;
        }
        public async Task AdicionarFilme(Filme filme)
        {
            await _validator.ValidateAndThrowAsync(filme);
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarFilme(Filme filme)
        {
           // var filmeExistente = await _context.Filmes.FindAsync(filmeAtualizado.Id);

           // if (filmeExistente == null)
           // {
           //     throw new InvalidOperationException("Filme não encontrado.");
           // }

           // Atualizar propriedades do filme existente com as do filme atualizado

           //filmeExistente.Titulo = filmeAtualizado.Titulo;
           // filmeExistente.Diretor = filmeAtualizado.Diretor;
           // filmeExistente.Ano = filmeAtualizado.Ano;

           // Salvar as mudanças no banco de dados
           // await _context.SaveChangesAsync();
            _context.Entry(filme).State= EntityState.Modified;
                await _context.SaveChangesAsync();
        }

        public async Task<Filme> BuscaFilmePorId(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            return filme! == null ? throw new InvalidOperationException("pessoa não encontrada") : filme;
        }

        public async Task<List<Filme>> ObterTodosFilmes()
        {
            return await _context.Filmes.ToListAsync();
        }

        public Filme Remove(int? id)
        {
            var delete = _context.Filmes.FirstOrDefault(d => d.Id == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return delete;
        }
    }
}
