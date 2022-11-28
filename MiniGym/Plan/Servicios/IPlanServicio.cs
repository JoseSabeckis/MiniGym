using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Plan.Servicios
{
    public interface IPlanServicio
    {
        long Insertar(PlanDto dto);
        void Modificar(PlanDto planDto);
        void Eliminar(long planId);
        IEnumerable<PlanDto> Obtener(string cadenaBuscar);
        PlanDto ObtenerPorId(long planId);
    }
}
