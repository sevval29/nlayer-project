using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IService<T> where T : class

    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task <T> AddAsync(T entity);
        Task <IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        //Repository’de void olarak belirtilen Update ve Remove işlemleri; Servis Katmanı’nda kullanılıp veri
        //tabanına yansıtma işlemi gerçekleşeceği için IService içerisinde Task döndürmeli ve asenkron şekilde yazılmalıdır.
        //Bu nedenle, Update ve Remove metotları UpdateAsync ve RemoveAsync olarak güncellenmelidir. Bu şekilde, asenkron
        //bir yapıda çalışarak işlemleri daha verimli bir şekilde gerçekleştirilebilir.


        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);


    }
}
