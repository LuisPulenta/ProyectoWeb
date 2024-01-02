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
        [Route("detail/{month}/{year}")]
        public async Task<ActionResult> Get(int month, int year)
        {

            var asignaciones = await _context.AsignacionesOTs
                .Where(x => x.PROYECTOMODULO == "Tasa"
                        //&& x.DECO1 == "HGU"
                        //&& x.IDREGISTRO<= 1865240
                        && x.Fc_inicio_base!.Value.Month == month
                        && x.Fc_inicio_base.Value.Year == year)
                .OrderBy(x => x.IDREGISTRO)
                .ToListAsync();


            return Ok(asignaciones);
        }

        [HttpGet]
        [Route("count/{month}/{year}")]
        public async Task<ActionResult> GetCount(int month, int year)
        {
            var cantidad = await _context.AsignacionesOTs
                .Where(x => x.PROYECTOMODULO == "Tasa"
                        //&& x.DECO1 == "HGU"
                        //&& x.IDREGISTRO <= 1865240
                        && x.Fc_inicio_base!.Value.Month == month
                        && x.Fc_inicio_base.Value.Year == year)
                .CountAsync();

            return Ok(cantidad);
        }     
    }
}
