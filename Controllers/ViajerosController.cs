using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ConectarDatos;
using System.Data.Entity;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using MiWebAPI.Operations;

namespace MiWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "*", SupportsCredentials = true)]
    public class ViajerosController : ApiController
    {
        private AgenciaViajesEntities dbContext = new AgenciaViajesEntities();

        /*[HttpPut]
        public IHttpActionResult ActualizarViajero(int id, [FromBody] Viajeros via)
        {


            if (ModelState.IsValid)
            {
                var ViajeroExiste = dbContext.Viajeros.Count(c => c.id == id) > 0;

                if (ViajeroExiste)
                {
                    dbContext.Entry(via).State = EntityState.Modified;
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

        }*/

        /*[HttpDelete]
        public IHttpActionResult EliminarViajero(string id)
        {
            var via = dbContext.Viajeros.Find(int.Parse(id));

            if (via != null)
            {
                dbContext.Viajeros.Remove(via);
                dbContext.SaveChanges();

                return Ok(via);
            }
            else
            {
                return NotFound();
            }
        }*/

        // GET: Busqueda de un viajero
        [HttpGet]
        public Viajeros Get(int id)
        {
            using (AgenciaViajesEntities viajerosEntities = new AgenciaViajesEntities())
            {
                return viajerosEntities.Viajeros.FirstOrDefault(e => e.id == id);
            }
        }


        // GET: Busqueda de viajeros
        [HttpGet]
        public IEnumerable<Viajeros> Get()
        {
            using (AgenciaViajesEntities viajerosEntities = new AgenciaViajesEntities())
            {
                return viajerosEntities.Viajeros.ToList();
            }
        }

        // POST: Agregar Viajero
        [HttpPost]
        public IHttpActionResult AgregarViajero([FromBody] Viajeros via)
        {
            if (ModelState.IsValid)
            {
                dbContext.Viajeros.Add(via);
                dbContext.SaveChanges();
                return Ok(via);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: Eliminar viajero
        [HttpPost]
        [Route("api/EliminarViajero")]
        public JObject DoEliminarViajero(JObject context)
        {
            return Crud.EliminarViajero(context);
        }

        // POST: Actualizar viajero
        [HttpPost]
        [Route("api/ActualizarViajero")]
        public JObject DoActualizarViajero(JObject context)
        {
            return Crud.ActualizarViajero(context);
        }

        // POST: Listas de cedulas
        [HttpGet]
        [Route("api/CedulasViajeros")]
        public JObject DoCedulasViajeros()
        {
            return Crud.ListarCedulasViajeros();
        }
    }
}