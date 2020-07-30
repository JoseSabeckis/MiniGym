using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.PersonaCarpeta.Servicios
{
    public interface IPersonaServicio
    {
        void Eliminar(long empleadoId);

        long Insertar(PersonaDto dto);

        void Modificar(PersonaDto dto);

        IEnumerable<PersonaDto> Obtener(string cadenaBuscar);

        List<PersonaDto> ObtenerList(string cadenaBuscar);

        PersonaDto ObtenerPorCuil(string cliente);

        PersonaDto ObtenerPorDni(string dni);

        PersonaDto ObtenerPorId(long entidadId);

        bool VerificarSiExiste(string dni);

        bool VerificarSiExisteNombreApellido(string nombre, string apellido);
    }
}
