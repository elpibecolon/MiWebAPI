using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ConectarDatos;
using System.Data.Entity;
using Newtonsoft.Json.Linq;
using MiWebAPI.Operations;
using System.Web.Http.Cors;

namespace MiWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "*", SupportsCredentials = true)]
    public class UsuariosController : ApiController
    {
        private AgenciaViajesEntities dbContext = new AgenciaViajesEntities();

        //Visualiza todos los registros (api/Usuarios)
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            using (AgenciaViajesEntities usuariosEntities = new AgenciaViajesEntities())
            {
                return usuariosEntities.Usuarios.ToList();
            }
        }

        [HttpGet]
        public Usuarios Get(int id)
        {
            using (AgenciaViajesEntities usuariosEntities = new AgenciaViajesEntities())
            {
                return usuariosEntities.Usuarios.FirstOrDefault(e => e.id == id);
            }
        }


        [HttpPost]
        [Route("api/Auth")]
        public JObject DoLogin(JObject context)
        {
            return Auth.Autenticacion(context);
        }

        [HttpPost]
        public IHttpActionResult AgregarUsuario([FromBody] Usuarios usu)
        {
            if (ModelState.IsValid)
            {
                dbContext.Usuarios.Add(usu);
                dbContext.SaveChanges();
                return Ok(usu);
            }
            else
            {
                return BadRequest();
            }
        }



        [HttpPut]
        public IHttpActionResult ActualizarUsuario(int id, [FromBody] Usuarios usu)
        {
            

            if (ModelState.IsValid)
            {
                var UsuarioExiste = dbContext.Usuarios.Count(c => c.id == id) > 0;

                if (UsuarioExiste)
                {
                    dbContext.Entry(usu).State = EntityState.Modified;
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
        public IHttpActionResult EliminarUsuario(int id)
        {
            var usu = dbContext.Usuarios.Find(id);

            if (usu != null)
            {
                dbContext.Usuarios.Remove(usu);
                dbContext.SaveChanges();

                return Ok(usu);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
