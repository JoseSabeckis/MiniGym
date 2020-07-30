using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym
{
    public class BaseDto
    {
        public long Id { get; set; }

        public bool EstaEliminado { get; set; }

        public string EstaEliminadoStr => EstaEliminado ? "SI" : "NO";
    }
}
