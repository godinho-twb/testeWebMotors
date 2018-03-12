using DesafioWebMotors.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioWebMotors.Infra.Repositorio
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected readonly Contexto Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repositorio(Contexto contexto)
        {
            Db = contexto;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual TEntity ObterPeloID(int ID)
        {
            return DbSet.Find(ID);
        }

        public virtual IQueryable<TEntity> ObterTodos()
        {
            return DbSet;
        }

        public virtual void Remover(int ID)
        {
            DbSet.Remove(DbSet.Find(ID));
        }

        public virtual int SalvarAlteracoes()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
