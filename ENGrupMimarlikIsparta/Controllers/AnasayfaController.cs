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
        Context c = new Context();

        // GET: Anasayfa

        public ActionResult AnasayfaIndex()
        {
            var anasayfaDegerler = c.Detaylars.Where(x=>x.HangiSayfa == "Anasayfa").ToList();
            return View(anasayfaDegerler);
        }

        [HttpGet]
        public ActionResult VeriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VeriEkle(Detaylar p)
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
            p.HangiSayfa = "Anasayfa";
            c.Detaylars.Add(p);
            c.SaveChanges();
            return RedirectToAction("AnasayfaIndex");
        }

        public ActionResult AnasayfaVerileriniGetir(int id)
        {
            var anasayfaVerileri = c.Detaylars.Find(id);
            return View("AnasayfaVerileriniGetir", anasayfaVerileri);
        }

        public ActionResult AnasayfaVeriGuncelle(Detaylar p)
        {

            var anasayfaVeri = c.Detaylars.Find(p.DetayID);

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var file = Request.Files[0];
                string dosyaAdi = Path.GetFileName(file.FileName);
                string uzanti = Path.GetExtension(file.FileName);
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

            return RedirectToAction("AnasayfaIndex");

        }
        public ActionResult VeriSil(int id)
        {
            var sütunSil = c.Detaylars.Find(id);
            c.Detaylars.Remove(sütunSil);
            c.SaveChanges();
            return RedirectToAction("AnasayfaIndex");
        }
    }
}