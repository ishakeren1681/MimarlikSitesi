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
    public class PersonelController : Controller
    {
        Context c = new Context();

        public PartialViewResult PersonelSayfasi()
        {
            var personeller = c.Personels.ToList();
            return PartialView(personeller);
        }


        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
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
            c.Personels.Add(p);
            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod
            return RedirectToAction("HakkimizdaIndex", "Hakkimizda");
        }


        

        public ActionResult PersonelSil(int id)
        {
            var personelBul = c.Personels.Find(id);
            string eskiDosyaYolu = Server.MapPath(personelBul.Fotograf);
            if (System.IO.File.Exists(eskiDosyaYolu))
            {
                System.IO.File.Delete(eskiDosyaYolu);
            }
            c.Personels.Remove(personelBul);
            c.SaveChanges();
            return RedirectToAction("HakkimizdaIndex","Hakkimizda");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personelGetir = c.Personels.Find(id);
            return View("PersonelGetir",personelGetir);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var personelVeri = c.Personels.Find(p.PersonelID);
            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                //ÖNCEKİ DOSYAYI SİLME
                string eskiDosyaYolu = Server.MapPath(personelVeri.Fotograf);
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
                personelVeri.Fotograf = p.Fotograf;
            }

            personelVeri.AdSoyad = p.AdSoyad;
            personelVeri.Unvan = p.Unvan;
            personelVeri.TelefonNumarasi = p.TelefonNumarasi;
      
            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod
            return RedirectToAction("HakkimizdaIndex","Hakkimizda");
        }
    }
}