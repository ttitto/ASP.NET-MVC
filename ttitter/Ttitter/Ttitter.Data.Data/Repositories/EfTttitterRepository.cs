namespace Ttitter.Data.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class EfTttitterRepository<T> : ITtitterRepository<T> where T : class
    {
        
        private DbContext context;
        private IDbSet<T> set;

        public EfTttitterRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.set.Where(predicate);
        }

        public T Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            return entity;
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Update(object id)
        {
            var entity = this.Find(id);
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(object Id)
        {
            var entity = this.Find(Id);
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        public void Attach(T entity)
        {
            this.set.Attach(entity);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
