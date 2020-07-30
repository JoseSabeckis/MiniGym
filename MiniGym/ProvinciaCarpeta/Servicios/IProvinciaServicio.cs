using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Provincia.Servicios
{
    public interface IProvinciaServicio
    {
        long Insertar(ProvinciaDto provinciadto);

        void Modificar(ProvinciaDto provinciadto);

        void Eliminar(long provinciaId);

        // ===================================================== //

        bool ObtenerClientesConProvincia(long provinciaid);

        IEnumerable<ProvinciaDto> Obtener(string cadenaBuscar);

        ProvinciaDto ObtenerPorId(long provinciaId);
    }
}
