using MiniGym.Helpers;
using MiniGym.Plan.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym.Plan
{
    public partial class Plan_ABM : FormularioBase.FormularioAbm
    {
        private IPlanServicio planServicio;

        public Plan_ABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

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

            planServicio = new PlanServicio();
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            AgregarControlesObligatorios(txtDescripcion.Text, "txtDescripcion");
            AgregarControlesObligatorios(nudPrecio.Value, "nudPrecio");

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

            var plan = planServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = plan.Descripcion;
            nudPrecio.Value = plan.Precio;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (nudPrecio.Value <= 0)
            {
                MessageBox.Show(@"Por favor ingrese un precio mayor a Cero", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (nudPrecio.Value <= 0)
            {
                MessageBox.Show(@"Por favor ingrese un precio mayor a Cero", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var plan = new PlanDto
            {
                Descripcion = txtDescripcion.Text,
                Precio = nudPrecio.Value
            };

            planServicio.Insertar(plan);

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

            var Modificar = new PlanDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Precio = nudPrecio.Value
            };

            planServicio.Modificar(Modificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            planServicio.Eliminar(EntidadId.Value);

            return true;
        }
    }
}
