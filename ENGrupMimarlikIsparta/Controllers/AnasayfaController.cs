using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENGrupMimarlikIsparta.Models;
using ENGrupMimarlikIsparta.Models.Siniflar;

namespace ENGrupMimarlikIsparta.Controllers
{

    [Authorize]
    public class AnasayfaController : Controller
    {
        private readonly Context c = new Context();

        // GET: Anasayfa



        [HttpGet]
        public ActionResult VeriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VeriEkle(Detaylar p)
        {
            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);
                
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                Request.Files[0].SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
            }

            p.Yonu = Request.Form["Yonu"];
            p.HangiSayfa = "Anasayfa";
            c.Detaylars.Add(p);
            c.SaveChanges();

            return RedirectToAction("Anasayfa","Sayfalar");

        }

        public ActionResult AnasayfaVerileriniGetir(int id)
        {
            var anasayfaVerileri = c.Detaylars.Find(id);
            return View("AnasayfaVerileriniGetir", anasayfaVerileri);
        }

        public ActionResult AnasayfaVeriGuncelle(Detaylar p)
        {
            var anasayfaVeri = c.Detaylars.Find(p.DetayID);

            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                //ÖNCEKİ DOSYAYI SİLME
                string eskiDosyaYolu = Server.MapPath(anasayfaVeri.Fotograf);
                if (System.IO.File.Exists(eskiDosyaYolu))
                {
                    System.IO.File.Delete(eskiDosyaYolu);
                }

                var file = Request.Files[0];
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);
               
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                anasayfaVeri.Fotograf = p.Fotograf;
            }

            anasayfaVeri.Yonu = Request.Form["Yonu"];
            anasayfaVeri.Aciklama = p.Aciklama;
            anasayfaVeri.Baslik = p.Baslik;
            anasayfaVeri.Yonu = p.Yonu;

            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod
            return RedirectToAction("Anasayfa", "Sayfalar");
        }


        public ActionResult VeriSil(int id)
        {
            var sütunSil = c.Detaylars.Find(id);
            string eskiDosyaYolu = Server.MapPath(sütunSil.Fotograf);
            if (System.IO.File.Exists(eskiDosyaYolu))
            {
                System.IO.File.Delete(eskiDosyaYolu);
            }
            c.Detaylars.Remove(sütunSil);
            c.SaveChanges();
            return RedirectToAction("Anasayfa", "Sayfalar");
        }
    }
}