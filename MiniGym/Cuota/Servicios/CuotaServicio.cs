using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Cuota.Servicios
{
    public class CuotaServicio : ICuotaServicio
    {

        public void CargarCuotas(int cantidadCuotas, CuotaDto cuota, DateTime fechainiciofinal)
        {
            using (var contex = new MiniGymModelContainer())
            {
                int numeroCuota = 1;

                DateTime fechaVencimiento = new DateTime();
                DateTime fechaInicio = new DateTime();

                for (int i = 0; i < cantidadCuotas; i++)
                {

                    if (i == 0)
                    {
                        fechaInicio = fechainiciofinal;
                    }
                    else
                    {

                        fechaInicio = fechaInicio.AddMonths(1);                    
                        
                    }



                    fechaVencimiento = fechaInicio.AddMonths(1);


                    var cuotasCant = new CuotaSet
                    {
                        EstadoCuota = EstadoCuota.Pendiente,
                        ValorCuota = Math.Round(cuota.ValorCuota, 2),
                        Saldo = Math.Round(cuota.Saldo, 2),
                        ValorParcial = 0,
                        FechaInicio = fechaInicio,
                        NumeroCuota = $"{numeroCuota}",
                        PrestamoId = cuota.PrestamoId,
                        FechaVencimiento = fechaVencimiento

                    };

                    contex.Cuotas.Add(cuotasCant);

                    numeroCuota++;

                }


                contex.SaveChanges();

            }
        }       

        public IEnumerable<CuotaDto> ObtenerCuotasPorIDComprobante(long prestamoId)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var listaCuotas = contex.Cuotas.Where(x => x.PrestamoId == prestamoId).Select(x => new CuotaDto
                {
                    CuotaId = x.Id,
                    EstadoCuota = x.EstadoCuota,
                    FechaInicio = x.FechaInicio,
                    FechaVencimiento = x.FechaVencimiento,
                    NumeroCuota = x.NumeroCuota,
                    Saldo = x.Saldo,
                    ValorCuota = x.ValorCuota,
                    ValorParcial = x.ValorParcial,
                    PrestamoId = x.PrestamoId

                }).ToList();


                return listaCuotas;

            }

        }

        public void CobrarCuota(CuotaDto cuota)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var cuotaAModificar = contex.Cuotas.FirstOrDefault(x => x.Id == cuota.CuotaId);

                cuotaAModificar.Saldo = cuota.Saldo;
                cuotaAModificar.EstadoCuota = cuota.EstadoCuota;
                cuotaAModificar.ValorParcial += cuota.ValorParcial;

                contex.SaveChanges();

            }

        }

        public void VerificarVencimientoDeCuotasYPonerImpagas()
        {

            using (var contex = new MiniGymModelContainer())
            {

                var cuotasVencidas = contex.Cuotas.Where(x => x.FechaVencimiento <= DateTime.Now && x.EstadoCuota != EstadoCuota.Cobrado);

                foreach (var item in cuotasVencidas)
                {
                    item.EstadoCuota = EstadoCuota.Impaga;
                }

                contex.SaveChanges();

            }

        }

        public IEnumerable<CuotaDto> ObtenerCuotasVencidasPorCliente(long prestamoId)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var cuotasVencidas = contex.Cuotas.Where(x => x.EstadoCuota == EstadoCuota.Impaga && x.PrestamoId == prestamoId).Select(x => new CuotaDto
                {

                    CuotaId = x.Id,
                    EstadoCuota = x.EstadoCuota,
                    FechaInicio = x.FechaInicio,
                    FechaVencimiento = x.FechaVencimiento,
                    NumeroCuota = x.NumeroCuota,
                    Saldo = x.Saldo,
                    ValorCuota = x.ValorCuota,
                    ValorParcial = x.ValorParcial,
                    PrestamoId = x.PrestamoId

                }).ToList();


                return cuotasVencidas;

            }

        }

        public IEnumerable<CuotaDto> ObtenerCuotasVencidasPorClienteDesdeHasta(long prestamoId, DateTime desde, DateTime hasta)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var cuotasVencidas = contex.Cuotas.Where(x => x.EstadoCuota == EstadoCuota.Impaga && x.PrestamoId == prestamoId && x.FechaVencimiento.Year >= desde.Year && x.FechaVencimiento.Year <= hasta.Year
                && x.FechaVencimiento.Month >= desde.Month && x.FechaVencimiento.Month <= hasta.Month && x.FechaVencimiento.Day >= desde.Day && x.FechaVencimiento.Day <= hasta.Day).Select(x => new CuotaDto
                {

                    CuotaId = x.Id,
                    EstadoCuota = x.EstadoCuota,
                    FechaInicio = x.FechaInicio,
                    FechaVencimiento = x.FechaVencimiento,
                    NumeroCuota = x.NumeroCuota,
                    Saldo = x.Saldo,
                    ValorCuota = x.ValorCuota,
                    ValorParcial = x.ValorParcial,
                    PrestamoId = x.PrestamoId

                }).ToList();


                return cuotasVencidas;

            }

        }

        public IEnumerable<CuotaDto> ObtenerCuotasTodas(long prestamoId)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var cuotasVencidas = contex.Cuotas.Where(x => x.PrestamoId == prestamoId).Select(x => new CuotaDto
                {

                    CuotaId = x.Id,
                    EstadoCuota = x.EstadoCuota,
                    FechaInicio = x.FechaInicio,
                    FechaVencimiento = x.FechaVencimiento,
                    NumeroCuota = x.NumeroCuota,
                    Saldo = x.Saldo,
                    ValorCuota = x.ValorCuota,
                    ValorParcial = x.ValorParcial,
                    PrestamoId = x.PrestamoId

                }).ToList();


                return cuotasVencidas;

            }

        }

        public bool VerificarSiLaCuotaEstaPagada(long cuotaId)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var cuotasVencidas = contex.Cuotas.FirstOrDefault(x => x.Id == cuotaId);

                var bandera = false;

                if (cuotasVencidas.EstadoCuota == EstadoCuota.Cobrado)
                {
                    bandera = true;
                }
                else
                {
                    bandera = false;
                }



                return bandera;

            }

        }

        public CuotaDto ObtenerCuotaPorId(long cuotaId)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var cuotas = contex.Cuotas.FirstOrDefault(x => x.Id == cuotaId);

                var cuotasDto = new CuotaDto
                {
                    CuotaId = cuotas.Id,
                    EstadoCuota = cuotas.EstadoCuota,
                    FechaInicio = cuotas.FechaInicio,
                    FechaVencimiento = cuotas.FechaVencimiento,
                    NumeroCuota = cuotas.NumeroCuota,
                    PrestamoId = cuotas.PrestamoId,
                    Saldo = cuotas.Saldo,
                    ValorCuota = cuotas.ValorCuota,
                    ValorParcial = cuotas.ValorParcial
                };


                return cuotasDto;

            }

        }

        public void ModificarValorCuota(long cuotaId, decimal nuevoValor)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var cuotas = contex.Cuotas.FirstOrDefault(x => x.Id == cuotaId);

                cuotas.ValorCuota = nuevoValor;

                var diferencia = nuevoValor - cuotas.ValorParcial;

                cuotas.Saldo = diferencia;

                contex.SaveChanges();

            }

        }

    }
}
