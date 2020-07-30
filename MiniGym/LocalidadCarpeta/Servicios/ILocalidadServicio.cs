using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Localidad.Servicios
{
    public interface ILocalidadServicio
    {
        long Insertar(LocalidadDto localidaddto);

        void Modificar(LocalidadDto localidaddto);

        void Eliminar(long localidadId);

        // ===================================================== //

        bool ObtenerLocalidadesDeDirecciones(long localidadid);

        IEnumerable<LocalidadDto> Obtener(string cadenaBuscar);

        IEnumerable<LocalidadDto> ObtenerPorProvincia(long provinciaId, string cadenaBuscar);

        LocalidadDto ObtenerPorId(long localidadId);
    }
}
