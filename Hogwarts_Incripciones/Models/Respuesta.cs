using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts_Incripciones.Models
{
    /// <summary>
    /// Objeto de Respuesta a la solicitudes de controller
    /// </summary>
    public class Respuesta<T>
    {
        public bool OK { get; set; }
        public Solicitud Item { get; set; }
        public Dictionary<string, List<string>> Errores { get; set; }
        public string Notificacion { get; set; }
        public int CantidadItems { get; set; }
        public Solicitud[] Items { get; set; }

    }
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Respuesta<bool> respuesta = new Respuesta<bool>
                {
                    OK = false,
                    Notificacion = "Uno o mas errores ocurrieron durante la ejecución",
                    Errores = new Dictionary<string, List<string>>()
                };

                foreach (var modelState in context.ModelState)                
                    respuesta.Errores.Add(modelState.Key, modelState.Value.Errors.Select(a => a.ErrorMessage).ToList());              

                
                context.Result = new BadRequestObjectResult(respuesta);
            }
        
        }
    }
}
