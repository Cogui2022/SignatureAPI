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
    public class GenerateWinSignatureController : ControllerBase
    {
        GenerateWinSignatureServicio CrearServicio()
        {
            RolContexto db = new RolContexto();
            RolRepositorio repo = new RolRepositorio(db);
            GenerateWinSignatureServicio servicio = new GenerateWinSignatureServicio(repo);
            return servicio;
        }
        //// GET: api/<GenerateWinSignatureController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<GenerateWinSignatureController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<GenerateWinSignatureController>
        [HttpPost]
        public ActionResult<Contract> Post([FromBody] List<Contract> Contrats)
        {
            var servicion = CrearServicio();
            if (Contrats != null)
            {
                if (servicion.GenerateWinSignature(Contrats) != null)
                {
                    return Ok("La firma necesaria para ganar el juicio es:" + servicion.GenerateWinSignature(Contrats));
                }
                return UnprocessableEntity("No ha habido respuesa de firma");
            }
            return UnprocessableEntity("No hay contratos para generar firma");
        }

        //// PUT api/<GenerateWinSignatureController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GenerateWinSignatureController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
