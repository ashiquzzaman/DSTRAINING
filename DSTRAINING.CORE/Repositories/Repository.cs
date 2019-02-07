using DSTRAINING.WEB.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DSTRAINING.WEB.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private static ApplicationDbContext _context = new ApplicationDbContext();//UnitOfWork
        DbSet<T> _dbSet = _context.Set<T>();//Repository
        public IQueryable<T> All()
        {

            return _dbSet.AsQueryable();
        }
        public List<T> GetAll()
        {

            return _dbSet.ToList();
        }
        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Create(T item)
        {
            //  var addedEntries = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();

            _dbSet.Add(item);
            _context.SaveChanges();
            return item;
        }
        public int Update(T item)
        {

            _context.Entry(item).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public void Delete(T item)
        {

            _dbSet.Remove(item);
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}