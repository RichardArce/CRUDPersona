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

namespace CRUDPersona.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaServicio _personaServicio;

        public PersonaController(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            return View(await _personaServicio.ObtenerPersonasAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            var persona = await _personaServicio.ObtenerPersonaPorIdAsync(id.Value);
            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
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
