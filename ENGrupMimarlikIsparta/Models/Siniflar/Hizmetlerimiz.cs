using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENGrupMimarlikIsparta.Models.Siniflar
{
    public class Hizmetlerimiz
    {
        [Key]
        public int HizmetID { get; set; }
        public string Hizmet { get; set; }
    }
}