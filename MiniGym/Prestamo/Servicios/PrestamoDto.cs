using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Prestamo.Servicios
{
    public class PrestamoDto
    {
        public long PrestamoId { get; set; }

        public string CodigoCredito { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public int CantidadCuotas { get; set; }

        public string Notas { get; set; }

        public long PersonaId { get; set; }

        public EstadoPrestamo EstadoPrestamo { get; set; }

        public long PlanId { get; set; }
    }
}
