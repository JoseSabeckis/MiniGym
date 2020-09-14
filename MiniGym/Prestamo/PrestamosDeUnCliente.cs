using MiniGym.Cuota;
using MiniGym.PersonaCarpeta.Servicios;
using MiniGym.Prestamo.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym.Prestamo
{
    public partial class PrestamosDeUnCliente : Form
    {
        private readonly IPersonaServicio _clienteServicio;
        private readonly IPrestamoServicio _prestamoServicio;
        protected long EntidadId;
        protected object EntidadSeleccionada;
        long PersonaId;
        string Dni;
        long IdComprobanteSeleccionado;

        PrestamoDto _prestamo = new PrestamoDto();

        public PrestamosDeUnCliente(string dni)
        {
            InitializeComponent();

            _clienteServicio = new PersonaServicio();
            _prestamoServicio = new PrestamoServicio();
            IdComprobanteSeleccionado = 0;
            Dni = dni;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        public virtual void RowEnter(DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _prestamo = (PrestamoDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }

            IdComprobanteSeleccionado = _prestamo.PrestamoId;
            PersonaId = _prestamo.PersonaId;
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount == 0)
            {
                MessageBox.Show(@"No hay Prestamos seleccionados", @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            var cuota = new CobrarCuota(IdComprobanteSeleccionado, PersonaId);
            cuota.ShowDialog();

            ObtenerPrestamoCliente(Dni);
        }

        private bool HayDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }

        public virtual void EjecutarLoadFormulario()
        {
            ActualizarDatos(dgvGrilla, EntidadId);
        }

        public virtual void ActualizarDatos(DataGridView grilla, long EntidadId)
        {
            dgvGrilla.DataSource = _prestamoServicio.ObtenerPrestamosPorClienteIdSinPrestamosTerminados(EntidadId);
        }

        public virtual void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["CodigoCredito"].Visible = true;
            grilla.Columns["CodigoCredito"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["CodigoCredito"].HeaderText = @"CodigoCredito";
            grilla.Columns["CodigoCredito"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["FechaInicio"].Visible = true;
            grilla.Columns["FechaInicio"].Width = 200;
            grilla.Columns["FechaInicio"].HeaderText = @"FechaInicio";
            grilla.Columns["FechaInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["FechaInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void ObtenerPrestamoCliente(string dni)
        {
            dgvGrilla.DataSource = _prestamoServicio.ObtenerPrestamosPorClienteDniSinTerminado(dni);
            FormatearGrilla(dgvGrilla);

        }

        private void PrestamosDeUnCliente_Load(object sender, EventArgs e)
        {
            var cliente = _clienteServicio.ObtenerPorDni(Dni);

            lblCliente.Text = $"Cliente: {cliente.Apellido} {cliente.Nombre} - {cliente.Dni}";

            ObtenerPrestamoCliente(Dni);
        }
    }
}
