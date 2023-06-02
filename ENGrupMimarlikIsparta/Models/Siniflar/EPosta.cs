using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENGrupMimarlikIsparta.Models.Siniflar
{
    public class EPosta
    {

        [Key]
        public int MesajID { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string Gonderen { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]
        public string Konu { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız.")]

        public DateTime Tarih { get; set; }
        public string MesajDetay { get; set; }
        public string TelefonNumarasi { get; set; }
        public string MesajStatusu { get; set; }
    }
}