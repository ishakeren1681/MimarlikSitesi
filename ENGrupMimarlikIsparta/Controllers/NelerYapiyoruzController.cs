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
    public class NelerYapiyoruzController : Controller
    {
        Context c = new Context();

        public ActionResult NelerYapiyoruzIndex()
        {
            var nelerYapiyoruzDegerler = c.Detaylars.Where(x => x.HangiSayfa == "NelerYapiyoruz").ToList();
            return View(nelerYapiyoruzDegerler);
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
            p.HangiSayfa = "NelerYapiyoruz";


            c.Detaylars.Add(p);
            c.SaveChanges();
            return RedirectToAction("NelerYapiyoruzIndex", "NelerYapiyoruz");
        }

        public ActionResult NelerYapiyoruzVeriGuncelle(Detaylar p)
        {

            var nelerYapiyoruzVeri = c.Detaylars.Find(p.DetayID);

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var file = Request.Files[0];
                string dosyaAdi = Path.GetFileName(file.FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                nelerYapiyoruzVeri.Fotograf = p.Fotograf;
            }
            nelerYapiyoruzVeri.Aciklama = p.Aciklama;
            nelerYapiyoruzVeri.Baslik = p.Baslik;
            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod

            return RedirectToAction("NelerYapiyoruzIndex");
        }

        public ActionResult NelerYapiyoruzVerileriniGetir(int id)
        {
            var nelerYapiyoruz = c.Detaylars.Find(id);
            return View("NelerYapiyoruzVerileriniGetir", nelerYapiyoruz);
        }

        public ActionResult VeriSil(int id)
        {
            var sütunSil = c.Detaylars.Find(id);
            c.Detaylars.Remove(sütunSil);
            c.SaveChanges();
            return RedirectToAction("NelerYapiyoruzIndex");
        }
    }
}