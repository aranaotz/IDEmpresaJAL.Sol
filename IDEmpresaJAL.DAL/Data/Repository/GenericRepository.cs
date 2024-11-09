using IDEmpresaJAL.DAL.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _dbContext;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            this._dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string? includeProperties = null)
        {
            //se crea una consulta Iqueryble a partir del dbset
            IQueryable<TEntity> query = _dbSet;

            //se aplica filtro si se proporciona
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //se incliyen propiedades si se proporcionan
            if (includeProperties != null)
            {
                //se divide la cadena de propiedades por coma y se itera sobre ellas
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(property);
                }
            }

            //Se aplica ordenamiento si se proporciona
            if (orderBy != null)
            {
                //se ejecuta la función de ordenamiento y se convierta la consulta en una lista
                return orderBy(query).ToList();
            }

            //si no se proporciona ordenamiento simplemente se convierte la consulta en una lista
            return query.ToList();
        }

        public TEntity GetByGuid(Guid id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null)
        {
            //se crea una consulta iqueryble a partir del dbset del contexto
            IQueryable<TEntity> query = _dbSet;

            //se aplica el filtro si se proporciona
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Se incluyen propiedades de navegación si se proporcionan
            if (includeProperties != null)
            {
                //se divide la cadena de propiedades por coma y se itera sobre ellas
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public void RemoveByEntity(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveByGuid(Guid id)
        {
            TEntity entityToRemove = _dbSet.Find(id);
            _dbSet.Remove(entityToRemove);
        }

        public void RemoveByID(int id)
        {
            TEntity entityToRemove = _dbSet.Find(id);
            _dbSet.Remove(entityToRemove);
        }
    }
}
