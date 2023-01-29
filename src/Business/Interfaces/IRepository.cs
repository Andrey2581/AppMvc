using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    //implementar Repositorio generico - oferece todos os metodos necessario para as entidades
    //Dispose - libera memoria
    //trabalhar com metodos async para melhor performace
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {

        Task Adiionar(TEntity entity);
        Task <TEntity> ObterPorId(Guid id);
        Task <List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
