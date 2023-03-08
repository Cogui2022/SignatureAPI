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
      
        // POST api/<GenerateWinSignatureController>
        [HttpPost]
        public ActionResult<Contract> Post([FromBody] List<Contract> Contrats)
        {
            var servicion = CrearServicio();
            if (Contrats != null)
            {
                if (Contrats.Count > 0)
                {
                    if (servicion.GenerateWinSignature(Contrats) != null)
                    {
                        return Ok("La firma necesaria para ganar el juicio es:" + servicion.GenerateWinSignature(Contrats));
                    }
                    return UnprocessableEntity("No ha habido respuesa de firma");
                }
                else
                {
                    return Ok("Se necesitan dos contratos para poder generar una firma valida");
                }
                
            }
            return UnprocessableEntity("No hay contratos para generar firma");
        }

      
    }
}
