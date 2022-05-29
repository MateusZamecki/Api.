using Api.Comum.Repositorios;
using Api.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra.Repositorios.Implementacao
{
    public class RepositorioLancamento : RepositorioBase<Lancamento>, IRepositorioLancamento
    {
        public RepositorioLancamento(bool SaveChanges = true) : base(SaveChanges){}
    }
}
