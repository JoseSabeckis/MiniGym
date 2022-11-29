using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Prestamo.Servicios
{
    public interface IPrestamoServicio
    {

        void NuevoPrestamo(PrestamoDto prestamo);

        void ModificarNotas(long id, string notas);
        long TrerIdDelPrestamoPorFechaIinicio(DateTime inicio);

        void EliminarPrestamoCuotasComprobante(long prestamoId);

        void ModificarFechaFinDePrestamo(long id);

        PrestamoDto BuscarPrestamoPorId(long id);

        int VerCodigoDeCredito();

        IEnumerable<PrestamoDto> ObtenerPrestamosPorClienteId(long ClienteId);

        IEnumerable<PrestamoDto> ObtenerPrestamosEnProcesoPorClienteId(long ClienteId);

        IEnumerable<PrestamoDto> ObtenerPrestamosPorClienteIdSinPrestamosTerminados(long ClienteId);

        IEnumerable<PrestamoDto> ObtenerPrestamosPorClienteDni(string ClienteDni);

        PrestamoDto ObtenerPrestamoPorClienteDniEnProceso(string ClienteDni);

        IEnumerable<PrestamoDto> ObtenerPrestamosPorClienteDniSinTerminado(string ClienteDni);

        List<PersonaCarpeta.Servicios.PersonaDto> ObtenerPrestamosAdeudadosList(List<PersonaCarpeta.Servicios.PersonaDto> ListaClientes);

        List<PersonaCarpeta.Servicios.PersonaDto> ObtenerPrestamosPorAdeudar(List<PersonaCarpeta.Servicios.PersonaDto> ListaClientes, DateTime desde, DateTime hasta);

    }
}
