using SiparisTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Dal.Abstract
{
   public interface IStokRepository:IGenericRepository<Stok>
    {
        //stok ile ilgili özzel bir işlem yapılacaksa burayı oluştururuz.
        List<Stok> StokListele(int StokGrubuId);
    }
}
