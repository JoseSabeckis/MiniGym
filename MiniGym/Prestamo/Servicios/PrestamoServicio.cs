using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Prestamo.Servicios
{
    public class PrestamoServicio : IPrestamoServicio
    {
        public void EliminarPrestamoCuotasComprobante(long prestamoId)
        {
            using (var contex = new MiniGymModelContainer())
            {

                var cuotas = contex.Cuotas.Where(x => x.PrestamoId == prestamoId);

                foreach (var item in cuotas)
                {

                    contex.Cuotas.Remove(item);

                }

                var prestamo = contex.Prestamos.FirstOrDefault(x => x.Id == prestamoId);
                prestamo.EstadoPrestamo = EstadoPrestamo.Cancelado;

                contex.SaveChanges();

            }

        }
        public void NuevoPrestamo(PrestamoDto prestamo)
        {

            using (var contex = new MiniGymModelContainer())
            {

                var prestamoNuevo = new PrestamoSet
                {
                    CantidadCuotas = prestamo.CantidadCuotas,
                    CodigoCredito = prestamo.CodigoCredito,
                    EstadoPrestamo = prestamo.EstadoPrestamo,
                    FechaFin = prestamo.FechaFin,
                    FechaInicio = prestamo.FechaInicio,
                    Notas = prestamo.Notas,
                    PersonaId = prestamo.PersonaId,
                    PlanId = prestamo.PlanId
                };

                contex.Prestamos.Add(prestamoNuevo);


                contex.SaveChanges();
            }

        }        

        public long TrerIdDelPrestamoPorFechaIinicio(DateTime inicio)
        {
            using (var contex = new MiniGymModelContainer())
            {

                var aux = contex.Prestamos.FirstOrDefault(x => x.FechaInicio.Day == inicio.Day && x.FechaInicio.Month == inicio.Month
                && x.FechaInicio.Year == inicio.Year && x.FechaInicio.Hour == inicio.Hour && x.FechaInicio.Minute == inicio.Minute && x.FechaInicio.Second == inicio.Second);

                return aux.Id;

            }
        }

        public void ModificarFechaFinDePrestamo(long id)
        {
            using (var contex = new MiniGymModelContainer())
            {
                var aux = contex.Prestamos.FirstOrDefault(x => x.Id == id);

                aux.FechaFin = DateTime.Now.Date;
                aux.EstadoPrestamo = EstadoPrestamo.Terminado;

                contex.SaveChanges();

            }

        }

        public PrestamoDto BuscarPrestamoPorId(long id)
        {
            using (var contex = new MiniGymModelContainer())
            {

                var aux = contex.Prestamos.Where(x => x.Id == id).Select(x => new PrestamoDto
                {
                    CantidadCuotas = x.CantidadCuotas,
                    CodigoCredito = x.CodigoCredito,
                    Notas = x.Notas,
                    EstadoPrestamo = x.EstadoPrestamo,
                    FechaInicio = x.FechaInicio,
                    PrestamoId = x.Id,
                    PersonaId = x.PersonaId,
                    FechaFin = x.FechaFin,
                    PlanId = x.PlanId

                }).ToList();

                var aux2 = aux.FirstOrDefault(x => x.PrestamoId == id);

                return aux2;

            }
        }

        public int VerCodigoDeCredito()
        {
            using (var contex = new MiniGymModelContainer())
            {

                var contador = contex.Prestamos.Count();

                return contador + 1;

            }
        }

        public IEnumerable<PrestamoDto> ObtenerPrestamosPorClienteId(long ClienteId)
        {
            using (var contex = new MiniGymModelContainer())
            {

                var aux = contex.Prestamos.Where(x => x.PersonaId == ClienteId).Select(x => new PrestamoDto
                {

                    CantidadCuotas = x.CantidadCuotas,
                    CodigoCredito = x.CodigoCredito,
                    Notas = x.Notas,
                    EstadoPrestamo = x.EstadoPrestamo,
                    FechaInicio = x.FechaInicio,
                    PrestamoId = x.Id,
                    PersonaId = x.PersonaId,
                    FechaFin = x.FechaFin,
                    PlanId = x.PlanId

                }).ToList();

                return aux;

            }

        }

        public IEnumerable<PrestamoDto> ObtenerPrestamosEnProcesoPorClienteId(long ClienteId)
        {
            using (var contex = new MiniGymModelContainer())
            {

                var aux = contex.Prestamos.Where(x => x.PersonaId == ClienteId && x.EstadoPrestamo == EstadoPrestamo.EnProceso).Select(x => new PrestamoDto
                {

                    CantidadCuotas = x.CantidadCuotas,
                    CodigoCredito = x.CodigoCredito,
                    Notas = x.Notas,
                    EstadoPrestamo = x.EstadoPrestamo,
                    FechaInicio = x.FechaInicio,
                    PrestamoId = x.Id,
                    PersonaId = x.PersonaId,
                    FechaFin = x.FechaFin,
                    PlanId = x.PlanId

                }).ToList();

                return aux;

            }

        }

        public IEnumerable<PrestamoDto> ObtenerPrestamosPorClienteIdSinPrestamosTerminados(long ClienteId)
        {
            using (var contex = new MiniGymModelContainer())
            {

                var aux = contex.Prestamos.Where(x => x.PersonaId == ClienteId && x.EstadoPrestamo != EstadoPrestamo.Terminado && x.EstadoPrestamo != EstadoPrestamo.Cancelado).Select(x => new PrestamoDto
                {

                    CantidadCuotas = x.CantidadCuotas,
                    CodigoCredito = x.CodigoCredito,
                    Notas = x.Notas,
                    EstadoPrestamo = x.EstadoPrestamo,
                    FechaInicio = x.FechaInicio,
                    PrestamoId = x.Id,
                    PersonaId = x.PersonaId,
                    FechaFin = x.FechaFin,
                    PlanId = x.PlanId

                }).ToList();

                return aux;

            }

        }

        public IEnumerable<PrestamoDto> ObtenerPrestamosPorClienteDni(string ClienteDni)
        {
            using (var contex = new MiniGymModelContainer())
            {
                var cliente = contex.Personas.FirstOrDefault(x => x.Dni == ClienteDni);

                var aux = contex.Prestamos.Where(x => x.PersonaId == cliente.Id).Select(x => new PrestamoDto
                {

                    CantidadCuotas = x.CantidadCuotas,
                    CodigoCredito = x.CodigoCredito,
                    Notas = x.Notas,
                    EstadoPrestamo = x.EstadoPrestamo,
                    FechaInicio = x.FechaInicio,
                    PrestamoId = x.Id,
                    PersonaId = x.PersonaId,
                    FechaFin = x.FechaFin,
                    PlanId = x.PlanId

                }).ToList();

                return aux;

            }

        }

        public PrestamoDto ObtenerPrestamoPorClienteDniEnProceso(string ClienteDni)
        {
            using (var contex = new MiniGymModelContainer())
            {
                var cliente = contex.Personas.FirstOrDefault(x => x.Dni == ClienteDni);

                var aux = contex.Prestamos.FirstOrDefault(x => x.PersonaId == cliente.Id && x.EstadoPrestamo == EstadoPrestamo.EnProceso);

                var prestamo = new PrestamoDto
                {

                    CantidadCuotas = aux.CantidadCuotas,
                    CodigoCredito = aux.CodigoCredito,
                    Notas = aux.Notas,
                    EstadoPrestamo = aux.EstadoPrestamo,
                    FechaInicio = aux.FechaInicio,
                    PrestamoId = aux.Id,
                    PersonaId = aux.PersonaId,
                    FechaFin = aux.FechaFin,
                    PlanId = aux.PlanId

                };

                return prestamo;

            }

        }

        public IEnumerable<PrestamoDto> ObtenerPrestamosPorClienteDniSinTerminado(string ClienteDni)
        {
            using (var contex = new MiniGymModelContainer())
            {
                var cliente = contex.Personas.FirstOrDefault(x => x.Dni == ClienteDni);

                var aux = contex.Prestamos.Where(x => x.PersonaId == cliente.Id && x.EstadoPrestamo != EstadoPrestamo.Terminado && x.EstadoPrestamo != EstadoPrestamo.Cancelado).Select(x => new PrestamoDto
                {

                    CantidadCuotas = x.CantidadCuotas,
                    CodigoCredito = x.CodigoCredito,
                    Notas = x.Notas,
                    EstadoPrestamo = x.EstadoPrestamo,
                    FechaInicio = x.FechaInicio,
                    PrestamoId = x.Id,
                    PersonaId = x.PersonaId,
                    FechaFin = x.FechaFin,
                    PlanId = x.PlanId

                }).ToList();

                return aux;

            }

        }        

       

        public class Aux ///////////////////////////////////// AUXILIAR 
        {

            public long PrestamoId { get; set; }

            public decimal TotalAdeudado { get; set; }

        }

        public class AuxPrestamo ///////////////////////////////////// AUXILIAR 
        {
            public long AuxIdCliente { get; set; }

            public long PrestamoId { get; set; }

            public decimal TotalAdeudado { get; set; }

        }

        public List<PersonaCarpeta.Servicios.PersonaDto> ObtenerPrestamosAdeudadosList(List<PersonaCarpeta.Servicios.PersonaDto> ListaClientes)
        {
            using (var contex = new MiniGymModelContainer())
            {
                List<Aux> ListAuxiliar = new List<Aux>();
                List<AuxPrestamo> ListAuxiliarFinal = new List<AuxPrestamo>();

                var ListaCuotas = contex.Cuotas.Where(x => x.EstadoCuota == EstadoCuota.Impaga || x.EstadoCuota == EstadoCuota.Parcial && x.FechaVencimiento <= DateTime.Now);//agregar esta parcial despues

                foreach (var item in ListaCuotas) //AUX --> 1
                {
                    if (ListAuxiliar.FirstOrDefault(x => x.PrestamoId == item.PrestamoId) == null)
                    {
                        var MontoSuma = new Aux
                        {
                            PrestamoId = item.PrestamoId,
                            TotalAdeudado = item.ValorCuota - item.ValorParcial
                        };

                        ListAuxiliar.Add(MontoSuma);
                    }
                    else
                    {
                        var Aux = ListAuxiliar.FirstOrDefault(x => x.PrestamoId == item.PrestamoId);

                        Aux.TotalAdeudado += (item.ValorCuota - item.ValorParcial);

                    }


                }


                ///////////////////////////////////////////


                List<PrestamoDto> ListaPrestamo = new List<PrestamoDto>();
                List<PersonaCarpeta.Servicios.PersonaDto> ListaClientesFinal = new List<PersonaCarpeta.Servicios.PersonaDto>();

                foreach (var item in ListaCuotas)
                {

                    var ListaPrestamoAux = contex.Prestamos.Where(x => x.Id == item.PrestamoId).Select(x => new PrestamoDto
                    {
                        CantidadCuotas = x.CantidadCuotas,
                        CodigoCredito = x.CodigoCredito,
                        EstadoPrestamo = x.EstadoPrestamo,
                        FechaFin = x.FechaFin,
                        FechaInicio = x.FechaInicio,
                        Notas = x.Notas,
                        PersonaId = x.PersonaId,
                        PrestamoId = x.Id,
                        PlanId = x.PlanId

                    });


                    foreach (var itemAux in ListaPrestamoAux)
                    {
                        if (ListaPrestamo.FirstOrDefault(x => x.PrestamoId == item.PrestamoId) == null)
                        {
                            ListaPrestamo.Add(itemAux);
                        }
                    }




                }

                foreach (var item in ListaPrestamo)
                {
                    var ListaTotalDeudores = ListAuxiliar.Where(x => x.PrestamoId == item.PrestamoId);//--//

                    var calculos = ListaTotalDeudores.Sum(x => x.TotalAdeudado);

                    long idcliente = item.PersonaId;

                    var nuevo = new AuxPrestamo
                    {
                        TotalAdeudado = calculos,
                        PrestamoId = ListaTotalDeudores.FirstOrDefault(x => x.PrestamoId == x.PrestamoId).PrestamoId,
                        AuxIdCliente = idcliente
                    };

                    ListAuxiliarFinal.Add(nuevo);

                }


                foreach (var item in ListaPrestamo)//item2 listacliente
                {
                    foreach (var item2 in ListaClientes)//item listaprestamo
                    {
                        var presta = ListAuxiliarFinal.FirstOrDefault(x => x.PrestamoId == item.PrestamoId);

                        if (ListaClientesFinal.FirstOrDefault(x => x.Id == item2.Id && x.Id == item.PersonaId) == null && presta.AuxIdCliente == item2.Id)
                        {
                            var prestamo = ListaPrestamo.Where(x => x.PersonaId == item2.Id);

                            var nuevo = new PersonaCarpeta.Servicios.PersonaDto
                            {
                                Id = item2.Id,
                                Apellido = item2.Apellido,
                                Nombre = item2.Nombre,
                                Dni = item2.Dni,
                                TotalAdeudado = ListAuxiliarFinal.FirstOrDefault(x => x.AuxIdCliente == item2.Id).TotalAdeudado,
                                PrestamoId = item.PrestamoId
                            };

                            ListaClientesFinal.Add(nuevo);
                        }
                        else
                        {
                            if (presta.AuxIdCliente == item2.Id)
                            {
                                var client = ListaClientesFinal.FirstOrDefault(x => x.Id == item2.Id);


                                client.TotalAdeudado += ListAuxiliarFinal.FirstOrDefault(x => x.AuxIdCliente == item2.Id && x.PrestamoId == item.PrestamoId).TotalAdeudado;
                            }



                        }
                    }

                }

                List<PersonaCarpeta.Servicios.PersonaDto> ListaClientesFinaly = new List<PersonaCarpeta.Servicios.PersonaDto>();

                // =========================================\\\\\\\\\\\\\\\\\\\\\========================================================

                foreach (var item in ListaClientesFinal)
                {

                    if (ListaClientesFinaly.FirstOrDefault(x => x.Id == item.Id) == null)
                    {

                        var nuevo = new PersonaCarpeta.Servicios.PersonaDto
                        {
                            Id = item.Id,
                            Apellido = item.Apellido,
                            Nombre = item.Nombre,
                            Dni = item.Dni,
                            TotalAdeudado = item.TotalAdeudado,
                            PrestamoId = item.PrestamoId//
                        };

                        ListaClientesFinaly.Add(nuevo);

                    }
                    else
                    {

                        var client = ListaClientesFinaly.FirstOrDefault(x => x.Id == item.Id);

                        client.TotalAdeudado = (client.TotalAdeudado + item.TotalAdeudado);

                    }



                }




                return ListaClientesFinaly;

            }

        }

        public List<PersonaCarpeta.Servicios.PersonaDto> ObtenerPrestamosPorAdeudar(List<PersonaCarpeta.Servicios.PersonaDto> ListaClientes, DateTime desde, DateTime hasta)
        {
            using (var contex = new MiniGymModelContainer())
            {
                List<Aux> ListAuxiliar = new List<Aux>();
                List<AuxPrestamo> ListAuxiliarFinal = new List<AuxPrestamo>();

                var ListaCuotas = contex.Cuotas.Where(x => x.EstadoCuota == EstadoCuota.Impaga && x.FechaVencimiento.Year >= desde.Year && x.FechaVencimiento.Year <= hasta.Year
                && x.FechaVencimiento.Month >= desde.Month && x.FechaVencimiento.Month <= hasta.Month && x.FechaVencimiento.Day >= desde.Day && x.FechaVencimiento.Day <= hasta.Day);//agregar esta parcial despues

                foreach (var item in ListaCuotas) //AUX --> 1
                {
                    if (ListAuxiliar.FirstOrDefault(x => x.PrestamoId == item.PrestamoId) == null)
                    {
                        var MontoSuma = new Aux
                        {
                            PrestamoId = item.PrestamoId,
                            TotalAdeudado = item.ValorCuota - item.ValorParcial
                        };

                        ListAuxiliar.Add(MontoSuma);
                    }
                    else
                    {
                        var Aux = ListAuxiliar.FirstOrDefault(x => x.PrestamoId == item.PrestamoId);

                        Aux.TotalAdeudado += (item.ValorCuota - item.ValorParcial);

                    }


                }


                ///////////////////////////////////////////


                List<PrestamoDto> ListaPrestamo = new List<PrestamoDto>();
                List<PersonaCarpeta.Servicios.PersonaDto> ListaClientesFinal = new List<PersonaCarpeta.Servicios.PersonaDto>();

                foreach (var item in ListaCuotas)
                {

                    var ListaPrestamoAux = contex.Prestamos.Where(x => x.Id == item.PrestamoId).Select(x => new PrestamoDto
                    {
                        CantidadCuotas = x.CantidadCuotas,
                        CodigoCredito = x.CodigoCredito,
                        EstadoPrestamo = x.EstadoPrestamo,
                        FechaFin = x.FechaFin,
                        FechaInicio = x.FechaInicio,
                        Notas = x.Notas,
                        PersonaId = x.PersonaId,
                        PrestamoId = x.Id,
                        PlanId = x.PlanId

                    });


                    foreach (var itemAux in ListaPrestamoAux)
                    {
                        if (ListaPrestamo.FirstOrDefault(x => x.PrestamoId == item.PrestamoId) == null)
                        {
                            ListaPrestamo.Add(itemAux);
                        }
                    }




                }

                foreach (var item in ListaPrestamo)
                {
                    var ListaTotalDeudores = ListAuxiliar.Where(x => x.PrestamoId == item.PrestamoId);//--//

                    var calculos = ListaTotalDeudores.Sum(x => x.TotalAdeudado);

                    long idcliente = item.PersonaId;

                    var nuevo = new AuxPrestamo
                    {
                        TotalAdeudado = calculos,
                        PrestamoId = ListaTotalDeudores.FirstOrDefault(x => x.PrestamoId == x.PrestamoId).PrestamoId,
                        AuxIdCliente = idcliente
                    };

                    ListAuxiliarFinal.Add(nuevo);

                }


                foreach (var item in ListaPrestamo)//item2 listacliente
                {
                    foreach (var item2 in ListaClientes)//item listaprestamo
                    {
                        var presta = ListAuxiliarFinal.FirstOrDefault(x => x.PrestamoId == item.PrestamoId);

                        if (ListaClientesFinal.FirstOrDefault(x => x.Id == item2.Id && x.Id == item.PersonaId) == null && presta.AuxIdCliente == item2.Id)
                        {
                            var prestamo = ListaPrestamo.Where(x => x.PersonaId == item2.Id);

                            var nuevo = new PersonaCarpeta.Servicios.PersonaDto
                            {
                                Id = item2.Id,
                                Apellido = item2.Apellido,
                                Nombre = item2.Nombre,
                                Dni = item2.Dni,
                                TotalAdeudado = ListAuxiliarFinal.FirstOrDefault(x => x.AuxIdCliente == item2.Id).TotalAdeudado,
                                PrestamoId = item.PrestamoId
                            };

                            ListaClientesFinal.Add(nuevo);
                        }
                        else
                        {
                            if (presta.AuxIdCliente == item2.Id)
                            {
                                var client = ListaClientesFinal.FirstOrDefault(x => x.Id == item2.Id);


                                client.TotalAdeudado += ListAuxiliarFinal.FirstOrDefault(x => x.AuxIdCliente == item2.Id && x.PrestamoId == item.PrestamoId).TotalAdeudado;
                            }



                        }
                    }

                }

                List<PersonaCarpeta.Servicios.PersonaDto> ListaClientesFinaly = new List<PersonaCarpeta.Servicios.PersonaDto>();

                // =========================================\\\\\\\\\\\\\\\\\\\\\========================================================

                foreach (var item in ListaClientesFinal)
                {

                    if (ListaClientesFinaly.FirstOrDefault(x => x.Id == item.Id) == null)
                    {

                        var nuevo = new PersonaCarpeta.Servicios.PersonaDto
                        {
                            Id = item.Id,
                            Apellido = item.Apellido,
                            Nombre = item.Nombre,
                            Dni = item.Dni,
                            TotalAdeudado = item.TotalAdeudado,
                            PrestamoId = item.PrestamoId//
                        };

                        ListaClientesFinaly.Add(nuevo);

                    }
                    else
                    {

                        var client = ListaClientesFinaly.FirstOrDefault(x => x.Id == item.Id);

                        client.TotalAdeudado = (client.TotalAdeudado + item.TotalAdeudado);

                    }



                }




                return ListaClientesFinaly;

            }

        }

    }
}
