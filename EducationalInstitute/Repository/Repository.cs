using EducationalInstitute.Data;
using EducationalInstitute.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EducationalInstitute.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly EducationalInstituteContext _Context;
        internal DbSet<T> dbSet;
        public Repository(EducationalInstituteContext Context)
        {
            _Context = Context;
            this.dbSet = _Context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
