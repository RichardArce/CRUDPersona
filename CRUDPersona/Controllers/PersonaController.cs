using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDPersonaDAL;
using CRUDPersonaObjetos.Modelos;
using CRUDPersonaBLL.Servicios.Persona;
using CRUDPersonaObjetos.ViewModelos;
using CRUDPersonaBLL.Servicios.Provincia;

namespace CRUDPersona.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaServicio _personaServicio;
        private readonly IProvinciaServicio _provinciaServicio;

        public PersonaController(IPersonaServicio personaServicio, IProvinciaServicio provinciaServicio)
        {
            _personaServicio = personaServicio;
            _provinciaServicio = provinciaServicio;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var mascotas = new List<MascotaViewModelo>
            {
                new MascotaViewModelo
                {
                    Nombre = "Firulais",
                    Tipo = "Perro"
                },
                new MascotaViewModelo
                {
                    Nombre = "Rambo",
                    Tipo = "Gato"
                }
            };


            var personas = await _personaServicio.ObtenerPersonasAsync();

            foreach (var persona in personas)
            {
                // Asignar las mascotas a cada persona
                persona.Mascotas = mascotas;
            }


            return View(personas);
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            var persona = await _personaServicio.ObtenerPersonaPorIdAsync(id.Value);
            return View(persona);
        }

        // GET: Personas/Create
        public async Task<IActionResult> Create()
        {
            // Aquí podrías cargar las provincias si es necesario
            ViewBag.ProvinciaIdfk = new SelectList(await _provinciaServicio.ObtenerProvinciasAsync(),"Id","Nombre");    
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonaViewModelo persona)
        {
            if (ModelState.IsValid)
            {
                var p = _personaServicio.CrearPersonaAsync(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var persona = await _personaServicio.ObtenerPersonaPorIdAsync(id.Value);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonaViewModelo persona)
        {
            if (ModelState.IsValid)
            {
                await _personaServicio.ActualizarPersonaAsync(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var persona = await _personaServicio.ObtenerPersonaPorIdAsync(id.Value);

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personaServicio.EliminarPersonaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
