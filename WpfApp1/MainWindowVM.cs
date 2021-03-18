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

        DokumAnalizSonucRepository repo = new DokumAnalizSonucRepository();

        DokumAlasimRepository repoAlasimSinir = new DokumAlasimRepository();

        public DelegateCommand DosyaSecCommand => new DelegateCommand(onDosyaSec);

        public DelegateCommand YenileCommand => new DelegateCommand(onYenile);

        DokumAnalizSonucRepository repoAnalizSonuc = new DokumAnalizSonucRepository();

        public DelegateCommand DbGuncelleCommand => new DelegateCommand(OnDbGuncelle);

        private void OnDbGuncelle()
        {
             repoAnalizSonuc.Upsert_DokumAnalizSonuclar(DokumAnalizSonucListe);
        }

        public DelegateCommand AlasimSinirFormGosterCommand => new DelegateCommand(OnAlasimSinirFormGoster);

        public DelegateCommand AlasimAnalizRaporGosterCommand => new DelegateCommand(OnAlasimAnalizRaporGoster);

        private void OnAlasimAnalizRaporGoster()
        {
            AlasimAnalizRaporView vw = new AlasimAnalizRaporView();
            AlasimAnalizSorguVM vm = new AlasimAnalizSorguVM();
            vw.DataContext = vm;

            vw.Show();
         
        }

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
            {
                VerileriYukle(AktifFileName);
                OnDbGuncelle();
            }
               
            else
                MessageBox.Show("Dosya seçiniz");
          
        }

        private void onDosyaSec()
        {
           //OpenFileDialog fd = new OpenFileDialog();
           //var sonuc=fd.ShowDialog();

           //if(sonuc==true)
           //{
           //     VerileriYukle(fd.FileName);
           //}


            var yol = @"\\192.168.1.204\PandaFile\Spektro";

            VerileriYukle(yol);

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

        public MainWindowVM()
        {
            DokumAnalizSonucListe = new ObservableCollection<DokumAnalizSonuc>();

            DokumAlasimSinirlari = repoAlasimSinir.DokumAnalizSinirlariGetir();

        }


       
    }
}
