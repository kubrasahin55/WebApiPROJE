using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;//ekledik
using mvcsiparis.Models;//ekledik

namespace mvcsiparis.Controllers
{
    public class siparisdetayController : Controller
    {
        // GET: siparisdetay
        public ActionResult Index()
        {
            IEnumerable<mvcsiparisdetay> calList;
            HttpResponseMessage response = golabalvariables.WepApiClient.GetAsync("tblsiparisdetays").Result; //wepapicrudmvc içindeki siparislers webapinin içindeki neyse oraya bağlanıp sonuçları gtiriyor
            calList = response.Content.ReadAsAsync<IEnumerable<mvcsiparisdetay>>().Result;
            return View(calList);
        }
        public ActionResult Ekle(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcsiparisdetay());
            }
            else
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.GetAsync("tblsiparisdetays/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcsiparisdetay>().Result);
            }
        }
        [HttpPost]
        public ActionResult Ekle(mvcsiparisdetay siparisdetay)
        {
            if (siparisdetay.siparisdetayid == 0)
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.PostAsJsonAsync("tblsiparisdetays", siparisdetay).Result;
                TempData["successMessage"] = "başarılı şekilde kaydedildi";/*controllerdan viewlara veri taşır tempdata ve viewbag*/
            }
            else
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.PutAsJsonAsync("tblsiparisdetays/" + siparisdetay.siparisdetayid, siparisdetay).Result;
                TempData["successMessage"] = "update başarılı";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = golabalvariables.WepApiClient.DeleteAsync("tblsiparisdetays/" + id.ToString()).Result;
            TempData["successMessage"] = "silme başarılı";
            return RedirectToAction("Index");
        }
    }
}