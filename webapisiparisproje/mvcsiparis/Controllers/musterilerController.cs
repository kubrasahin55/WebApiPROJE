using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;//ekledik
using mvcsiparis.Models;//ekledik

namespace mvcsiparis.Controllers
{
   
    public class musterilerController : Controller
    {
        // GET: musteriler
        public ActionResult Index()
        {
            IEnumerable<mvcmusterilermodel> calList;
            HttpResponseMessage response = golabalvariables.WepApiClient.GetAsync("tblmusterilers").Result; //wepapicrudmvc içindeki musterilers webapinin içindeki neyse oraya bağlanıp sonuçları gtiriyor
            calList = response.Content.ReadAsAsync<IEnumerable<mvcmusterilermodel>>().Result;
            return View(calList);
        }
        public ActionResult Ekle(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcmusterilermodel());
            }
            else
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.GetAsync("tblmusterilers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcmusterilermodel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Ekle(mvcmusterilermodel musteri)
        {
            if (musteri.musteriid == 0)
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.PostAsJsonAsync("tblmusterilers", musteri).Result;
                TempData["successMessage"] = "başarılı şekilde kaydedildi";/*controllerdan viewlara veri taşır tempdata ve viewbag*/
            }
            else
            {
                HttpResponseMessage response = golabalvariables.WepApiClient.PutAsJsonAsync("tblmusterilers/" + musteri.musteriid, musteri).Result;
                TempData["successMessage"] = "update başarılı";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = golabalvariables.WepApiClient.DeleteAsync("tblmusterilers/" + id.ToString()).Result;
            TempData["successMessage"] = "silme başarılı";
            return RedirectToAction("Index");
        }
    }
}