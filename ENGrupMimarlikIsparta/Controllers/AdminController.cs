using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ENGrupMimarlikIsparta.Models;
using ENGrupMimarlikIsparta.Models.Siniflar;

namespace ENGrupMimarlikIsparta.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        Context c = new Context();

        public ActionResult AdminIndex()
        {
            var adminler = c.Admins.ToList();
            return View(adminler);
        }


        // ADMİN EKLEME
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Admin p)
        {
            if (ModelState.IsValid)
            {
                var bilgiler = c.Admins.FirstOrDefault(x => x.Email == p.Email || x.KullaniciAdi == p.KullaniciAdi);
                if (bilgiler != null)
                {
                    if (bilgiler.Email == p.Email)
                    {
                        ViewBag.mailVar = "Böyle bir mail adresi daha önce alınmış!";
                    }
                    else if (bilgiler.KullaniciAdi == p.KullaniciAdi)
                    {
                        ViewBag.kullaniciVar = "Böyle bir kullanıcı adı daha önce alınmış!";
                    }
                    
                    
                    return View(p);
                }
                else
                {
                    c.Admins.Add(p);
                    c.SaveChanges();
                    return RedirectToAction("AdminIndex", "Admin");
                }
            }
            else
            {
                return View(p);
            }
        }

        // ADMİN SİL
        public ActionResult AdminSil(int id)
        {
            var adminBul = c.Admins.Find(id);
            if (id != 1)
            {
                c.Admins.Remove(adminBul);
                c.SaveChanges();
            }

            return RedirectToAction("AdminIndex", "Admin");
        }


        // ADMİN BİLGİLERİ
        public ActionResult AdminBilgileriniGetir(int id)
        {
            var adminBilgileri = c.Admins.Find(id);
            return View("AdminBilgileriniGetir",adminBilgileri);
        }

        public ActionResult AdminGuncelle(Admin p)
        {
            var adminVeri = c.Admins.Find(p.AdminID);
            if (ModelState.IsValid)
            {
                adminVeri.Email = p.Email;
                adminVeri.Sifre = p.Sifre;
                adminVeri.KullaniciAdi = p.KullaniciAdi;
                adminVeri.SifreTekrar = p.SifreTekrar;
                adminVeri.YetkiStatusu = p.YetkiStatusu;
                c.SaveChanges();
                return RedirectToAction("AdminIndex", "Admin", p);
            }
            else
            {
                return View("AdminBilgileriniGetir",p);
            }
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Anasayfa", "Sayfalar");
        }

        // SOSYAL MEDYA BİLGİLERİ
        public ActionResult SosyalMedya(int id = 1)
        {
            var sosyalMedya = c.SosyalMedyaAyarlars.Find(id);
            return View("SosyalMedya", sosyalMedya);
        }

        public ActionResult SosyalMedyaGuncelle(SosyalMedyaAyarlar p)
        {
            var sosyalMedyaVeri = c.SosyalMedyaAyarlars.Find(p.LoginID);
            if (ModelState.IsValid)
            {
                sosyalMedyaVeri.twitterAdresi = p.twitterAdresi;
                sosyalMedyaVeri.linkedinAdresi = p.linkedinAdresi;
                sosyalMedyaVeri.facebookAdresi = p.facebookAdresi;
                sosyalMedyaVeri.instagramAdresi = p.instagramAdresi;

                c.SaveChanges();
                return RedirectToAction("SosyalMedya", "Admin", p);
            }
            else
            {
                return View("SosyalMedya", p);
            }
        }

      


        // ILETİSIM BİLGİLERİ 
        public ActionResult IletisimBilgisiGetir(int id = 1)
        {
            var iletisimBilgileri = c.IletisimBilgileris.Find(id);
            return View("IletisimBilgisiGetir", iletisimBilgileri);
        }

        public ActionResult IletisimBilgisiGuncelle(IletisimBilgileri p)
        {
            var iletisimVeri = c.IletisimBilgileris.Find(p.IletisimID);

            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                //ÖNCEKİ DOSYAYI SİLME
                string eskiDosyaYolu = Server.MapPath(iletisimVeri.Fotograf);
                if (System.IO.File.Exists(eskiDosyaYolu))
                {
                    System.IO.File.Delete(eskiDosyaYolu);
                }

                var file = Request.Files[0];
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.Fotograf = "/Image/" + dosyaAdi;
                iletisimVeri.Fotograf = p.Fotograf;
            }

            iletisimVeri.Adres = p.Adres;
            iletisimVeri.Email = p.Email;
            iletisimVeri.TelefonNumarasi_1 = p.TelefonNumarasi_1;
            iletisimVeri.TelefonNumarasi_2 = p.TelefonNumarasi_2;

            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod

            return RedirectToAction("IletisimBilgisiGetir");
        }


        // FİRMA LOGOSU
        public ActionResult FirmaLogosu(int id = 1)
        {
            var iletisimBilgileri = c.IletisimBilgileris.Find(id);
            return View("FirmaLogosu", iletisimBilgileri);
        }

        public ActionResult FirmaLogosuGuncelle(IletisimBilgileri p)
        {
            var iletisimVeri = c.IletisimBilgileris.Find(p.IletisimID);

            string fotografTarihi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                //ÖNCEKİ DOSYAYI SİLME
                string eskiDosyaYolu = Server.MapPath(iletisimVeri.FirmaLogosu);
                if (System.IO.File.Exists(eskiDosyaYolu))
                {
                    System.IO.File.Delete(eskiDosyaYolu);
                }

                var file = Request.Files[0];
                string dosyaAdi = "EN_Mimarlik" + fotografTarihi + Path.GetExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(file.FileName);
                string yol = Path.Combine(Server.MapPath("~/Image/"), dosyaAdi);
                file.SaveAs(yol);
                p.FirmaLogosu = "/Image/" + dosyaAdi;
                iletisimVeri.FirmaLogosu = p.FirmaLogosu;
            }

            c.SaveChanges(); // Değişiklikleri veritabanına kaydetmek için gerekli olan kod

            return RedirectToAction("FirmaLogosu", "Admin");
        }


        //FİRMA MAİL ADRESİ
        public ActionResult FirmaMailAdresi(int id = 1)
        {
            var firmaEmaili = c.Admins.Find(id);
            return View("FirmaMailAdresi", firmaEmaili);
        }


        public ActionResult FirmaMailAdresiGuncelle(Admin p)
        {
            var adminVeri = c.Admins.Find(p.AdminID);
            if (ModelState.IsValid)
            {
                adminVeri.Email = p.Email;
                adminVeri.Sifre = p.Sifre;
                adminVeri.KullaniciAdi = p.KullaniciAdi;
                adminVeri.SifreTekrar = p.SifreTekrar;
                adminVeri.YetkiStatusu = p.YetkiStatusu;
                c.SaveChanges();
                return RedirectToAction("AdminIndex", "Admin", p);
            }
            else
            {
                return View("AdminBilgileriniGetir", p);
            }
        }


       
    }
}