using System.Linq;
using ConectarDatos;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Entity;
using Newtonsoft.Json.Linq;
using ViajesSinAsignar = MiWebAPI.Operations.ViajesSinAsignar;
using System.Collections.Generic;
using MiWebAPI.Operations;

namespace MiWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "*", SupportsCredentials = true)]
    public class ViajesController : ApiController
    {

        private AgenciaViajesEntities dbContext = new AgenciaViajesEntities();


        // GET: Busqueda de Viaje
        [HttpGet]
        public Viajes Get(long id)
        {
            using (AgenciaViajesEntities viajesEntities = new AgenciaViajesEntities())
            {
                return viajesEntities.Viajes.FirstOrDefault(e => e.id_viaje == id);
            }
        }

        /*[HttpPut]
        public IHttpActionResult ActualizarViaje(long id, [FromBody] Viajes viaje)
        {


            if (ModelState.IsValid)
            {
                var ViajeExiste = dbContext.Viajes.Count(c => c.id_viaje == id) > 0;

                if (ViajeExiste)
                {
                    dbContext.Entry(viaje).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }

        }

       
        [HttpDelete]
        public IHttpActionResult EliminarViajero(long id)
        {
            var viaje = dbContext.Viajes.Find(id);

            if (viaje != null)
            {
                dbContext.Viajes.Remove(viaje);
                dbContext.SaveChanges();

                return Ok(viaje);
            }
            else
            {
                return NotFound();
            }
        }*/


        // GET: Busqueda de Viajes sin asignar
        [HttpGet]
        [Route("api/ViajesSinAsignar")]
        public JObject DoViajesSinAsignar()
        {
            return ViajesSinAsignar.ViajesDisponibles();
        }

        // GET: Busqueda de Viajes asignados
        [HttpGet]
        [Route("api/ViajesAsignados")]
        public JObject DoViajesAsignado()
        {
            return ViajesSinAsignar.ViajesNoDisponibles();
        }


        // POST: Agregar viajes (Se puede asignar el viaje al viajero o puede estar nulo)
        [HttpPost]
        [Route("api/AgregarViaje")]
        public IHttpActionResult AgregarViaje([FromBody] Viajes viaje)
        {
            if (ModelState.IsValid)
            {
                dbContext.Viajes.Add(viaje);
                dbContext.SaveChanges();
                return Ok(viaje);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: Actualizar Viajes/ Asignacion al Viajero
        [HttpPost]
        [Route("api/ActualizarViajes")]
        public JObject DoActualizarViajes(JObject context)
        {
            return Crud.ActualizarViaje(context);
        }

        // POST: Eliminar Viaje
        [HttpPost]
        [Route("api/EliminarViaje")]
        public JObject DoEliminarViaje(JObject context)
        {
            return Crud.EliminarViaje(context);
        }

    }
}