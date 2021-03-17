using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.BC_DokumKalite;

namespace WpfApp1.BC_DokumAnaliz
{
    public class _DokumAnalizDbContext:DbContext
    {
        public DbSet<DokumAlasimSinir> DokumAlasimSinirlari { get; set; }

        public DbSet<DokumAnalizSonuc> DokumAnalizSonuclari { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cnnStr = "server=.;database=pandapdb;user id=sa;password=Ankara!06";
            optionsBuilder.UseSqlServer(cnnStr);


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
