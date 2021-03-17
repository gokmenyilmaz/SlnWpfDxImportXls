﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BC_DokumKalite;

namespace WpfApp1.BC_DokumAnaliz
{
    public class DokumAnalizRepository
    {
        _DokumAnalizDbContext dc = new _DokumAnalizDbContext();
       
      

        public List<DokumAnalizSonuc> DokumAnalizSonuclariGetir(DateTime date)
        {
            var sonuc = dc.DokumAnalizSonuclari
                .Where(c => c.TarihSaat.Date == date)
                .ToList();

            return sonuc;
        }
    }
}
