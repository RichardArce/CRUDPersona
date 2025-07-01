using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonaDAL.Repositorios.Provincia
{
    public interface IProvinciaRepositorio
    {
        Task<List<CRUDPersonaObjetos.Modelos.Provincia>> ObtenerProvinciasAsync();

        Task<CRUDPersonaObjetos.Modelos.Provincia> ObtenerProvinciaPorIdAsync(int id);

        Task<CRUDPersonaObjetos.Modelos.Provincia> AgregarProvinciaAsync(CRUDPersonaObjetos.Modelos.Provincia provincia);

        Task<CRUDPersonaObjetos.Modelos.Provincia> ActualizarProvinciaAsync(CRUDPersonaObjetos.Modelos.Provincia provincia);

        Task<bool> EliminarProvinciaAsync(int id);
    }
}
