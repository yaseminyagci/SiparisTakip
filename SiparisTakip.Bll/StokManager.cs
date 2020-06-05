using SiparisTakip.Dal.Abstract;
using SiparisTakip.Entities.Model;
using SiparisTakip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Bll
{
  public class StokManager:GenericManager<Stok>,IStokService
    {
        IStokRepository stokRepository;
        public StokManager(IStokRepository stokRepository):base(stokRepository)
        {
            this.stokRepository = stokRepository;
        }

        public List<Stok> StokListele(int StokGrubuId)
        {
            return stokRepository.StokListele(StokGrubuId);
        }
    }
}
