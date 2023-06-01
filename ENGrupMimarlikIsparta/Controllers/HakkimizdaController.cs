using ENGrupMimarlikIsparta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENGrupMimarlikIsparta.Models.Siniflar;
using System.IO;

namespace ENGrupMimarlikIsparta.Controllers
{

    [Authorize]
    public class HakkimizdaController : Controller
    {
        Context c = new Context();

        public ActionResult HakkimizdaIndex()
        {
            var hakkimizdaDegerler = c.Detaylars.Where(x => x.HangiSayfa == "Hakkimizda").ToList();
            return View(hakkimizdaDegerler);
        }

        [HttpGet]
        public ActionResult HakkimizdaVeriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HakkimizdaVeriEkle(Detaylar p)
        {
            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                Request.Files[0].SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
            }
            p.HangiSayfa = "Hakkimizda";
            p.Yonu = Request.Form["Yonu"];

            c.Detaylars.Add(p);
            c.SaveChanges();
            return RedirectToAction("HakkimizdaIndex", "Hakkimizda");
        }

        public ActionResult HakkimizdaVerileriniGetir(int id)
        {
            var anasayfaVerileri = c.Detaylars.Find(id);
            return View("HakkimizdaVerileriniGetir", anasayfaVerileri);
        }

        public ActionResult VeriGuncelle(Detaylar p)
        {
            var hakkimizda = c.Detaylars.Find(p.DetayID);

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var file = Request.Files[0];
                string dosyaAdi = Path.GetFileName(file.FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                hakkimizda.Fotograf = p.Fotograf;
            }

            hakkimizda.Yonu = Request.Form["Yonu"];
            hakkimizda.Aciklama = p.Aciklama;
            hakkimizda.Baslik = p.Baslik;
            hakkimizda.Yonu = p.Yonu;

            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod

            return RedirectToAction("HakkimizdaIndex");
        }

        public ActionResult VeriSil(int id)
        {
            var sütunSil = c.Detaylars.Find(id);
            c.Detaylars.Remove(sütunSil);
            c.SaveChanges();
            return RedirectToAction("HakkimizdaIndex");
        }
    }


}