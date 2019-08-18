using HMandiola2.Data;
using HMandiola2.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

using System.Net.Http;
using System.Web.Http;
using HMandiola2.Classes;
using Newtonsoft.Json;

namespace HMandiola2.Controllers
{
    public class LoginController : Controller
    {
        ManejoDeErrores manejoDeErrores = new ManejoDeErrores();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public string Login(Cliente cliente)
        {
            HotelesEntities db = new HotelesEntities();
            try
            {
                List<sproc_hoteles_LoginCliente_Result> clienteLogin = db.sproc_hoteles_LoginCliente(cliente.Correo, cliente.Contrasena).ToList();
                bool isSuccess = false;
                if (clienteLogin.Count >= 1)
                {
                    System.Web.HttpContext.Current.Session["clienteLogueado"] = clienteLogin[0];
                    isSuccess = true;
                }
                else
                {
                    System.Web.HttpContext.Current.Session["clienteLogueado"] = null;
                }


                var responseModel = new ResponseModel
                {
                    Success = isSuccess
                };

                return JsonConvert.SerializeObject(responseModel);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(manejoDeErrores.errorGeneral(ex));
            }
        }

        [System.Web.Http.HttpPost]
        public string RegistrarCliente([FromBody]Cliente cliente, string repetir_contrasena)
        {
            HotelesEntities db = new HotelesEntities();

            try
            {
                //estado activo
                if(cliente.EstadoCliente_ID_EstadoCli >0)
                db.sproc_hoteles_InsertCliente(cliente.Cedula, cliente.EstadoCliente_ID_EstadoCli, cliente.Nombre, cliente.PrimerApellido, cliente.SegundoApellido, cliente.Correo, cliente.Contrasena);
               

                var responseModel = new ResponseModel
                {
                    Success = true,
                    Message = "Cliente registrado"
                };

                return JsonConvert.SerializeObject(responseModel);
            }
            catch (DbEntityValidationException e)
            {
                return JsonConvert.SerializeObject(manejoDeErrores.errorBaseDeDatos(e));
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(manejoDeErrores.errorGeneral(ex));
            }
        }
    }
}
