using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repositories
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();
        //T entity Bool da dönüş 
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        //0dan bir nesne eklerken async yaptık çünkü contexte hiçbir karşılığı yok
        Task AddAsync(T entity);

        Task AddRangeAsync (IEnumerable<T> entities);

        //zaten olan bir şeyi güncellediğimiz için async metod olmasına  gerek yok
        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}
