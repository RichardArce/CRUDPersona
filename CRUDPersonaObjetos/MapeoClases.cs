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
            CreateMap<Persona, PersonaViewModelo>()
                .ForMember(dest => dest.ProvinciaNombre, opt => opt.MapFrom(src => src.ProvinciaIdfkNavigation.Nombre));
                

            CreateMap<PersonaViewModelo, Persona>()
                .ForMember(dest => dest.ProvinciaIdfkNavigation, opt => opt.Ignore()); // Ignorar el objeto de navegación
                


            CreateMap<Provincia, ProvinciaViewModelo>();
            CreateMap<ProvinciaViewModelo, Provincia>();

        }
    }
}
