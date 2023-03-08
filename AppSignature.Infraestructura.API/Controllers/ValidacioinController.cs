using AppSignature.Aplicaciones.Servicios;
using AppSignature.Dominio;
using AppSignature.Infraestructura.Datos.Contextos;
using AppSignature.Infraestructura.Datos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppSignature.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidacioinController : ControllerBase
    {
        ValidacionServicio CrearServicio()
        {
            RolContexto db = new RolContexto();
            RolRepositorio repo = new RolRepositorio(db);
            ValidacionServicio servicio = new ValidacionServicio(repo);
            return servicio;
        }
        //// GET: api/<ValidacioinController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ValidacioinController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValidacioinController>
        [HttpPost]
        public ActionResult<Contract>? Post([FromBody] List<Contract> validationContrats)
        {
            var servicion = CrearServicio();
            if (validationContrats != null)
            {
              
                return Ok(servicion.Validar(validationContrats));
            }
            return UnprocessableEntity("No hay contratos para validar");
        }

       
        //// PUT api/<ValidacioinController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValidacioinController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
