using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BC_DokumAnaliz;
using WpfApp1.BC_DokumKalite;

namespace WpfApp1
{
    public class AlasimAnalizSorguVM : BindableBase
    {
        public List<DokumAnalizSonuc> DokumAnalizSonucListe { get => dokumAnalizSonucListe; 
            set => SetProperty(ref dokumAnalizSonucListe ,value, "DokumAnalizSonucListe"); }

        public DelegateCommand<string> SorgulaCommand => new DelegateCommand<string>(OnSorgula);

        public List<DokumAlasimSinir> DokumAlasimSinirlari { get; }

        private void OnSorgula(string obj)
        {
            DokumAnalizSonucListe = repo.DokumAnalizSonuclariGetir(obj);

            SinirHatalariYukle();
        }

        private void SinirHatalariYukle()
        {
            foreach (var item in DokumAnalizSonucListe)
            {
                item.Si_Err = Utils.AlasimHataGetir(item.Alasim, "Si", item.Si, DokumAlasimSinirlari);
                item.Fe_Err = Utils.AlasimHataGetir(item.Alasim, "Fe", item.Fe, DokumAlasimSinirlari);
                item.Cu_Err = Utils.AlasimHataGetir(item.Alasim, "Cu", item.Cu, DokumAlasimSinirlari);

                item.Mn_Err = Utils.AlasimHataGetir(item.Alasim, "Mn", item.Mn, DokumAlasimSinirlari);
                item.Mg_Err = Utils.AlasimHataGetir(item.Alasim, "Mg", item.Mg, DokumAlasimSinirlari);
                item.Ti_Err = Utils.AlasimHataGetir(item.Alasim, "Ti", item.Ti, DokumAlasimSinirlari);
                item.Zn_Err = Utils.AlasimHataGetir(item.Alasim, "Zn", item.Zn, DokumAlasimSinirlari);
                item.Al_Err = Utils.AlasimHataGetir(item.Alasim, "Al", item.Al, DokumAlasimSinirlari);
            }
        }

        DokumAnalizSonucRepository repo = new DokumAnalizSonucRepository();
        DokumAlasimRepository repoAlasimSinir = new DokumAlasimRepository();

        private List<DokumAnalizSonuc> dokumAnalizSonucListe;

        public AlasimAnalizSorguVM()
        {
            DokumAlasimSinirlari = repoAlasimSinir.DokumAnalizSinirlariGetir();
        }
    }
}
