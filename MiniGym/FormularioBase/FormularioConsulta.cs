using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym.FormularioBase
{
    public partial class FormularioConsulta : FormularioBase
    {
        protected long? EntidadId;
        protected bool PuedeEjecutarComando;
        protected object EntidadSeleccionada;

        public FormularioConsulta()
        {
            InitializeComponent();

            //btnImprimir.Visible = false;

            //Agregar imagenes

            // Asigncacion de Imagenes a Botones
           

            txtBuscar.Enter += Control_Enter;
            txtBuscar.Leave += Control_Leave;

            EntidadId = null;
            PuedeEjecutarComando = false;

            AsignarEventoEnterLeave(this);

            dgvGrilla.Font = new Font("Century Gothic", 10);
        }

        private bool HayDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }


        public virtual void EjecutarNuevo()
        {

        }

        public virtual void EjecutarEliminar()
        {
            if (HayDatosCargados())
            {
                if (!EntidadId.HasValue)
                {
                    MessageBox.Show(@"Por favor seleccione un registro.");
                    PuedeEjecutarComando = false;
                    return;
                }

                PuedeEjecutarComando = true;
            }
            else
            {
                MessageBox.Show(@"No hay Datos cargados");
            }
        }


        public virtual void EjecutarModificar()
        {
            if (HayDatosCargados())
            {
                if (!EntidadId.HasValue)
                {
                    MessageBox.Show(@"Por favor seleccione un registro.");
                    PuedeEjecutarComando = false;
                    return;
                }

                PuedeEjecutarComando = true;
            }
            else
            {
                MessageBox.Show(@"No hay Datos cargados");
            }
        }


        public virtual void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {

        }

        public virtual void RowEnter(DataGridViewCellEventArgs e)
        {
            if (HayDatosCargados())
            {

                EntidadId = (int)(long?)dgvGrilla["Id", e.RowIndex].Value;
                EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadId = null;
                EntidadSeleccionada = null;
            }
        }

        public virtual void EjecutarLoadFormulario()
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        // =========================================================== //

        public virtual void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, txtBuscar.Text);

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            EjecutarNuevo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EjecutarEliminar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EjecutarModificar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        private void FormularioConsulta_Load_1(object sender, EventArgs e)
        {
            EjecutarLoadFormulario();
            FormatearGrilla(dgvGrilla);
        }

        private void dgvGrilla_DoubleClick_1(object sender, EventArgs e)
        {

        }

        private void dgvGrilla_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, txtBuscar.Text);
        }
    }
}
