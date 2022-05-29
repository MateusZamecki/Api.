using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Comum.Dominio
{
    public interface IRepositorioBase<T> where T : class
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        T ObterPor(int id);
        IEnumerable<T> ObterTodos();
        //IEnumerable<T> ObterPor(ISpecification<T> specification);
        void Remover(T entidade);
        void Sincronizar(T entidade);
    }
}
