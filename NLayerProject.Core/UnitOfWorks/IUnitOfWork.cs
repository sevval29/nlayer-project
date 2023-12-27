using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.UnitOfWorks
{
    //UnitOfWork tasarım deseni, farklı repositorylerde yapılan işlemleri tek bir transaction
    //bloğunda toplar ve veri tabanına yansıtır. Örneğin, UserRepository ve TeamRepository üzerinde
    //yapılan değişiklikler birlikte SaveChanges metotu çağırılana kadar Entity Framework Core
    //tarafından Memory’de tutulur,SaveChanges çağrıldığında ise veri tabanına yansır.

    //Eğer biri başarısız ise diğer repository üzerindeki değişiklikler de rollback yapılarak geri alınır.
    public interface IUnitOfWork
    {

        void Commit();
        Task CommitAsync();
    }
}
