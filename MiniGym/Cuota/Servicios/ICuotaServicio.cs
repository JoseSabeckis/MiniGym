using MiniGym.PersonaCarpeta.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Cuota.Servicios
{
    public interface ICuotaServicio
    {
        void CargarCuotas(int cantidadCuotas, CuotaDto cuota, DateTime fechainiciofinal);

        IEnumerable<CuotaDto> ObtenerCuotasPorIDComprobante(long prestamoId);

        bool VerificarCuotasVencidasPorClienteDni(PersonaDto personaDto);

        void CobrarCuota(CuotaDto cuota);

        void VerificarVencimientoDeCuotasYPonerImpagas();

        CuotaDto ObtenerCuotaImpaga(long prestamoId);

        CuotaDto ObtenerProximoVencimiento(long prestamoId);

        IEnumerable<CuotaDto> ObtenerCuotasVencidasPorCliente(long prestamoId);

        IEnumerable<CuotaDto> ObtenerCuotasVencidasPorClienteDesdeHasta(long prestamoId, DateTime desde, DateTime hasta);

        IEnumerable<CuotaDto> ObtenerCuotasTodas(long prestamoId);

        bool VerificarSiLaCuotaEstaPagada(long cuotaId);

        CuotaDto ObtenerCuotaPorId(long cuotaId);

        void ModificarValorCuota(long cuotaId, decimal nuevoValor);
    }
}
