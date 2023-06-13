using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENGrupMimarlikIsparta.Models;
using ENGrupMimarlikIsparta.Models.Siniflar;

namespace ENGrupMimarlikIsparta.Controllers
{

    [Authorize]
    public class HizmetController : Controller
    {
        private readonly Context c = new Context();
        // GET: Hizmet
        public ActionResult HizmetIndex()
        {
            var hizmetler = c.Hizmetlerimizs.ToList();
            return View(hizmetler);
        }

        public ActionResult HizmetBilgileriniGetir(int id)
        {
            var hizmetBilgileri = c.Hizmetlerimizs.Find(id);
            return View("HizmetBilgileriniGetir",hizmetBilgileri);
        }

        public ActionResult HizmetBilgisiGuncelle(Hizmetlerimiz p)
        {
            var hizmetVeri = c.Hizmetlerimizs.Find(p.HizmetID);

            hizmetVeri.Hizmet = p.Hizmet;
            c.SaveChanges();
            return RedirectToAction("HizmetIndex", "Hizmet");
        }

        public ActionResult HizmetSil(int id)
        {
            var hizmetBul = c.Hizmetlerimizs.Find(id);
            c.Hizmetlerimizs.Remove(hizmetBul);
            c.SaveChanges();
            return RedirectToAction("HizmetIndex", "Hizmet");
        }

        [HttpGet]
        public ActionResult HizmetEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HizmetEkle(Hizmetlerimiz p)
        {
            c.Hizmetlerimizs.Add(p);
            c.SaveChanges();
            return RedirectToAction("HizmetIndex", "Hizmet");
        }



    }
}