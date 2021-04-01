using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Context;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {

        // GET: Blog
        Context context = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            var bloglar = context.Blogs.ToList();

            return View(bloglar);
        }

        public ActionResult BlogDetay(int id)
        {
            //var blogBul = context.Blogs.Where(x => x.ID == id).ToList();
            
            by.BlogDeger = context.Blogs.Where(x => x.ID == id).ToList();
            by.YorumDeger = context.Yorums.Where(x => x.Blogid == id).ToList();
            return View(by);
        }
        //Yorum yapma olayı
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            //Hangi bloğa yorum yapacaksak onun ıd sine göre getiriyoruz bunuda viewBag ile id yi tasıyoruz
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorum y)
        {
            context.Yorums.Add(y);
            context.SaveChanges();
            Response.Redirect("https://localhost:44323/Blog/Index");
            return PartialView();
        }
    }
}