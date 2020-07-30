using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Localidad.Servicios
{
    public class LocalidadDto : BaseDto
    {

        public string Descripcion { get; set; }

        public long ProvinciaId { get; set; }

    }
}
