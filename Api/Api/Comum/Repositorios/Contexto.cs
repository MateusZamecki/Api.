using Api.Dominio;
using Api.Dominio.Usuarios;
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
            var conexaoTexto = Conexao.Url();
            optionsBuilder.UseSqlServer(conexaoTexto);
        }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Salario> Salarios { get; set; }
    }
}
