using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Siniflar
{
    public class Yorum
    {
        [Key]
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorumlar { get; set; }
        public int Blogid{ get; set; }
        //ilişkili tablo ayarı Bir yorumun sadece bir blogu olabilir
        public virtual Blog Blog { get; set; }

    }
}