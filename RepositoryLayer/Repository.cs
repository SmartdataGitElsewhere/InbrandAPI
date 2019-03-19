using InbrandInterface;
using RepositoryLayer.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace RepositoryLayer
{
   public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        
        protected readonly DB db;
        public DbSet<TEntity> dbSet;
        public Repository(DB _db)
        {
            db = _db;
            dbSet = db.Set<TEntity>();
        }
       public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }
       public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate);
        }
       public TEntity Get(object Id)
        {
            return db.Set<TEntity>().Find(Id);
        }
       
        public async Task<TEntity> GetAsync(object Id)
        {
            return await db.Set<TEntity>().FindAsync(Id);
        }
        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }
       public void AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
        }

       public void Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
        }

       public void Remove(object Id)
        {
            TEntity entity = db.Set<TEntity>().Find(Id);
            db.Set<TEntity>().Remove(entity);
        }
       public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }
       public void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().Where(match).ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsyn()
        {
            return await db.Set<TEntity>().AsNoTracking().ToListAsync();
        }
    }
}
