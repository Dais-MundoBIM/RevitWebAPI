using System.Diagnostics;
using DataBase_Web.Data;
using DataBase_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBase_Web.Data.Models_Tablas;






namespace DataBase_Web.Controllers
{
    public class VelascoAlvaradoController : Controller
    {

        private readonly ILogger<VelascoAlvaradoController> _logger;

        private readonly ApplicationDbContex _context;

        public VelascoAlvaradoController(ILogger<VelascoAlvaradoController> logger, ApplicationDbContex contex)
        {
            _logger = logger;
            _context = contex;
        }

        public async Task<IActionResult> Velasco_Estructuras_469()
        {
            var Velasco_Estructuras_469 = await _context.PConstruccions.ToListAsync(); //si en SQL Select*From Contacts llamamos al tabla

            return View(Velasco_Estructuras_469); //nos muestra la vista la tabla
        }

















        // Esta es la acción que definiste en el asp-action="VelascoIndex"
        public IActionResult Velasco_Index()
        {
            // Aquí podrías luego buscar datos específicos de este colegio en la DB
            return View();
        }


        public IActionResult Velasco_Contenedor()
        {
            // Aquí podrías luego buscar datos específicos de este colegio en la DB
            return View();
        }




    }
}
