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



        public decimal? Si { get; set; }
        public decimal? Fe { get; set; }
        public decimal? Cu { get; set; }
        public decimal? Mn { get; set; }
        public decimal? Mg { get; set; }
        public decimal? Ti { get; set; }
        public decimal? Zn { get; set; }
        public decimal? Al { get; set; }



        [NotMapped]
        public string Si_Err { get; set; }

        [NotMapped]
        public string Fe_Err { get;  set; }


        [NotMapped]
        public string Cu_Err { get;  set; }

        [NotMapped]
        public string Mn_Err { get;  set; }

        [NotMapped]
        public string Mg_Err { get;  set; }

        [NotMapped]
        public string Ti_Err { get;  set; }


        [NotMapped]
        public string Zn_Err { get;  set; }

        [NotMapped]
        public string Al_Err { get;  set; }
    }


}
