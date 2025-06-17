using AutoMapper;
using CRUDPersonaDAL.Repositorios.Persona;
using CRUDPersonaObjetos.ViewModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaBLL.Servicios.Persona
{
    public class PersonaServicio : IPersonaServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly IMapper _mapper;

        public PersonaServicio(IPersonaRepositorio personaRepositorio, IMapper mapper)
        {
            _personaRepositorio = personaRepositorio;
            _mapper = mapper; 
        }


        public async Task<PersonaViewModelo> ActualizarPersonaAsync(PersonaViewModelo personaViewModelo)
        {
            var persona = _mapper.Map<CRUDPersonaObjetos.Modelos.Persona>(personaViewModelo);

            var resultado = await _personaRepositorio.ActualizarPersonaAsync(persona);

            return _mapper.Map<PersonaViewModelo>(resultado);

        }

        public async Task<PersonaViewModelo> CrearPersonaAsync(PersonaViewModelo personaViewModelo)
        {
            var persona = _mapper.Map<CRUDPersonaObjetos.Modelos.Persona>(personaViewModelo);

            persona.FechaRegistro = DateTime.Now; // Asignar la fecha de registro actual    //REGLA DE NEGOCIO

            var resultado = await _personaRepositorio.CrearPersonaAsync(persona);

            return _mapper.Map<PersonaViewModelo>(resultado);
        }

        public async Task<bool> EliminarPersonaAsync(int id)
        {
            return await _personaRepositorio.EliminarPersonaAsync(id);  
        }

        public async Task<PersonaViewModelo> ObtenerPersonaPorIdAsync(int id)
        {
            var persona = await _personaRepositorio.ObtenerPersonaPorIdAsync(id);
            return _mapper.Map<PersonaViewModelo>(persona);
        }

        public async Task<List<PersonaViewModelo>> ObtenerPersonasAsync()
        {
           var personas = await _personaRepositorio.ObtenerPersonasAsync();
           return _mapper.Map<List<PersonaViewModelo>>(personas);    
        }
    }
}
