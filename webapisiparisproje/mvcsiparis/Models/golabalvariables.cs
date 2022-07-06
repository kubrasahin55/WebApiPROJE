using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http; //ekledik
using System.Net.Http.Headers; //ekledik

namespace mvcsiparis.Models
{
    public static class golabalvariables//static yaptık nesne üretmeden çağırabilmek için
    {
        public static HttpClient WepApiClient = new HttpClient();

        static golabalvariables()
        {
            WepApiClient.BaseAddress = new Uri("http://localhost:56374/api/"); //api programının urlsi eklediğimiz clientle buraya erişip crud işlemlerine erişecek
            WepApiClient.DefaultRequestHeaders.Clear();
            WepApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //jsonu kullanarak verileri getirir. hangi başlıklarla çalışacağını belirtir. json mı xml mi.üstüne geldiğinde eklenmesi gereken kütüphaneyi gösterir
        }
    }
}