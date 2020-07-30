using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.Localidad.Servicios
{
    public class LocalidadServicio : ILocalidadServicio
    {
        public void Eliminar(long localidadId)
        {
            using (var context = new MiniGymModelContainer())
            {
                var localidadEliminar = context.Localidades
                    .FirstOrDefault(x => x.Id == localidadId);

                if (localidadEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Localidad");

                localidadEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(LocalidadDto localidaddto)
        {
            using (var context = new MiniGymModelContainer())
            {
                var localidadNueva = new LocalidadSet{ Descripcion = localidaddto.Descripcion, ProvinciaId = localidaddto.ProvinciaId };

                context.Localidades.Add(localidadNueva);

                context.SaveChanges();

                return localidadNueva.Id;
            }
        }

        public void Modificar(LocalidadDto localidaddto)
        {
            using (var context = new MiniGymModelContainer())
            {
                var localidadModificar = context.Localidades
                    .FirstOrDefault(x => x.Id == localidaddto.Id);

                if (localidadModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                localidadModificar.Descripcion = localidaddto.Descripcion;
                localidadModificar.ProvinciaId = localidaddto.ProvinciaId;

                context.SaveChanges();
            }
        }

        public IEnumerable<LocalidadDto> Obtener(string cadenaBuscar)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Localidades
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new LocalidadDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ProvinciaId = x.ProvinciaId,
                        EstaEliminado = x.EstaEliminado,

                    }).ToList();
            }
        }

        public bool ObtenerLocalidadesDeDirecciones(long localidadid)
        {
            using (var context = new MiniGymModelContainer())
            {
                var aux = context.Localidades.Where(x => x.Id == localidadid).ToList();

                if (aux.Count() == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public LocalidadDto ObtenerPorId(long localidadId)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Localidades
                    .Select(x => new LocalidadDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ProvinciaId = x.ProvinciaId,
                        EstaEliminado = x.EstaEliminado,

                    }).FirstOrDefault(x => x.Id == localidadId && x.EstaEliminado == false);
            }
        }

        public IEnumerable<LocalidadDto> ObtenerPorProvincia(long provinciaId, string cadenaBuscar)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Localidades
                    .AsNoTracking()
                    .Where(x => x.ProvinciaId == provinciaId
                                && x.Descripcion.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new LocalidadDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ProvinciaId = x.ProvinciaId,
                        EstaEliminado = x.EstaEliminado,

                    }).ToList();
            }
        }

    }
}
