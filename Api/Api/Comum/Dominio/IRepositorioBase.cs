using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Comum.Dominio
{
    public interface IRepositorioBase<T> where T : class
    {
        List<T> SelecionarTodos();
        T SelecionarPorId(params object[] variavel);
        T Adicionar(T objeto);
        T Alterar(T objeto);
        void Excluir(T objeto);
        void Excluir(params object[] variavel);
        void SalvarAlteracoes();
    }
}
