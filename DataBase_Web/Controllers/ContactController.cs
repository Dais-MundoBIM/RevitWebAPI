using System.Diagnostics;
using DataBase_Web.Data;
using DataBase_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBase_Web.Data.Models_Tablas;


namespace DataBase_Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        private readonly ApplicationDbContex _context;

        public ContactController(ILogger<ContactController> logger, ApplicationDbContex contex)
        {
            _logger = logger;
            _context = contex;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contacts.ToListAsync(); //si en SQL Select*From Contacts llamamos al tabla

            return View(contacts); //nos muestra la vista la tabla
        }

        //METODO HTTP (SIEMPRE ES OBTENR Y LANZARR GET Y POST


        //CREAMOS OTRO METODO PAR VER O EDITAR LA DBASE ,  SOLO REVISA INFORMACION
        [HttpGet]//PAR OBTNER INFORMACION EN LA BASE ED DATOS
        public IActionResult Create()
        {

            return View();
        }

        //[HttpPut] //ACTULIZAR INFORAMCON EN LA BASE DE DATOS
        //[HttpDelete] //ELIMAR INFORAMCION DELA DB



        [HttpPost] //ENVIAMOS INFORAMCION AMI BASE DE DATO
        [ValidateAntiForgeryToken] // valid que si te quedas mucho tiempo envie la inforamcion. vlaida que el token del formulario este vigente
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)   //CON ESOTO VALIDAMO QUE INFORMACION SE CUMPLA COMO SE PIDA EN EL DATA ANOTATIONS
            {
                // 1. Obtiene la hora actual de tu PC (que es la hora de Perú, UTC-5)
                var horaLocalPeru = DateTime.Now;

                // 2. 🚀 SOLUCIÓN: Cambia la 'bandera Kind' de Local a UTC, 
                //    MANTENIENDO el valor numérico (la hora de Perú).
                //    Esto satisface la restricción de Npgsql.
                contact.Date_Create = DateTime.SpecifyKind(horaLocalPeru, DateTimeKind.Utc);


                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));


            }
            return View();

        }


        [HttpGet]//PAR OBTNER INFORMACION EN LA BASE ED DATOS
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }


            return View(contact);
        }

        [HttpPost] // ENVIAMOS INFORMACION A MI BASE DE DATO
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)   //CON ESOTO VALIDAMO QUE INFORMACION SE CUMPLA COMO SE PIDA EN EL DATA ANOTATIONS
            {
                // 1. Obtiene la hora actual de tu PC (que es la hora de Perú, UTC-5)
                var horaLocalPeru = DateTime.Now;

                // 2. 🚀 SOLUCIÓN: Cambia la 'bandera Kind' de Local a UTC, 
                //    MANTENIENDO el valor numérico (la hora de Perú).
                //    Esto satisface la restricción de Npgsql.
                contact.Date_Create = DateTime.SpecifyKind(horaLocalPeru, DateTimeKind.Utc);


                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));


            }
            return View();

        }

        [HttpGet]//PAR OBTNER INFORMACION EN LA BASE ED DATOS
        public IActionResult Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }


            return View(contact);
        }






        [HttpGet]//PAR OBTNER INFORMACION EN LA BASE ED DATOS
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }


            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {

            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return View();


            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }











        public IActionResult Privacy()
        {

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
