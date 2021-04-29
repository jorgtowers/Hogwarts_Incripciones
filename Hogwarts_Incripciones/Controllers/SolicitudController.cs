using Hogwarts_Incripciones.Models;
using Hogwarts_Incripciones.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hogwarts_Incripciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        SolicitudRepository model = new SolicitudRepository();

         // GET: api/<SolicitudController>
         [HttpGet("Consultar")]
        public ActionResult<Respuesta<bool>> Consultar()
        {
            IEnumerable<Solicitud> data = model.Listado().ToList();

            Respuesta<bool> respuesta = new Respuesta<bool>()
            {
                CantidadItems = 0,
                Item = null,
                Items = null,
                Notificacion = "No existen registros"
            };
            if (data != null)
            {
                respuesta.OK = true;
                respuesta.Item = null;
                respuesta.Items = data.ToArray();
                respuesta.Notificacion = "Listado de todas las Solicitudes";
                respuesta.CantidadItems = data.Count();
            }
            return Ok(respuesta);

        }

        // GET api/<SolicitudController>/5
        [HttpGet("Consultar/{identificacion}")]
        public ActionResult<Respuesta<bool>> Consultar(int identificacion)
        {
            Solicitud solicitud = model.Obtener(identificacion);
            Respuesta<bool> respuesta = new Respuesta<bool>()
            {
                CantidadItems = 0,
                Item = null,
                Items = null,
                Notificacion = "No existen registros"
            };
            if (solicitud != null)
            {
                respuesta.OK = true;
                respuesta.Item = solicitud;
                respuesta.Items = null;
                respuesta.Notificacion = "Registro con identificador " + identificacion;
                respuesta.CantidadItems = 1;
            }
            return Ok(respuesta);
        }

        // POST api/<SolicitudController>
        [ValidateModel]
        [HttpPost("Enviar")]       
        public ActionResult<Respuesta<bool>> Post([FromBody] Solicitud value)
        {
            try
            {
                model.Agregar(value);
                Respuesta<bool> respuesta = new Respuesta<bool>()
                {
                    OK = true,
                    Item = value,
                    Items = model.Listado().ToArray(),
                    Notificacion = $"Registro {value.Identificacion} agregado con exito",
                    CantidadItems = model.Listado().Count()
                };
                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // PUT api/<SolicitudController>/5
        [HttpPut("Actualizar/{identificacion}")]
        public ActionResult<Respuesta<bool>> Put(int identificacion, [FromBody] Solicitud value)
        {
            try
            {
                model.Modificar(identificacion, value);
                Respuesta<bool> respuesta = new Respuesta<bool>()
                {
                    OK = true,
                    Item = value,
                    Items = model.Listado().ToArray(),
                    Notificacion = $"Registro {value.Identificacion} modificador con exito",
                    CantidadItems = model.Listado().Count()
                };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
                 
        }

        // DELETE api/<SolicitudController>/5
        [HttpDelete("Eliminar/{identificacion}")]
        public ActionResult<Respuesta<bool>> Delete(int identificacion)
        {
            try
            {
                model.Eliminar(model.Obtener(identificacion));
                Respuesta<bool> respuesta = new Respuesta<bool>()
                {
                    OK = true,
                    Item = null,
                    Items = model.Listado().ToArray(),
                    Notificacion = $"Registro {identificacion} eliminado con exito",
                    CantidadItems = model.Listado().Count()
                };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
    }
}
