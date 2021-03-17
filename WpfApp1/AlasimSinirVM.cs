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
    public class AlasimSinirVM:BindableBase
    {
        public DelegateCommand KaydetCommand => new DelegateCommand(OnKaydet, true);

        private void OnKaydet()
        {
            repo.Kaydet();
        }

        public List<DokumAlasimSinir> AlasimSinirlari 
        { 
            get => alasimSinirlari; set => SetProperty(ref alasimSinirlari ,value, "AlasimSinirlari"); 
        }

        DokumAlasimRepository repo = new DokumAlasimRepository();
        private List<DokumAlasimSinir> alasimSinirlari;

        public AlasimSinirVM()
        {
            AlasimSinirlari = new List<DokumAlasimSinir>();
            AlasimSinirlari =repo.DokumAnalizSinirlariGetir();



        }


    }
}
