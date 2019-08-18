using System.Data.Objects;
using HMandiola2.Data;
using HMandiola2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HMandiola2.Controllers
{
    public class SeguridadController : Controller
    {
              

        [System.Web.Http.HttpPost]
        public JsonResult validarContrasena(String contrasenaActual)
        {
            String correo = System.Web.HttpContext.Current.Session["Correo"].ToString();
            String resultado = String.Empty;
            String mensaje = String.Empty;
            Boolean valido;

            try
            {
                using (HotelesEntities db = new HotelesEntities())
                {
                    ObjectParameter IsPasswordValid = new ObjectParameter("IsPasswordValid", typeof(Boolean));
                    var result = db.sproc_hoteles_ValidarContrasenaCliente(correo, contrasenaActual, IsPasswordValid);
                    valido = (Boolean)IsPasswordValid.Value;
                }

                if (valido)
                {
                    resultado = "OK";
                    mensaje = String.Empty;
                }
                else
                {
                    resultado = "ERROR";
                    mensaje = "La contraseña no coincide con la contraseña actual";
                }

                return Json(new { Result = resultado, Message = mensaje });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [System.Web.Http.HttpPost]
        public JsonResult cambiarContrasena(String contrasenaActual, String contrasenaNueva)
        {
            String correo = System.Web.HttpContext.Current.Session["Correo"].ToString();
            String resultado = String.Empty;
            String mensaje = String.Empty;
            Boolean cambiada;

            try
            {
                using (HotelesEntities db = new HotelesEntities())
                {
                    ObjectParameter IsPasswordChanged = new ObjectParameter("IsPasswordChanged", typeof(Boolean));
                    var result = db.sproc_hoteles_CambiarContrasenaCliente(correo, contrasenaActual, contrasenaNueva, IsPasswordChanged);
                    cambiada = (Boolean)IsPasswordChanged.Value;                  

                }

                if (cambiada)
                {
                    resultado = "OK";
                    mensaje = String.Empty;
                }
                else
                {
                    resultado = "ERROR";
                    mensaje = "No se pudo cambiar la contraseña.";
                }

                return Json(new { Result = resultado, Message = mensaje });

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }


        }

        [System.Web.Http.HttpGet]
        public ActionResult CambiarContrasenia()
        {
            return View();
        }
    }
}