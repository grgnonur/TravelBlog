using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models.Context;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            //girdiğimiz “ var user = context.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);” komutu ile,
            //formdan gelen veriyi “Admins” tablosunda arayarak sonucu “user” isimli değişkene aktardık.
            var user = context.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
            //değişkeninin boş olup olmadığını sorgulayarak,
            //girilen kullanıcı bilgileri ile uyuşan (userName ve password) bir kullanıcının olup olmadığını kontrol ettik.
            if (user != null)
            {
                //(eğer kullanıcı doğru bilgileri vermiş ise) kullanıcıyı sisteme tanıtıyoruz. Bu işlem ile sistem artık kullanıcıyı tanıyor.
                //Parantez içerisinde verdiğimiz bilgi ile kullanıcı bilgisinin ne olarak (hangi isim ile) tutulacağını bildiriyoruz.
                FormsAuthentication.SetAuthCookie(user.Kullanici, false);
                Session["Kullanici"] = user.Kullanici.ToString(); //Session ile kullanıcıyı tutuyor oluyoruz.
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.hataMesaj = "Kullanıcı Adı ve şifreniz yanlış tekrar deneyiniz.";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}