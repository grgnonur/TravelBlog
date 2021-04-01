using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Context;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{

    public class HomePageController : Controller
    {
        Context context = new Context();
        // GET: HomePage
        public ActionResult Index()
        {
            var resim = context.Blogs.ToList();
            return View(resim);
        }

        public ActionResult About()
        {
            var degerler = context.Hakkimizdas.ToList();
            return View(degerler);
        }

        public PartialViewResult Partial()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(5).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial3()
        {
            var degerler = context.Blogs.Take(3).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial4()
        {
            var degerler = context.Blogs.Take(3).OrderByDescending(x => x.ID).ToList();
            return PartialView(degerler);
        }
    }
}