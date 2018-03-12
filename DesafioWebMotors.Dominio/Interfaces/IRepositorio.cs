using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioWebMotors.Dominio.Interfaces
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity ObterPeloID(int ID);
        IQueryable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(int ID);
        int SalvarAlteracoes();
    }
}
