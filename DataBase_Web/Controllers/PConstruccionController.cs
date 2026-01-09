using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBase_Web.Data;
using DataBase_Web.Data.Models_Tablas;

namespace DataBase_Web.Controllers
{
    [Route("api/[controller]")] // La URL será: midominio.com/api/PConstruccion
    [ApiController]
    public class PConstruccionController : ControllerBase
    {
        private readonly ApplicationDbContex _context;

        public PConstruccionController(ApplicationDbContex context)
        {
            _context = context;
        }

        // Este es el método que recibirá la lista desde Revit
        [HttpPost]
        public async Task<IActionResult> SyncRevitData([FromBody] List<PConstruccion> elementosRevit)
        {
            if (elementosRevit == null || elementosRevit.Count == 0)
                return BadRequest("La lista de elementos está vacía.");

            try
            {
                foreach (var item in elementosRevit)
                {
                    // Buscamos si ya existe el elemento por su GUID (Key)
                    var existente = await _context.PConstruccions
                        .FirstOrDefaultAsync(x => x.ElementGUID == item.ElementGUID);

                    if (existente != null)
                    {
                        // ACTUALIZAR campos si ya existe
                        existente.ElementID = item.ElementID;
                        existente.Category = item.Category;
                        existente.ElementName = item.ElementName;
                        existente.FechaProgramada = item.FechaProgramada;
                        existente.FechaEjecutada = item.FechaEjecutada;
                    }
                    else
                    {
                        // INSERTAR si es nuevo
                        _context.PConstruccions.Add(item);
                    }
                }

                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Sincronización completa", total = elementosRevit.Count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // Método opcional para ver los datos desde el navegador (GET)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PConstruccion>>> GetDatos()
        {
            return await _context.PConstruccions.ToListAsync();
        }
    }
}