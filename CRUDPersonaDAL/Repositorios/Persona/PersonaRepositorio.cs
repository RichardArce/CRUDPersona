using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaDAL.Repositorios.Persona
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly ProyectoPersonaContext _context;

        public PersonaRepositorio(ProyectoPersonaContext context)
        {
            _context = context;
        }
        public async Task<CRUDPersonaObjetos.Modelos.Persona> ActualizarPersonaAsync(CRUDPersonaObjetos.Modelos.Persona persona)
        {
            /*var personaExistente = await _context.Personas.FindAsync(persona.Id); // otra forma de actualizar
            if (personaExistente != null)
            {
                personaExistente.Nombre = persona.Nombre;
                personaExistente.Apellido = persona.Apellido;
                personaExistente.Edad = persona.Edad;
                personaExistente.FechaRegistro = persona.FechaRegistro;
                await _context.SaveChangesAsync();
            }*/

            var existente = await _context.Personas.FindAsync(persona.Id);
            if (existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(persona);
            _context.Entry(existente).Property(p => p.FechaRegistro).IsModified = false;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<CRUDPersonaObjetos.Modelos.Persona> CrearPersonaAsync(CRUDPersonaObjetos.Modelos.Persona persona)
        {
            //await _context.Personas.AddAsync(persona); // otra forma de guardar
            //await _context.SaveChangesAsync();

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<bool> EliminarPersonaAsync(int id)
        {
            //var persona = await _context.Personas.FindAsync(id); // otra forma de eliminar
            //if (persona != null)
            //{
            //    _context.Personas.Remove(persona);
            //    await _context.SaveChangesAsync();
            //}
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return false;

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CRUDPersonaObjetos.Modelos.Persona> ObtenerPersonaPorIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<List<CRUDPersonaObjetos.Modelos.Persona>> ObtenerPersonasAsync()
        {
            return await _context.Personas.ToListAsync();
        }

    }
}
