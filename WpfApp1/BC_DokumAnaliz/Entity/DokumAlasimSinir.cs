using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.BC_DokumKalite
{
    [Table("DokumAlasimSinir",Schema ="Uretim")]
    public class DokumAlasimSinir
    {
        [Key]
        public int Id { get; set; }
        public string Alasim { get; set; }
        public decimal SiMin { get; set; }
        public decimal SiMax { get; set; }
        public decimal FeMin { get; set; }
        public decimal FeMax { get; set; }
        public decimal CuMin { get; set; }
        public decimal CuMax { get; set; }
        public decimal MnMin { get; set; }
        public decimal MnMax { get; set; }
        public decimal MgMin { get; set; }
        public decimal MgMax { get; set; }
        public decimal TiMin { get; set; }
        public decimal TiMax { get; set; }
        public decimal ZnMin { get; set; }
        public decimal ZnMax { get; set; }
        public decimal AlMin { get; set; }
        public decimal AlMax { get; set; }
    }
}
