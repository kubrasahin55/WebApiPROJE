using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//ekledik

namespace mvcsiparis.Models
{
    public class mvcsiparisler
    {
        public int siparisid { get; set; }
        [Required(ErrorMessage = "ad girilmesi zorunludur")] //veri girilmediğinde uyarı veren attribute
        public string siparisadi { get; set; }
        public string siparistarihi { get; set; }
      
    }
}