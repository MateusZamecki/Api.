using Api.Comum.Repositorios;
using Api.Dominio;
using Api.Dominio.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra.Repositorios.Implementacao
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(bool SaveChanges = true) : base(SaveChanges){}
    }
}
