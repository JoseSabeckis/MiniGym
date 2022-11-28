﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Plan.Servicios
{
    public class PlanDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool EstaEliminado { get; set; }
    }
}
