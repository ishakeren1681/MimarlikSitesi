using ENGrupMimarlikIsparta.Models;
using ENGrupMimarlikIsparta.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ENGrupMimarlikIsparta.Controllers
{


    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();

  
        public ActionResult LoginIndex()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("AdminIndex", "Admin");
            }
            else
            {
                return RedirectToAction("LoginIndex", "Login");
            }

        }

        [HttpGet]
        public ActionResult SifremiUnuttum()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SifremiUnuttum(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Email == p.Email);

            var aliciMail = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Email).FirstOrDefault();
            var aliciSifre = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Sifre).FirstOrDefault();

            try
            {
                if (bilgiler != null)
                {
                    string fromEmail = aliciMail.ToString();
                    string fromPassword = aliciSifre.ToString();
                    string toEmail = bilgiler.Email;

                    string randomSifre = RandomSifreOlustur(5);

                    using (MailMessage mail = new MailMessage(fromEmail, toEmail))
                    {
                        mail.Subject = "Yeni Şifre";
                        mail.Body = $"Merhaba, rastgele sayınız: {randomSifre}";

                        using (SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                            bilgiler.Sifre = randomSifre.ToString();
                            bilgiler.SifreTekrar = randomSifre.ToString();
                            c.SaveChanges();
                        }
                    }

                    ViewBag.Mesaj = "Yeni şifreniz mail adresinize gönderilmiştir.";
                    return View();
                }
                else
                {
                    ViewBag.Mesaj = "Böyle bir mail adresi bulunmamaktadır!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mesaj = "E-posta gönderme işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult KullaniciAdimiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciAdimiUnuttum(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Email == p.Email && x.Sifre == p.Sifre);

            try
            {
                if (bilgiler != null)
                {
                    string fromEmail = "ishak-1681@hotmail.com";
                    string fromPassword = "56089.Eren";
                    string toEmail = bilgiler.Email;

                    string kullaniciAdi = bilgiler.KullaniciAdi;

                    using (MailMessage mail = new MailMessage(fromEmail, toEmail))
                    {
                        mail.Subject = "Kulanıcı Adınız";
                        mail.Body = $"Merhaba, kullanıcı adınız: {kullaniciAdi}";

                        using (SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                    ViewBag.Mesaj = "Kullanıcı adınız mail adresinize gönderilmiştir.";
                    return View();
                }
                else
                {
                    ViewBag.Mesaj = "Girdiğniz mail adresi veya şifre yanlıştır.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mesaj = "E-posta gönderme işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                return View();
            }
        }

        private string RandomSifreOlustur(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            return password.ToString();
        }
    }
}