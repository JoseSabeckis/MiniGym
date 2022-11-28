using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Plan.Servicios
{
    public class PlanServicio : IPlanServicio
    {
        public void Eliminar(long planId)
        {
            using (var context = new MiniGymModelContainer())
            {
                var Eliminar = context.Planes
                    .FirstOrDefault(x => x.Id == planId);

                if (Eliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Localidad");

                Eliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(PlanDto dto)
        {
            using (var context = new MiniGymModelContainer())
            {
                var Nueva = new PlanSet{ Descripcion = dto.Descripcion, Precio = dto.Precio };

                context.Planes.Add(Nueva);

                context.SaveChanges();

                return Nueva.Id;
            }
        }

        public void Modificar(PlanDto planDto)
        {
            using (var context = new MiniGymModelContainer())
            {
                var Modificar = context.Planes
                    .FirstOrDefault(x => x.Id == planDto.Id);

                if (Modificar == null)
                    throw new Exception("Ocurrio un error al Obtener el Plan");

                Modificar.Descripcion = planDto.Descripcion;
                Modificar.Precio = planDto.Precio;

                context.SaveChanges();
            }
        }

        public IEnumerable<PlanDto> Obtener(string cadenaBuscar)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Planes
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new PlanDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Precio = x.Precio,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public PlanDto ObtenerPorId(long planId)
        {
            using (var context = new MiniGymModelContainer())
            {
                var plan = context.Planes.FirstOrDefault(x => x.Id == planId);

                var devolver = new PlanDto
                {
                    Id = plan.Id,
                    Descripcion = plan.Descripcion,
                    Precio = plan.Precio,
                    EstaEliminado = plan.EstaEliminado
                };

                return devolver;

            }
        }

    }
}
