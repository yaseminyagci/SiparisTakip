using SiparisTakip.Dal.Abstract;
using SiparisTakip.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Dal.Concrete.EntityFramework.Repository
{
   public class EFCariRepository:EFGenericRepository<Cari>, ICariRepository
    {
        public EFCariRepository():base() {
            //context = new Context.EFSiparisTakipContext();
        }

        public List<Cari> CariHesapEkstresi(int cariId)
        {
           
            return context.Cari.Where(x=>x.CariID==cariId).ToList();
        }
    }
}
