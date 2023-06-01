using System.ComponentModel.DataAnnotations;

namespace ENGrupMimarlikIsparta.Models.Siniflar
{
    public class IletisimBilgileri
    {
        [Key]
        public int IletisimID { get; set; }
        public string Fotograf { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string TelefonNumarasi_1 { get; set; }
        public string TelefonNumarasi_2 { get; set; }

        public string FirmaLogosu { get; set; }

    }
}