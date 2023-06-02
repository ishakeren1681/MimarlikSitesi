using ENGrupMimarlikIsparta.Models;
using ENGrupMimarlikIsparta.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENGrupMimarlikIsparta.Controllers
{

    [Authorize]
    public class MesajController : Controller
    {
        Context c = new Context();

        // GET: Mesaj
        [HttpGet]

        public ActionResult MesajBirak()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MesajBirak(EPosta p)
        {

            if (ModelState.IsValid)
            {
                p.MesajStatusu = "Yeni";
                c.EPostas.Add(p);
                c.SaveChanges();
                return RedirectToAction("IletisimIndex", "Iletisim");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult GelenKutusu()
        {
            var mesajlariGetir = c.EPostas.Where(x => x.MesajStatusu == "Yeni" || x.MesajStatusu == "Okundu").OrderByDescending(x => x.Tarih).ToList();
            return View(mesajlariGetir);
        }

       

        public ActionResult SilinmisMesajlar()
        {
            var silinmisMesajlariGetir = c.EPostas.Where(x => x.MesajStatusu == "Silinen").OrderByDescending(x => x.Tarih).ToList();
            return View(silinmisMesajlariGetir);
        }

        [HttpPost]
        public ActionResult SilinenlereTasi(int id)
        {
            var mesajBul = c.EPostas.Find(id);
            if (mesajBul != null)
            {
                mesajBul.MesajStatusu = "Silinen";
                c.SaveChanges();
            }
      
            return RedirectToAction("GelenKutusu", "Mesaj");
        }

        public ActionResult SilinmisMesajiOku(int id)
        {
            var mesajDetaylari = c.EPostas.Where(x => x.MesajID == id).ToList();
            return RedirectToAction("MesajDetay", "Mesaj",mesajDetaylari);
        }

        public ActionResult GelenKutusunaTasi(int id)
        {
            var mesajBul = c.EPostas.Find(id);
            mesajBul.MesajStatusu = "Okundu";
            c.SaveChanges();
            return RedirectToAction("SilinmisMesajlar", "Mesaj");
        }

       

        public ActionResult OkunmadıOlarakIsaretle(int id)
        {
            var mesajBul = c.EPostas.Find(id);
            if (mesajBul != null)
            {
                mesajBul.MesajStatusu = "Yeni";
                c.SaveChanges();
            }

            return RedirectToAction("GelenKutusu", "Mesaj");
        }

        public ActionResult OkunduOlarakIsaretle(int id)
        {
            var mesajBul = c.EPostas.Find(id);
            if (mesajBul != null)
            {
                mesajBul.MesajStatusu = "Okundu";
                c.SaveChanges();
            }

            return RedirectToAction("GelenKutusu", "Mesaj");
        }

        public ActionResult MesajDetay(int id)
        {
            var mesajDetaylari = c.EPostas.Where(x => x.MesajID == id).ToList();
            var mesaj = mesajDetaylari[0];
            if (mesaj.MesajStatusu == "Yeni")
            {
                mesaj.MesajStatusu = "Okundu";
                c.SaveChanges();
            }

            return View(mesajDetaylari);
        }
     
        public ActionResult MesajSil(int id)
        {
            var mesajBul = c.EPostas.Find(id);
            c.EPostas.Remove(mesajBul);
            c.SaveChanges();
            return RedirectToAction("SilinmisMesajlar", "Mesaj");
        }
    }
}