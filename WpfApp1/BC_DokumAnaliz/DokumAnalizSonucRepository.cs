using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BC_DokumKalite;

namespace WpfApp1.BC_DokumAnaliz
{
    public class DokumAnalizSonucRepository
    {
        _DokumAnalizDbContext dc = new _DokumAnalizDbContext();
       
      

        public List<DokumAnalizSonuc> DokumAnalizSonuclariGetir(string tarihRangeText)
        {
            DateTime tarih = new DateTime();

            if (tarihRangeText == "1G") tarih = DateTime.Now.AddDays(-1);
            if (tarihRangeText == "5G") tarih = DateTime.Now.AddDays(-5);
            if (tarihRangeText == "1A") tarih = DateTime.Now.AddMonths(-1);
            if (tarihRangeText == "1Y") tarih = DateTime.Now.AddYears(-1);
            if (tarihRangeText == "5Y") tarih = DateTime.Now.AddYears(-5);


            var sonuc = dc.DokumAnalizSonuclari
                .Where(c => c.TarihSaat.Date >= tarih.Date)
                .AsNoTracking()
                .ToList();

            return sonuc;
        }


        public void Upsert_DokumAnalizSonuclar(ObservableCollection<DokumAnalizSonuc> analizSonuclar)
        {
            foreach (var item in analizSonuclar)
            {
                var satir = dc.DokumAnalizSonuclari
                  .Where(c => c.TarihSaat == item.TarihSaat)
                  .AsNoTracking()
                  .FirstOrDefault();


                if(satir==null) dc.DokumAnalizSonuclari.Add(item);
               
            }

            dc.SaveChanges();
        }

    }
}
