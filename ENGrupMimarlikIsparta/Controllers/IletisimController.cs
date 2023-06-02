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
    public class IletisimController : Controller
    {
        Context c = new Context();

        public ActionResult IletisimIndex()
        {
            var iletisimBilgileri = c.IletisimBilgileris.Where(x => x.IletisimID == 1).ToList();
            return View(iletisimBilgileri);
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
    }
}