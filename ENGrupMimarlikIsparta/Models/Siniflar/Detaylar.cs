using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENGrupMimarlikIsparta.Models.Siniflar
{
    public class Detaylar
    {
        [Key]
        public int DetayID { get; set; }
        public string HangiSayfa { get; set; }
        public string Fotograf { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Yonu { get; set; }

    }
}