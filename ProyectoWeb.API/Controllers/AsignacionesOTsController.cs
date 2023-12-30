using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProyectoWeb.API.Controllers
{
    [ApiController]
    [Route("/api/asignacionesots")]
    public class AsignacionesOTsController : ControllerBase
    {
        private readonly DataContext _context;

        public AsignacionesOTsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {

            var asignaciones = await _context.AsignacionesOTs
                .Where(x => x.PROYECTOMODULO == "Tasa" && x.Fc_inicio_base.Value.Month == 12 && x.Fc_inicio_base.Value.Year == 2023)
                .OrderBy(x => x.IDREGISTRO)
                .ToListAsync();


            return Ok(asignaciones);
        }

        [HttpGet("count")]
        public async Task<ActionResult> GetCount()
        {
            var cantidad = await _context.AsignacionesOTs
                .Where(x => x.PROYECTOMODULO == "Tasa" && x.Fc_inicio_base.Value.Month == 12 && x.Fc_inicio_base.Value.Year == 2023)
                .CountAsync();

            return Ok(cantidad);
        }     
    }
}
