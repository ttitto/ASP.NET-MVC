namespace Ttitter.Data.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface ITtitterRepository<T> where T: class
    {
        IQueryable<T> All();

        T Find(object Id);

        IQueryable<T> Search(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        void Update(T entity);

        void Update(object Id);

        T Delete(object Id);

        T Delete(T entity);

        void Detach(T entity);

        void Attach(T entity);

        int SaveChanges();
    }
}
