using AutoMapper;
using CRUDPersonaObjetos.Modelos;
using CRUDPersonaObjetos.ViewModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaObjetos
{
    public class MapeoClases : Profile
    {
        public MapeoClases()
        {
            CreateMap<Persona, PersonaViewModelo>();
            CreateMap<PersonaViewModelo, Persona>();


        }
    }
}
