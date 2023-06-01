using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENGrupMimarlikIsparta.Models.Siniflar
{
    public class SosyalMedyaAyarlar
    {


        [Key]
        public int LoginID { get; set; }

        public string facebookAdresi { get; set; }
        public string twitterAdresi { get; set; }
        public string linkedinAdresi { get; set; }
        public string instagramAdresi { get; set; }

    }
}