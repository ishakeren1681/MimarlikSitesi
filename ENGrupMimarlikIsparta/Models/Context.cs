using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ENGrupMimarlikIsparta.Models.Siniflar;

namespace ENGrupMimarlikIsparta.Models
{
    public class Context:DbContext
    {
   
        public DbSet<Detaylar> Detaylars { get; set; }

        public DbSet<IletisimBilgileri> IletisimBilgileris { get; set; }

        public DbSet<Personel> Personels { get; set; }

        public DbSet<EPosta> EPostas { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<SosyalMedyaAyarlar> SosyalMedyaAyarlars { get; set; }

        public DbSet<Hizmetlerimiz> Hizmetlerimizs { get; set; }


    }
}