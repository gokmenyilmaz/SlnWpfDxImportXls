using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BC_DokumKalite
{
    [Table("DokumAnalizSonuc", Schema = "Uretim")]
    public class DokumAnalizSonuc
    {
        [Key]
        public int Id { get; set; }
        public DateTime TarihSaat { get; set; }
        public string DokumHatti { get; set; }
        public string Bolge { get; set; }
        public string Alasim { get; set; }
        public string BobinNo { get; set; }
        public decimal Si { get; set; }

        [NotMapped]
        public string Si_Err { get; set; }

        public decimal Fe { get; set; }
        public decimal Cu { get; set; }
        public decimal Mn { get; set; }
        public decimal Mg { get; set; }
        public decimal Ti { get; set; }
        public decimal Zn { get; set; }
        public decimal Al { get; set; }
        public string Fe_Err { get; internal set; }
        public string Cu_Err { get; internal set; }
        public string Mn_Err { get; internal set; }
        public string Mg_Err { get; internal set; }
        public string Ti_Err { get; internal set; }
        public string Zn_Err { get; internal set; }
        public string Al_Err { get; internal set; }
    }


}
