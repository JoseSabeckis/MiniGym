//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniGym
{
    using System;
    using System.Collections.Generic;
    
    public partial class CuotaSet
    {
        public long Id { get; set; }
        public string NumeroCuota { get; set; }
        public decimal ValorCuota { get; set; }
        public decimal ValorParcial { get; set; }
        public EstadoCuota EstadoCuota { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public decimal Saldo { get; set; }
        public long PrestamoId { get; set; }
    
        public virtual PrestamoSet Prestamo { get; set; }
    }
}
