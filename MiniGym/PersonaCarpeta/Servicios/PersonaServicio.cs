using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGym.PersonaCarpeta.Servicios
{
    public class PersonaServicio : IPersonaServicio
    {

        public void Eliminar(long empleadoId)
        {
            using (var context = new MiniGymModelContainer())
            {
                var provinciaEliminar = context.Personas
                    .FirstOrDefault(x => x.Id == empleadoId);

                if (provinciaEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener el CLiente");

                provinciaEliminar.EstaEliminado = true;

                context.SaveChanges();

            }
        }

        public long Insertar(PersonaDto dto)
        {
            using (var context = new MiniGymModelContainer())
            {
                var nuevoCliente = new Persona
                {
                    Apellido = dto.Apellido,
                    Nombre = dto.Nombre,
                    Dni = dto.Dni,
                    Telefono = dto.Telefono,
                    Celular = dto.Celular,
                    Email = dto.Mail,
                    Cuil = dto.Cuil,
                    FechaNacimiento = dto.FechaNacimiento,
                    LocalidadId = dto.LocalidadId,
                    Calle = dto.Calle,
                    Numero = dto.Numero
                };


                context.Personas.Add(nuevoCliente);

                context.SaveChanges();

                return nuevoCliente.Id;
            }
        }

        public void Modificar(PersonaDto dto)
        {
            using (var context = new MiniGymModelContainer())
            {
                var clienteModificar = context.Personas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (clienteModificar == null)
                    throw new Exception("No se encontro el Cliente");

                //var deuda = clienteModificar.MontoMaximoCtaCte - clienteModificar.MontoLibreCtaCte;

                clienteModificar.Apellido = dto.Apellido;
                clienteModificar.Nombre = dto.Nombre;
                clienteModificar.Dni = dto.Dni;
                clienteModificar.Telefono = dto.Telefono;
                clienteModificar.Celular = dto.Celular;
                clienteModificar.Email = dto.Mail;
                clienteModificar.Cuil = dto.Cuil;
                clienteModificar.FechaNacimiento = dto.FechaNacimiento;
                clienteModificar.LocalidadId = dto.LocalidadId;
                clienteModificar.Calle = dto.Calle;
                clienteModificar.Numero = dto.Numero;

                context.SaveChanges();
            }
        }

        public IEnumerable<PersonaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Personas
                    .AsNoTracking()
                    .Where(x => (x.Nombre.Contains(cadenaBuscar)
                                || x.Apellido.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar
                                || x.Email == cadenaBuscar)
                                && x.EstaEliminado == false)
                    .Select(x => new PersonaDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Mail = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        LocalidadId = x.LocalidadId,
                        Numero = x.Numero,
                        Calle = x.Calle,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public List<PersonaDto> ObtenerList(string cadenaBuscar)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Personas
                    .AsNoTracking()
                    .Where(x => (x.Nombre.Contains(cadenaBuscar)
                                || x.Apellido.Contains(cadenaBuscar)
                                || x.Dni == cadenaBuscar
                                || x.Email == cadenaBuscar)
                                && x.EstaEliminado == false)
                    .Select(x => new PersonaDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Mail = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        LocalidadId = x.LocalidadId,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Calle,
                        Numero = x.Numero

                    }).ToList();
            }
        }

        public PersonaDto ObtenerPorCuil(string cliente)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Personas
                    .Select(x => new PersonaDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Mail = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        LocalidadId = x.LocalidadId,
                        EstaEliminado = x.EstaEliminado,
                        Calle = x.Calle,
                        Numero = x.Numero

                    }).FirstOrDefault(x => x.Apellido == cliente);

            }
        }

        public PersonaDto ObtenerPorDni(string dni)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Personas
                    .AsNoTracking()
                    .Select(x => new PersonaDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Mail = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        EstaEliminado = x.EstaEliminado,
                        LocalidadId = x.LocalidadId,
                        Calle = x.Calle,
                        Numero = x.Numero
                    }
                    ).FirstOrDefault(x => x.Dni == dni && x.EstaEliminado == false);
            }
        }

        public PersonaDto ObtenerPorId(long entidadId)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Personas
                    .AsNoTracking()
                    .Select(x => new PersonaDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Dni = x.Dni,
                        Telefono = x.Telefono,
                        Celular = x.Celular,
                        Mail = x.Email,
                        Cuil = x.Cuil,
                        FechaNacimiento = x.FechaNacimiento,
                        EstaEliminado = x.EstaEliminado,
                        LocalidadId = x.LocalidadId,
                        Calle = x.Calle,
                        Numero = x.Numero
                    }
                    ).FirstOrDefault(x => x.Id == entidadId && x.EstaEliminado == false);
            }
        }

        public bool VerificarSiExiste(string dni)
        {
            using (var context = new MiniGymModelContainer())
            {
                return context.Personas
                    .Any(x => x.Dni == dni && x.EstaEliminado == false);
            }
        }

        public bool VerificarSiExisteNombreApellido(string nombre, string apellido)
        {
            using (var context = new MiniGymModelContainer())
            {
                var aux = context.Personas
                    .FirstOrDefault(x => x.Nombre == nombre && x.Apellido == apellido && x.EstaEliminado == false);

                if (aux == null)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
