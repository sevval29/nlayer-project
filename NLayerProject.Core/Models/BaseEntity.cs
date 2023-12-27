using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Models
{
    //neden abstract class kullandık?
    //- temel nedeni bu sınıfın kendi başına bir örneği oluşturulmuyor.
    //-Yalnızca türetilmiş sınıflar trfdan genişletilmiş bir şekilde kullanılıyor. bu yüzden soyut bir sınıf  kullanılıyor.
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
