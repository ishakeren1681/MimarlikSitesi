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
    public class ProjelerimizController : Controller
    {
        private readonly Context c = new Context();


        [HttpGet]
        public ActionResult MerkezProjesiEkle()
        {
            return View();
        }

        public ActionResult MerkezProjesiEkle(Detaylar p)
        {
            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                Request.Files[0].SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
            }

            p.Yonu = Request.Form["Yonu"];
            p.HangiSayfa = "MerkezProjeleri";
            c.Detaylars.Add(p);
            c.SaveChanges();

            return RedirectToAction("MerkezProjeleri", "Sayfalar");
        }

        public ActionResult MerkezProjeSil(int id)
        {
            var merkezprojesil = c.Detaylars.Find(id);
            string eskiDosyaYolu = Server.MapPath(merkezprojesil.Fotograf);
            if (System.IO.File.Exists(eskiDosyaYolu))
            {
                System.IO.File.Delete(eskiDosyaYolu);
            }
            c.Detaylars.Remove(merkezprojesil);
            c.SaveChanges();
            return RedirectToAction("MerkezProjeleri", "Sayfalar");
        }

        public ActionResult MerkezProjesiVerileriniGetir(int id)
        {
            var anasayfaVerileri = c.Detaylars.Find(id);
            
            return View("MerkezProjesiVerileriniGetir", anasayfaVerileri);
        }

        public ActionResult MerkezProjesiGuncelle(Detaylar p)
        {
            var merkezProje = c.Detaylars.Find(p.DetayID);

            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                //ÖNCEKİ DOSYAYI SİLME
                string eskiDosyaYolu = Server.MapPath(merkezProje.Fotograf);
                if (System.IO.File.Exists(eskiDosyaYolu))
                {
                    System.IO.File.Delete(eskiDosyaYolu);
                }

                var file = Request.Files[0];
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                merkezProje.Fotograf = p.Fotograf;
            }

            merkezProje.Yonu = Request.Form["Yonu"];
            merkezProje.Aciklama = p.Aciklama;
            merkezProje.Baslik = p.Baslik;
            merkezProje.Yonu = p.Yonu;

            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod

            return RedirectToAction("MerkezProjeleri", "Sayfalar");
        }


        [HttpGet]
        public ActionResult IlceProjeleri()
        {
            var koyProjeleri = c.Detaylars.Where(x => x.HangiSayfa == "IlceProjeleri").ToList();
            return View(koyProjeleri);
        }

        [HttpGet]
        public ActionResult IlceProjesiEkle()
        {
            return View();
        }

        public ActionResult IlceProjesiEkle(Detaylar p)
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
            p.HangiSayfa = "IlceProjeleri";
            c.Detaylars.Add(p);
            c.SaveChanges();

            return RedirectToAction("IlceProjeleri", "Sayfalar");
        }

        public ActionResult IlceProjesiSil(int id)
        {
            var ilceProjeSil = c.Detaylars.Find(id);

            string eskiDosyaYolu = Server.MapPath(ilceProjeSil.Fotograf);
            if (System.IO.File.Exists(eskiDosyaYolu))
            {
                System.IO.File.Delete(eskiDosyaYolu);
            }


            c.Detaylars.Remove(ilceProjeSil);
            c.SaveChanges();
            return RedirectToAction("IlceProjeleri", "Sayfalar");
        }

        public ActionResult IlceProjesiVerileriniGetir(int id)
        {
            var anasayfaVerileri = c.Detaylars.Find(id);

            return View("IlceProjesiVerileriniGetir", anasayfaVerileri);
        }

        public ActionResult IlceProjesiGuncelle(Detaylar p)
        {
            var ilceProje = c.Detaylars.Find(p.DetayID);

            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                //ÖNCEKİ DOSYAYI SİLME
                string eskiDosyaYolu = Server.MapPath(ilceProje.Fotograf);
                if (System.IO.File.Exists(eskiDosyaYolu))
                {
                    System.IO.File.Delete(eskiDosyaYolu);
                }

                var file = Request.Files[0];
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                ilceProje.Fotograf = p.Fotograf;

            }
            ilceProje.Yonu = Request.Form["Yonu"];
            ilceProje.Aciklama = p.Aciklama;
            ilceProje.Baslik = p.Baslik;
            ilceProje.Yonu = p.Yonu;

            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod

            return RedirectToAction("IlceProjeleri", "Sayfalar");
        }
    }
}