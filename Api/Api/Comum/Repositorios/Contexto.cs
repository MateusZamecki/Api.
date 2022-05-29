using Api.Dominio;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Comum.Repositorios
{
    public class Contexto : DbContext
    {
        public Contexto()
        {
        }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexaoTexto = new Conexao().Url();
            optionsBuilder.UseSqlServer(conexaoTexto);
        }
        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}
