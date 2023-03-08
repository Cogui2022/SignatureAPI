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
    public class ValidacionController : ControllerBase
    {
        ValidacionServicio CrearServicio()
        {
            RolContexto db = new RolContexto();
            RolRepositorio repo = new RolRepositorio(db);
            ValidacionServicio servicio = new ValidacionServicio(repo);
            return servicio;
        }
       
        // POST api/<ValidacioinController>
        [HttpPost]
        public ActionResult<Contract>? Post([FromBody] List<Contract> validationContrats)
        {
            var servicion = CrearServicio();
            if (validationContrats != null)
            {
              if(validationContrats.Count > 1)
                {
                    return Ok(servicion.Validar(validationContrats));
                }
                else
                {
                    return Ok("Se necesitan dos contratos para poder validar");
                }
                
            }
            return UnprocessableEntity("No hay contratos para validar");
        }

      
    }
}
