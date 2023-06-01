using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENGrupMimarlikIsparta.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public string AdSoyad { get; set; }
        public string Fotograf { get; set; }
        public string Unvan { get; set; }
        public string TelefonNumarasi { get; set; }

        public bool Durum { get; set; }
    }
}