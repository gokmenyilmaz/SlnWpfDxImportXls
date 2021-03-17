using DevExpress.Mvvm;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Spreadsheet;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.BC_DokumKalite;
using WpfApp1.BC_DokumAnaliz;

namespace WpfApp1
{
   public class MainWindowVM
    {
        public ObservableCollection<DokumAnalizSonuc> DokumAnalizSonucListe { get; set; }
        public List<DokumAlasimSinir> DokumAlasimSinirlari { get; }

        DokumAnalizRepository repo = new DokumAnalizRepository();

        DokumAlasimRepository repoAlasimSinir = new DokumAlasimRepository();

        public DelegateCommand DosyaSecCommand => new DelegateCommand(onDosyaSec);

        public DelegateCommand YenileCommand => new DelegateCommand(onYenile);

        public DelegateCommand AlasimSinirFormGosterCommand => new DelegateCommand(OnAlasimSinirFormGoster);

        private void OnAlasimSinirFormGoster()
        {

            AlasimSinirView vw = new AlasimSinirView();
            AlasimSinirVM vm = new AlasimSinirVM();
            vw.DataContext = vm;

            vw.Show();
        }

        public string AktifFileName { get; set; }

        private void onYenile()
        {
            if (!String.IsNullOrEmpty(AktifFileName))
                VerileriYukle(AktifFileName);
            else
                MessageBox.Show("Dosya seçiniz");
          
        }

        private void onDosyaSec()
        {
           OpenFileDialog fd = new OpenFileDialog();
           var sonuc=fd.ShowDialog();

           if(sonuc==true)
           {
                VerileriYukle(fd.FileName);
           }

            AktifFileName = fd.FileName;

        }

        private void VerileriYukle(string fileName)
        {
            DokumAnalizSonucListe.Clear();

            Workbook workbook = new Workbook();
            workbook.LoadDocument(fileName);


            var ws = workbook.Worksheets[0];


            var usedRange = ws.GetUsedRange();

            for (int i = 2; i < usedRange.RowCount; i++)
            {
                var tarih = DateTime.Parse(ws.Cells[i, 0].Value.ToString());
                var bolge = ws.Cells[i, 1].Value.ToString();
                var elemanSayisi = int.Parse(ws.Cells[i, 2].Value.ToString());
                var bobinNo = ws.Cells[i, 2].Value.ToString();

                //Si Fe	Cu	Mn Mg Ti Zn Al

                var Si = decimal.Parse(ws.Cells[i, 8].Value.ToString());
                var Fe = decimal.Parse(ws.Cells[i, 15].Value.ToString());
                var Cu = decimal.Parse(ws.Cells[i, 17].Value.ToString());

                var Mn = decimal.Parse(ws.Cells[i, 14].Value.ToString());
                var Mg = decimal.Parse(ws.Cells[i, 7].Value.ToString());
                var Ti = decimal.Parse(ws.Cells[i, 11].Value.ToString());

                var Zn = decimal.Parse(ws.Cells[i, 18].Value.ToString());
                var Al = decimal.Parse(ws.Cells[i, 26].Value.ToString());

                var s1 = new DokumAnalizSonuc 
                { 
                    TarihSaat =tarih,
                    Bolge = bolge.Split('-')[0].Trim(),
                    DokumHatti=bolge.Split('-')[1].Trim(),
                    Alasim=bolge.Split('-')[2].Trim(),
                    BobinNo=bobinNo,
                    Si=Si,
                    Fe=Fe,
                    Cu = Cu,

                    Mn = Mn,
                    Mg=Mg,
                    Ti=Ti,

                    Zn=Zn,
                    Al=Al

                };

                DokumAnalizSonucListe.Add(s1);
               
            }

         
            workbook.Dispose();


            SinirHatalariYukle();
        }

        private void SinirHatalariYukle()
        {
            foreach (var item in DokumAnalizSonucListe)
            {
                item.Si_Err = AlasimHataGetir(item.Alasim, "Si", item.Si);
                item.Fe_Err = AlasimHataGetir(item.Alasim, "Fe", item.Fe);
                item.Cu_Err = AlasimHataGetir(item.Alasim, "Cu", item.Cu);

                item.Mn_Err = AlasimHataGetir(item.Alasim, "Mn", item.Mn);
                item.Mg_Err = AlasimHataGetir(item.Alasim, "Mg", item.Mg);
                item.Ti_Err = AlasimHataGetir(item.Alasim, "Ti", item.Ti);
                item.Zn_Err = AlasimHataGetir(item.Alasim, "Zn", item.Zn);
                item.Al_Err = AlasimHataGetir(item.Alasim, "Al", item.Al);
            }
        }

        public MainWindowVM()
        {
            DokumAnalizSonucListe = new ObservableCollection<DokumAnalizSonuc>();

            DokumAlasimSinirlari = repoAlasimSinir.DokumAnalizSinirlariGetir();

        }


        public string AlasimHataGetir(string alasim, string elementName, decimal sonucDeger)
        {
            var alasimSinirlari = DokumAlasimSinirlari.FirstOrDefault(c => c.Alasim == alasim);

            if(alasimSinirlari==null)  return "Alaşım Yok";

            var min= alasimSinirlari.GetType().GetProperty(elementName + "Min").GetValue(alasimSinirlari);
            var max = alasimSinirlari.GetType().GetProperty(elementName + "Max").GetValue(alasimSinirlari);

            var d_min = (decimal)min;
            var d_max = (decimal)max;

            var hatali = sonucDeger < d_min || sonucDeger > d_max;

            return hatali==true?$"[{min}-{max}]":"";

        }
    }
}
