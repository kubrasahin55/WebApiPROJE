using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;//ekledik
using mvcsiparis.Models;//ekledik

namespace mvcsiparis.Controllers
{
    public class siparislerController : Controller
    {
        // GET: siparisler
        public ActionResult Index() //buna add view yap list seç model classı tablo adını seç use olan seçili sadece
        {
            IEnumerable<mvcsiparisler> calList;
            HttpResponseMessage response = golabalvariables.WepApiClient.GetAsync("tblsiparislers").Result; //wepapicrudmvc içindeki siparislers webapinin içindeki neyse oraya bağlanıp sonuçları gtiriyor. buradan indexe gel add view empty list seç
            calList = response.Content.ReadAsAsync<IEnumerable<mvcsiparisler>>().Result;
            return View(calList);
        }
        public ActionResult Ekle(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcsiparisler());
            }
            else
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.GetAsync("tblsiparislers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcsiparisler>().Result);
            }
        }
        [HttpPost]
        public ActionResult Ekle(mvcsiparisler siparis)
        {
            if (siparis.siparisid == 0)
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.PostAsJsonAsync("tblsiparislers", siparis).Result;
                TempData["successMessage"] = "başarılı şekilde kaydedildi";/*controllerdan viewlara veri taşır tempdata ve viewbag*/
            }
            else
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.PutAsJsonAsync("tblsiparislers/" + siparis.siparisid, siparis).Result;
                TempData["successMessage"] = "update başarılı";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = golabalvariables.WepApiClient.DeleteAsync("tblsiparislers/" + id.ToString()).Result;
            TempData["successMessage"] = "silme başarılı";
            return RedirectToAction("Index");
        }
    }
}