using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Comum.Repositorios
{
    public class RepositorioBase<TEntidade> where TEntidade : class
    {
        protected Contexto _contexto;
        public bool _salvarAlteracoes = true;
        public RepositorioBase(bool salvarAlteracoes = true)
        {
            _salvarAlteracoes = salvarAlteracoes;
            _contexto = new Contexto();
        }
        public TEntidade Alterar(TEntidade objeto)
        {
            _contexto.Entry(objeto).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            if (_salvarAlteracoes) _contexto.SaveChanges();
            return objeto;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public void Excluir(TEntidade objeto)
        {
            _contexto.Set<TEntidade>().Remove(objeto);
            if (_salvarAlteracoes) _contexto.SaveChanges();
        }

        public void Excluir(params object[] variavel)
        {
            var objeto = SelecionarPorId(variavel);
            Excluir(objeto);
        }

        public TEntidade Incluir(TEntidade objeto)
        {
            _contexto.Set<TEntidade>().Add(objeto);
            if (_salvarAlteracoes) _contexto.SaveChanges();
            return objeto;
        }

        public void SalvarAlteracoes()
        {
            _contexto.SaveChanges();
        }

        public TEntidade SelecionarPorId(params object[] variavel)
        {
            return _contexto.Set<TEntidade>().Find(variavel);
        }

        public List<TEntidade> SelecionarTodos()
        {
            return _contexto.Set<TEntidade>().ToList();
        }
    }
}
