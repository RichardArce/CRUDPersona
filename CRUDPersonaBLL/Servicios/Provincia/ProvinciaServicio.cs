using AutoMapper;
using CRUDPersonaDAL.Repositorios.Provincia;
using CRUDPersonaObjetos.ViewModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaBLL.Servicios.Provincia
{
    public class ProvinciaServicio : IProvinciaServicio
    {
        private readonly IProvinciaRepositorio _provinciaRepositorio;
        private readonly IMapper _mapper;

        public ProvinciaServicio(IProvinciaRepositorio provinciaRepositorio, IMapper mapper)
        {
            _provinciaRepositorio = provinciaRepositorio;
            _mapper = mapper;
        }

        public async Task<ProvinciaViewModelo> ActualizarProvinciaAsync(ProvinciaViewModelo provinciaViewModelo)
        {
            var provincia = _mapper.Map<CRUDPersonaObjetos.Modelos.Provincia>(provinciaViewModelo);
            var resultado = await _provinciaRepositorio.ActualizarProvinciaAsync(provincia);
            return _mapper.Map<ProvinciaViewModelo>(resultado);
        }

        public async Task<ProvinciaViewModelo> AgregarProvinciaAsync(ProvinciaViewModelo provinciaViewModelo)
        {
            var provincia = _mapper.Map<CRUDPersonaObjetos.Modelos.Provincia>(provinciaViewModelo);
            var resultado = await _provinciaRepositorio.AgregarProvinciaAsync(provincia);
            return _mapper.Map<ProvinciaViewModelo>(resultado);
        }

        public async Task<bool> EliminarProvinciaAsync(int id)
        {
            return await _provinciaRepositorio.EliminarProvinciaAsync(id);
        }

        public async Task<ProvinciaViewModelo> ObtenerProvinciaPorIdAsync(int id)
        {
            var provincia = await _provinciaRepositorio.ObtenerProvinciaPorIdAsync(id);
            return _mapper.Map<ProvinciaViewModelo>(provincia);
        }

        public async Task<List<ProvinciaViewModelo>> ObtenerProvinciasAsync()
        {
            var provincias = await _provinciaRepositorio.ObtenerProvinciasAsync();
            return _mapper.Map<List<ProvinciaViewModelo>>(provincias);
        }
    }
}
