using ENGrupMimarlikIsparta.Models;
using ENGrupMimarlikIsparta.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENGrupMimarlikIsparta.Controllers
{

    [Authorize]
    public class IletisimController : Controller
    {
        Context c = new Context();

        public ActionResult IletisimIndex()
        {
            var iletisimBilgileri = c.IletisimBilgileris.Where(x => x.IletisimID == 1).ToList();
            return View(iletisimBilgileri);
        }

        public PartialViewResult IletisimBilgileri_Footer()
        {
            var iletisimBilgileri = c.IletisimBilgileris.ToList();
            return PartialView(iletisimBilgileri);
        }

        public PartialViewResult HizmetBilgileri_Footer()
        {
            var hizmetBilgileri = c.Hizmetlerimizs.ToList();
            return PartialView(hizmetBilgileri);
        }

        [HttpGet]
        public ActionResult AdresFotografiEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdresFotografiEkle(Detaylar p)
        {
            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                Request.Files[0].SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
            }

            p.HangiSayfa = "Iletisim";
            c.Detaylars.Add(p);
            c.SaveChanges();
            return RedirectToAction("IletisimIndex");
        }


        public ActionResult AdresFotografiGetir(int id)
        {
            var adresVerileri = c.Detaylars.Find(id);
            return View("AdresFotografiGetir",adresVerileri);
        }



     

        public ActionResult AdresFotografiGuncelle(Detaylar p)
        {
            var fotoBul = c.Detaylars.Find(p.DetayID);

            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                //ÖNCEKİ DOSYAYI SİLME
                string eskiDosyaYolu = Server.MapPath(fotoBul.Fotograf);
                if (System.IO.File.Exists(eskiDosyaYolu))
                {
                    System.IO.File.Delete(eskiDosyaYolu);
                }

                var file = Request.Files[0];
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                fotoBul.Fotograf = p.Fotograf;
            }
            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod
            return RedirectToAction("IletisimIndex");
        }

        public PartialViewResult IletisimFotograflari()
        {
            var AdresFotograflari = c.Detaylars.Where(x => x.HangiSayfa == "Iletisim").ToList();
            return PartialView(AdresFotograflari);
        }

        public ActionResult AdresFotografiSil(int id)
        {
            var fotoBul = c.Detaylars.Find(id);
            c.Detaylars.Remove(fotoBul);
            c.SaveChanges();
            return RedirectToAction("IletisimIndex", "Iletisim");
        }
    }
}