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
        Context c = new Context();
        public ActionResult ProjeIndex()
        {
            return View();
        }

        public ActionResult MerkezProjeleri()
        {
            var merkezProjeleri = c.Detaylars.Where(x => x.HangiSayfa == "MerkezProjeleri").ToList();
            return View(merkezProjeleri);
        }

        [HttpGet]
        public ActionResult MerkezProjesiEkle()
        {
            return View();
        }

        public ActionResult MerkezProjesiEkle(Detaylar p)
        {
            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                Request.Files[0].SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
            }

            p.Yonu = Request.Form["Yonu"];
            p.HangiSayfa = "MerkezProjeleri";
            c.Detaylars.Add(p);
            c.SaveChanges();

            return RedirectToAction("MerkezProjeleri", "Projelerimiz");
        }

        public ActionResult MerkezProjeSil(int id)
        {
            var merkezprojesil = c.Detaylars.Find(id);
            c.Detaylars.Remove(merkezprojesil);
            c.SaveChanges();
            return RedirectToAction("MerkezProjeleri", "Projelerimiz");
        }

        public ActionResult MerkezProjesiVerileriniGetir(int id)
        {
            var anasayfaVerileri = c.Detaylars.Find(id);
            
            return View("MerkezProjesiVerileriniGetir", anasayfaVerileri);
        }

        public ActionResult MerkezProjesiGuncelle(Detaylar p)
        {
            var merkezProje = c.Detaylars.Find(p.DetayID);

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var file = Request.Files[0];
                string dosyaAdi = Path.GetFileName(file.FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                merkezProje.Fotograf = p.Fotograf;
            }
            merkezProje.Yonu = Request.Form["Yonu"];
            merkezProje.Aciklama = p.Aciklama;
            merkezProje.Baslik = p.Baslik;
            merkezProje.Yonu = p.Yonu;

            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod

            return RedirectToAction("MerkezProjeleri");
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
            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                Request.Files[0].SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
            }

            p.Yonu = Request.Form["Yonu"];
            p.HangiSayfa = "IlceProjeleri";
            c.Detaylars.Add(p);
            c.SaveChanges();

            return RedirectToAction("IlceProjeleri", "Projelerimiz");
        }

        public ActionResult IlceProjesiSil(int id)
        {
            var merkezprojesil = c.Detaylars.Find(id);
            c.Detaylars.Remove(merkezprojesil);
            c.SaveChanges();
            return RedirectToAction("IlceProjeleri", "Projelerimiz");
        }

        public ActionResult IlceProjesiVerileriniGetir(int id)
        {
            var anasayfaVerileri = c.Detaylars.Find(id);

            return View("IlceProjesiVerileriniGetir", anasayfaVerileri);
        }

        public ActionResult IlceProjesiGuncelle(Detaylar p)
        {
            var merkezProje = c.Detaylars.Find(p.DetayID);

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var file = Request.Files[0];
                string dosyaAdi = Path.GetFileName(file.FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                merkezProje.Fotograf = p.Fotograf;
            }
            merkezProje.Yonu = Request.Form["Yonu"];
            merkezProje.Aciklama = p.Aciklama;
            merkezProje.Baslik = p.Baslik;
            merkezProje.Yonu = p.Yonu;

            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod

            return RedirectToAction("IlceProjeleri");
        }
    }
}