using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaDAL.Repositorios.Persona
{
    public interface IPersonaRepositorio
    {
        Task<List<CRUDPersonaObjetos.Modelos.Persona>> ObtenerPersonasAsync();
        Task<CRUDPersonaObjetos.Modelos.Persona> ObtenerPersonaPorIdAsync(int id);
        Task<CRUDPersonaObjetos.Modelos.Persona> CrearPersonaAsync(CRUDPersonaObjetos.Modelos.Persona persona);
        Task<CRUDPersonaObjetos.Modelos.Persona> ActualizarPersonaAsync(CRUDPersonaObjetos.Modelos.Persona persona);
        Task<bool> EliminarPersonaAsync(int id);
    }
}
