using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BC_DokumKalite;

namespace WpfApp1
{
    public class Utils
    {
        public static string AlasimHataGetir(string alasim, string elementName, decimal? sonucDeger, List<DokumAlasimSinir> dokumAlasimSinirlari)
        {
            var alasimSinirlari = dokumAlasimSinirlari.FirstOrDefault(c => c.Alasim == alasim);

            if (alasimSinirlari == null) return "Alaşım Yok";

            if (sonucDeger == null) return "Değer Yok";


            var min = alasimSinirlari.GetType().GetProperty(elementName + "Min").GetValue(alasimSinirlari);
            var max = alasimSinirlari.GetType().GetProperty(elementName + "Max").GetValue(alasimSinirlari);

            var d_min = (decimal)min;
            var d_max = (decimal)max;

            var hatali = sonucDeger < d_min || sonucDeger > d_max;

            return hatali == true ? $"[{min}-{max}]" : "";

        }
    }
}
