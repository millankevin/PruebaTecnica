using Dominio.Dto;
using Logica.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        private readonly ITareaLogica _tareaLog;

        public TareaController(ITareaLogica tareaLog)
        {
            _tareaLog = tareaLog;
        }
        [HttpGet]
        [Route("Obtener")]
        public async Task<ActionResult> Obtener()
        {
            return Ok(await _tareaLog.ObtenerTareas());
        }

        [HttpGet]
        [Route("Consultar/{idTarea}")]
        public async Task<ActionResult> Consultar(int idTarea)
        {
            return Ok(await _tareaLog.ConsultarTarea(idTarea));
        }

        [HttpPost]
        [Route("CrearTarea")]
        public async Task<ActionResult> CrearTarea(CrearTareaDto tareaNueva)
        {
            return Ok(await _tareaLog.CrearTarea(tareaNueva));
        }

        [HttpPut]
        [Route("ModificarTarea")]
        public async Task<ActionResult> ModificarTarea(CrearTareaDto tareaNueva)
        {
            return Ok(await _tareaLog.ModificarTarea(tareaNueva));
        }

        [HttpPut]
        [Route("EliminarTarea/{idTarea}")]
        public async Task<ActionResult> EliminarTarea(int idTarea)
        {
            return Ok(await _tareaLog.EliminaTarea(idTarea));
        }
    }
}
