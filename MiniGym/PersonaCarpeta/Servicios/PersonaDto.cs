using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.PersonaCarpeta.Servicios
{
    public class PersonaDto : BaseDto
    {
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string ApyNom => Apellido + " " + Nombre;

        public string Cuil { get; set; }

        public string Dni { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Mail { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public long LocalidadId { get; set; }

        public string Numero { get; set; }

        public string Calle { get; set; }

        public string Domicilio => Calle + " " + Numero;
    }
}
