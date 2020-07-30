using MiniGym.FormularioBase;
using MiniGym.Helpers;
using MiniGym.Provincia.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym.ProvinciaCarpeta
{
    public partial class ProvinciaABM : FormularioAbm
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public ProvinciaABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _provinciaServicio = new ProvinciaServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripción");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            txtDescripcion.KeyPress += Validacion.NoNumeros;

            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            var provincia = _provinciaServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = provincia.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaProvincia = new ProvinciaDto
            {
                Descripcion = txtDescripcion.Text,
            };

            _provinciaServicio.Insertar(nuevaProvincia);

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var provinciaParaModificar = new ProvinciaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _provinciaServicio.Modificar(provinciaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _provinciaServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDescripcion_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
