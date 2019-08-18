using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using HMandiola2.Models;
using Newtonsoft.Json;

namespace HMandiola2.Classes
{
    public class ManejoDeErrores
    {
        public string errorBaseDeDatos(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }

            var responseModel = new ResponseModel
            {
                Success = false,
                Message = "Error"
            };

            return JsonConvert.SerializeObject(responseModel);
        }




        public string errorGeneral(Exception e)
        {
            var responseModel = new ResponseModel
            {
                Success = false,
                Message = "Error"
            };

            return JsonConvert.SerializeObject(responseModel);
        }
    }
}