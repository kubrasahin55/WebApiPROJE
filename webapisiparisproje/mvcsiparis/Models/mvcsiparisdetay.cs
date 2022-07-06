using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//ekledik

namespace mvcsiparis.Models
{
    public class mvcsiparisdetay
    {
        public int siparisdetayid { get; set; }
        [Required(ErrorMessage = "ad girilmesi zorunludur")] //veri girilmediğinde uyarı veren attribute
        public string siparisaciklama { get; set; }
        public int siparisadet { get; set; }
        public int siparisfiyat { get; set; }
       
    }
}