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

namespace WpfApp1
{
   public class MainWindowVM
    {
        public ObservableCollection<SpectroSonucModel> SpektroSonucListe { get; set; }

        public DelegateCommand DosyaSecCommand => new DelegateCommand(onDosyaSec);

        public DelegateCommand YenileCommand => new DelegateCommand(onYenile);

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
            SpektroSonucListe.Clear();

            Workbook workbook = new Workbook();
            workbook.LoadDocument(fileName);


            var ws = workbook.Worksheets[0];


            var usedRange = ws.GetUsedRange();

            for (int i = 2; i < usedRange.RowCount; i++)
            {
                var tarih = DateTime.Parse(ws.Cells[i, 0].Value.ToString());
                var bolge = ws.Cells[i, 1].Value.ToString();
                var elemanSayisi = int.Parse(ws.Cells[i, 2].Value.ToString());


                //Li Be	B	Na	Mg	Si	P	Ca	Ti	V	Cr	Mn	Fe	Ni	Cu


                var Li =decimal.Parse(ws.Cells[i, 3].Value.ToString());
                var Be = decimal.Parse(ws.Cells[i, 4].Value.ToString());
                var B = decimal.Parse(ws.Cells[i, 5].Value.ToString());
                var Na = decimal.Parse(ws.Cells[i, 6].Value.ToString());

                var Mg = decimal.Parse(ws.Cells[i, 7].Value.ToString());
                var Si = decimal.Parse(ws.Cells[i, 8].Value.ToString());
                var P = decimal.Parse(ws.Cells[i, 9].Value.ToString());


                var s1 = new SpectroSonucModel 
                { 
                    Tarih =tarih,
                    Bolge=bolge,
                    ElemanSayisi=elemanSayisi,
                    Li=Li,
                    Be=Be,
                    B = B,
                    Na = Na,
                    Mg=Mg,
                    Si=Si,
                    P=P

                };

                SpektroSonucListe.Add(s1);
               
            }

         
            workbook.Dispose();
        }

        public MainWindowVM()
        {
            SpektroSonucListe = new ObservableCollection<SpectroSonucModel>();

        }
    }
}
