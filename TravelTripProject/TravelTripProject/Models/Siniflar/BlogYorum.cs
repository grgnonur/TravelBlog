using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Siniflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> BlogDeger { get; set; }
        public IEnumerable<Yorum> YorumDeger { get; set; }
    }
}