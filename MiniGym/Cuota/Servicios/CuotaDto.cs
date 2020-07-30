using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Cuota.Servicios
{
    public class CuotaDto
    {

        public long CuotaId { get; set; }

        public string NumeroCuota { get; set; }

        public decimal ValorCuota { get; set; }

        public decimal ValorParcial { get; set; }

        public EstadoCuota EstadoCuota { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public decimal Saldo { get; set; }

        public long PrestamoId { get; set; }

    }
}
