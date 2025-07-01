using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaBLL.Servicios.Provincia
{
    public interface IProvinciaServicio
    {
        Task<List<CRUDPersonaObjetos.ViewModelos.ProvinciaViewModelo>> ObtenerProvinciasAsync();

        Task<CRUDPersonaObjetos.ViewModelos.ProvinciaViewModelo> ObtenerProvinciaPorIdAsync(int id);

        Task<CRUDPersonaObjetos.ViewModelos.ProvinciaViewModelo> AgregarProvinciaAsync(CRUDPersonaObjetos.ViewModelos.ProvinciaViewModelo provincia);

        Task<CRUDPersonaObjetos.ViewModelos.ProvinciaViewModelo> ActualizarProvinciaAsync(CRUDPersonaObjetos.ViewModelos.ProvinciaViewModelo provincia);

        Task<bool> EliminarProvinciaAsync(int id);
    }
}
