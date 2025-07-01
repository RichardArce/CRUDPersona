using CRUDPersonaDAL.Repositorios.Persona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaDAL.Repositorios.Provincia
{
    public class ProvinciaRepository : IProvinciaRepositorio
    {
        private readonly ProyectoPersonaContext _context;

        public ProvinciaRepository(ProyectoPersonaContext context)
        {
            _context = context;
        }

        public async Task<CRUDPersonaObjetos.Modelos.Provincia> ActualizarProvinciaAsync(CRUDPersonaObjetos.Modelos.Provincia provincia)
        {
            var existente = await _context.Provincia.FindAsync(provincia.Id); 

            if(existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(provincia);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<CRUDPersonaObjetos.Modelos.Provincia> AgregarProvinciaAsync(CRUDPersonaObjetos.Modelos.Provincia provincia)
        {
           _context.Provincia.Add(provincia);
            await _context.SaveChangesAsync();
            return provincia;
        }

        public async Task<bool> EliminarProvinciaAsync(int id)
        {
            var provincia = await _context.Provincia.FindAsync(id);
            if(provincia == null) return false;

            _context.Provincia.Remove(provincia);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CRUDPersonaObjetos.Modelos.Provincia> ObtenerProvinciaPorIdAsync(int id)
        {
           return await _context.Provincia.FindAsync(id);
        }

        public async Task<List<CRUDPersonaObjetos.Modelos.Provincia>> ObtenerProvinciasAsync()
        {
           return await _context.Provincia.ToListAsync();
        }
    }
}
