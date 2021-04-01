using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Context;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }

        //Sayfa yüklendiği zaman çalışacak Sayfa açıldığında bize sayfayı getirecek boş halini getirecek
        [Authorize]
        [HttpGet] 
        public ActionResult YeniBlog()
        {
            return View();
        }
        //Sayfada bir şey gönder işlemi yaptığımda çalışacak
        //Bizden burada parametre bekliyor yeni blog eklicemiz için blog üzerinde parametre yolluyoruz.
        [Authorize]
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            context.Blogs.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DeleteBlog(int id)
        {
            var delete = context.Blogs.Find(id);
            context.Blogs.Remove(delete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var blog = context.Blogs.Find(id);
            return View("BlogGetir", blog);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = context.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YourmListesi()
        {
            var degerler = context.Yorums.ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult DeleteYorum(int id)
        {
            var delete = context.Yorums.Find(id);
            context.Yorums.Remove(delete);
            context.SaveChanges();
            return RedirectToAction("YourmListesi");
        }
        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var deger = context.Yorums.Find(id);
            return View("YorumGetir",deger);
        }

        public ActionResult YorumGuncelle(Yorum y)
        {
            var yrm = context.Yorums.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorumlar = y.Yorumlar;
            yrm.Blog.Baslik = y.Blog.Baslik;
            context.SaveChanges();
            return RedirectToAction("YourmListesi");
        }
    }
}