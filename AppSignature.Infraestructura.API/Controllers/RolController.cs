using AppSignature.Aplicaciones.Servicios;
using AppSignature.Dominio;
using AppSignature.Infraestructura.Datos.Contextos;
using AppSignature.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppSignature.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        RolServicio CrearServicio()
        {
            RolContexto db= new RolContexto();
            RolRepositorio repo = new RolRepositorio(db);
            RolServicio servicio = new RolServicio(repo);
            return servicio;
        }

        // GET: api/<RolController>
        [HttpGet]
        public ActionResult<List<Rol>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public ActionResult<Rol> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<RolController>
        [HttpPost]
        public ActionResult Post([FromBody] Rol rol)
        {
            var servicio = CrearServicio();
            servicio.Agregar(rol);
            return Ok("Rol Agregado correctamente");
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Rol Eliminado correctamente");

        }
    }
}
