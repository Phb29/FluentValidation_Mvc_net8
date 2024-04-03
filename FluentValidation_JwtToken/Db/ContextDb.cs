using FluentValidation_JwtToken.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentValidation_JwtToken.Db
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }
        public DbSet<Filme>Filmes { get; set; }
    }
}

