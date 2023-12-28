using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Repository.Repositories
{
    //Core katmanında oluşturduğum IGenericRepository arabirimini, Repository katmanında uygulayacağım.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
           await _dbSet.AddRangeAsync(entities);
        }

        public IQueryable<T> GetAll()
        {
            //AsNoTracking() metodu, çekilen verilerin Entity Framework tarafından bellekte takip edilmemesini
            //ve değişikliklerin izlenmemesini sağlar. Bu özellik, performans açısından avantajlıdır, özellikle
            //büyük veri setleri ile çalışırken. Çünkü, AsNoTracking() kullanıldığında, çekilen veriler sadece
            //okunur ve bellekte bir önbelleğe alınmazlar. Bu durum, verilerin anlık durumlarını takip etmeye
            //gerek olmadığında performans kazancı sağlar.



            return _dbSet.AsNoTracking().AsQueryable();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
                
        }

        public void Remove(T entity)
        {
            // _context.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            // _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
