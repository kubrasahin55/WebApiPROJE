using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//ekledik

namespace mvcsiparis.Models
{
    public class mvcmusterilermodel
    {
        public int musteriid { get; set; }
        [Required(ErrorMessage = "ad girilmesi zorunludur")] //veri girilmediğinde uyarı veren attribute
        public string ad { get; set; }
        public string soyad { get; set; }
        public string adres { get; set; }
        public string sehir { get; set; } 
    }
}
