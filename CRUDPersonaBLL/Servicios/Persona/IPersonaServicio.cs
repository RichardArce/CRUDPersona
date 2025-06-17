using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaBLL.Servicios.Persona
{
    public interface IPersonaServicio
    {
        Task<List<CRUDPersonaObjetos.ViewModelos.PersonaViewModelo>> ObtenerPersonasAsync();
        Task<CRUDPersonaObjetos.ViewModelos.PersonaViewModelo> ObtenerPersonaPorIdAsync(int id);
        Task<CRUDPersonaObjetos.ViewModelos.PersonaViewModelo> CrearPersonaAsync(CRUDPersonaObjetos.ViewModelos.PersonaViewModelo persona);
        Task<CRUDPersonaObjetos.ViewModelos.PersonaViewModelo> ActualizarPersonaAsync(CRUDPersonaObjetos.ViewModelos.PersonaViewModelo persona);
        Task<bool> EliminarPersonaAsync(int id);
    }
}
