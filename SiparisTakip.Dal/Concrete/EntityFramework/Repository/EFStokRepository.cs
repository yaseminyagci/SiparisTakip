using SiparisTakip.Dal.Abstract;
using SiparisTakip.Dal.Concrete.EntityFramework.Context;
using SiparisTakip.Dal.Concrete.EntityFramework.Repository;
using SiparisTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Dal.Concrete.EntityFramework.Repository
{
    public class EFStokRepository : EFGenericRepository<Stok>, IStokRepository
    {
        public EFStokRepository() :base(){
          //  context = new EFSiparisTakipContext();
        }
        public List<Stok> StokListele(int StokGrubuId)
        {
            return context.Stok.Where(x => x.StokGrubuID == StokGrubuId).ToList();
        }
    }
}
