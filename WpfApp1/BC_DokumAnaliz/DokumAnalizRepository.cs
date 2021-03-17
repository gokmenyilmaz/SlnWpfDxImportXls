using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BC_DokumKalite;

namespace WpfApp1.BC_DokumAnaliz
{
    public class DokumAnalizRepository
    {
        DokumAnalizDbContext dc = new DokumAnalizDbContext();
       
        public List<DokumAlasimSinir> DokumAnalizSinirlariGetir()
        {
            var sonuc=dc.DokumAlasimSinirlari.ToList();

            return sonuc;
        }


        public List<DokumAnalizSonuc> DokumAnalizSonuclariGetir(DateTime date)
        {
            var sonuc = dc.DokumAnalizSonuclari
                .Where(c => c.TarihSaat.Date == date)
                .ToList();

            return sonuc;
        }
    }
}
