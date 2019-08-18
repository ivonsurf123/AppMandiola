using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using HMandiola2.Data;
using Newtonsoft.Json;

namespace HMandiola2.Controllers
{
    public class ReservaController : Controller
    { 
            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult ValidarCatcha(string empty)
            {
                // Code for validating the CAPTCHA  
                if (this.IsCaptchaValid("Captcha no es válido"))
                {

                    return RedirectToAction("../RegistraReserva");
                }

                ViewBag.ErrMessage = "Error: Captcha no es válido.";
                return View();
            }

        [HttpPost]
        public ActionResult LoadHab()
        {

            HotelesEntities db = new HotelesEntities();
            List<sproc_hoteles_GetHabitacionList_Result> listaHabitacion = db.sproc_hoteles_GetHabitacionList().ToList();

            return Json(listaHabitacion.AsEnumerable(), JsonRequestBehavior.AllowGet);
             
        }

          
    }
}