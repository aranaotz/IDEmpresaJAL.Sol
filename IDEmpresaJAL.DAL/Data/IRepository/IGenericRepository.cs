using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);

        TEntity GetByGuid(Guid id);

        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string? includeProperties = null
            );

        TEntity GetFirstOrDefault(
             Expression<Func<TEntity, bool>>? filter = null,
            string? includeProperties = null
            );

        void Add(TEntity entity);

        void RemoveByID(int id);

        void RemoveByGuid(Guid id);

        void RemoveByEntity(TEntity entity);
    }
}
