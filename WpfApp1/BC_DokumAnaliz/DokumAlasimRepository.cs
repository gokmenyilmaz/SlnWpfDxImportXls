using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BC_DokumKalite;

namespace WpfApp1.BC_DokumAnaliz
{
    public class DokumAlasimRepository
    {
        _DokumAnalizDbContext dc = new _DokumAnalizDbContext();

        public List<DokumAlasimSinir> DokumAnalizSinirlariGetir()
        {
            var sonuc = dc.DokumAlasimSinirlari.ToList();

            return sonuc;
        }

        internal void Kaydet()
        {
            dc.SaveChanges();
        }
    }
}
