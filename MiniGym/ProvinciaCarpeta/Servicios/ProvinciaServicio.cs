using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Provincia.Servicios
{
    public class ProvinciaServicio : IProvinciaServicio
    {
        public void Eliminar(long provinciaId)
        {
            using (var context = new MiniGymModelContainer())
            {
                var provinciaEliminar = context.Provincias
                    .FirstOrDefault(x => x.Id == provinciaId);

                if (provinciaEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                provinciaEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(ProvinciaDto provinciadto)
        {
            using (var context = new MiniGymModelContainer())
            {
                var provinciaNueva = new ProvinciaSet
                {
                    Descripcion = provinciadto.Descripcion
                };

                context.Provincias.Add(provinciaNueva);

                context.SaveChanges();

                return provinciaNueva.Id;
            }
        }

        public void Modificar(ProvinciaDto provinciadto)
        {
            using (var context = new MiniGymModelContainer())
            {
                var provinciaModificar = context.Provincias
                    .FirstOrDefault(x => x.Id == provinciadto.Id);

                if (provinciaModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                provinciaModificar.Descripcion = provinciadto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<ProvinciaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Provincias
                    //.AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new ProvinciaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }
        }

        public bool ObtenerClientesConProvincia(long provinciaid)
        {
            using (var context = new MiniGymModelContainer())
            {
                var aux = context.Localidades.Where(x => x.ProvinciaId == provinciaid).ToList();

                if (aux.Count() == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public ProvinciaDto ObtenerPorId(long provinciaId)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Provincias
                    .AsNoTracking()
                    .Select(x => new ProvinciaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x => x.Id == provinciaId && x.EstaEliminado == false);
            }
        }
    }
}
