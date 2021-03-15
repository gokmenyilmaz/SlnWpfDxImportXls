using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class SpectroSonucModel
    {

        //Li Be	B	Na	Mg	Si	P	Ca	Ti	V	Cr	Mn	Fe	Ni	Cu
        public DateTime Tarih { get; set; }

        public string    Bolge { get; set; }

        public int ElemanSayisi { get; set; }

        public decimal Li { get; set; }

        public decimal Be { get; set; }

        public decimal B { get; set; }
        public decimal Na { get; set; }

        public decimal Mg { get; set; }

        public decimal Si { get; set; }

        public decimal P { get; set; }

    }
}
