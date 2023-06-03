using ENGrupMimarlikIsparta.Models;
using ENGrupMimarlikIsparta.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENGrupMimarlikIsparta.Controllers
{
    [AllowAnonymous]
    public class SayfalarController : Controller
    {
        Context c = new Context();
        public ActionResult Anasayfa()
        {
            var veriler = c.Detaylars.Where(x => x.HangiSayfa == "Anasayfa").ToList();

           

            return View(veriler);
        }

        public ActionResult Hakkimizda()
        {
            var veriler = c.Detaylars.Where(x => x.HangiSayfa == "Hakkimizda").ToList();
            return View(veriler);
        }

        public PartialViewResult HakkimizdaPersonel()
        {
            var personeller = c.Personels.ToList();
            return PartialView(personeller);
        }

        public ActionResult NelerYapiyoruz()
        {
            var nelerYapiyoruzDegerler = c.Detaylars.Where(x => x.HangiSayfa == "NelerYapiyoruz").ToList();

            return View(nelerYapiyoruzDegerler);
        }

        public ActionResult Projelerimiz()
        {
            return View();
        }

        public ActionResult MerkezProjeleri()
        {
            var veriler = c.Detaylars.Where(x => x.HangiSayfa == "MerkezProjeleri").ToList();
            return View(veriler);
        }

        public ActionResult IlceProjeleri()
        {
            var veriler = c.Detaylars.Where(x => x.HangiSayfa == "IlceProjeleri").ToList();
            return View(veriler);
        }

        public ActionResult Iletisim()
        {
            var veriler = c.IletisimBilgileris.Where(x => x.IletisimID == 1).ToList();
            return View(veriler);
        }


        [HttpGet]
        public ActionResult Iletisim_MesajBirak()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Iletisim_MesajBirak(EPosta p)
        {

            if (ModelState.IsValid)
            {
                p.MesajStatusu = "Yeni";
                c.EPostas.Add(p);
                c.SaveChanges();
                return RedirectToAction("Iletisim", "Sayfalar");
            }
            else
            {
                return View(p);
            }
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

        public PartialViewResult FirmaLogosu_SolKose()
        {
            var logoUzantisi = c.IletisimBilgileris.Where(x => x.IletisimID == 1).Select(y => y.FirmaLogosu).FirstOrDefault().ToString();
            ViewBag.logo = logoUzantisi;
            return PartialView();
        }





        public PartialViewResult SosyalMedyaPartial()
        {
            

            var facebookAdresi = c.SosyalMedyaAyarlars.Where(x => x.LoginID == 1).Select(y => y.facebookAdresi).FirstOrDefault();
            ViewBag.facebookAdresi = facebookAdresi;

            var twitterAdresi = c.SosyalMedyaAyarlars.Where(x => x.LoginID == 1).Select(y => y.twitterAdresi).FirstOrDefault();
            ViewBag.twitterAdresi = twitterAdresi;

            var linkedinAdresi = c.SosyalMedyaAyarlars.Where(x => x.LoginID == 1).Select(y => y.linkedinAdresi).FirstOrDefault();
            ViewBag.linkedinAdresi = linkedinAdresi;

            var instagramAdresi = c.SosyalMedyaAyarlars.Where(x => x.LoginID == 1).Select(y => y.instagramAdresi).FirstOrDefault();
            ViewBag.instagramAdresi = instagramAdresi;
            return PartialView();
        }
    }
}