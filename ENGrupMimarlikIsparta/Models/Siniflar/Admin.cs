using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENGrupMimarlikIsparta.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }


        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string KullaniciAdi { get; set; }


        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string YetkiStatusu { get; set; }


        [Required(ErrorMessage ="Bu alanı boş bırakamazsınız.")]
        public string Sifre { get; set; }

        
        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string SifreTekrar { get; set; }
    }
}