using MiniGym.Cuota;
using MiniGym.Cuota.Servicios;
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
    public partial class VerPlanes : Form
    {
        private readonly IPersonaServicio _clienteServicio;
        private readonly IPrestamoServicio _prestamoServicio;
        private readonly ICuotaServicio _cuotaServicio;
        protected long EntidadId;
        protected object EntidadSeleccionada;
        long PersonaId;
        long IdComprobanteSeleccionado;

        PrestamoDto _prestamo = new PrestamoDto();

        public VerPlanes()
        {
            InitializeComponent();

            _clienteServicio = new PersonaServicio();
            _prestamoServicio = new PrestamoServicio();
            _cuotaServicio = new CuotaServicio();
            IdComprobanteSeleccionado = 0;

        }

        public virtual void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["CodigoCredito"].Visible = true;
            grilla.Columns["CodigoCredito"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["CodigoCredito"].HeaderText = @"Codigo";
            grilla.Columns["CodigoCredito"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["CodigoCredito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["FechaInicio"].Visible = true;
            grilla.Columns["FechaInicio"].Width = 100;
            grilla.Columns["FechaInicio"].HeaderText = @"Fecha de Inicio";
            grilla.Columns["FechaInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["FechaInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstadoPrestamo"].Visible = true;
            grilla.Columns["EstadoPrestamo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoPrestamo"].HeaderText = @"Estado";
            grilla.Columns["EstadoPrestamo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstadoPrestamo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            var cliente = new PersonaCarpeta.ElejirCliente();
            cliente.ShowDialog();

            if (cliente.ClienteSeleccionado() != null)
            {
                //var aux = 0;
                var auxClienteEncontrado = _clienteServicio.ObtenerPorDni(cliente.ClienteSeleccionado());
                var aux2 = auxClienteEncontrado.Id;

                ObtenerPrestamoCliente(aux2);

                txtBusquedaCliente.Text = $"|--   {auxClienteEncontrado.Apellido},  {auxClienteEncontrado.Nombre}   --|      |----   DNI: {auxClienteEncontrado.Dni}   ----|";
                txtBusquedaCliente.Enabled = false;
                PersonaId = aux2;
                //nudId.Value =  auxClienteEncontrado.Id;
                //aux = Convert.ToInt32( nudId.Value);
                // ActualizarDatos(dgvGrilla, EntidadId);
            }
        }

        public virtual void ActualizarDatos(DataGridView grilla, long EntidadId)
        {
            dgvGrilla.DataSource = _prestamoServicio.ObtenerPrestamosPorClienteId(EntidadId);
        }

        private void ObtenerPrestamoCliente(long clienteId)
        {
            dgvGrilla.DataSource = _prestamoServicio.ObtenerPrestamosPorClienteId(clienteId);
            FormatearGrilla(dgvGrilla);

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
            //nudTotal.Value = _prestamo.TotalFinal;
            //nudInteres.Value = _prestamo.TasaInteres;
        }

        private void VerPrestamos_Load(object sender, System.EventArgs e)
        {
            EjecutarLoadFormulario();
            FormatearGrilla(dgvGrilla);
        }

        private bool HayDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }

        public virtual void EjecutarLoadFormulario()
        {
            ActualizarDatos(dgvGrilla, EntidadId);
        }

        private void dgvGrilla_DoubleClick(object sender, System.EventArgs e)
        {
            if (dgvGrilla.RowCount == 0)
            {
                MessageBox.Show(@"No hay Prestamos seleccionados", @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            var prestamoAux = _prestamoServicio.BuscarPrestamoPorId(IdComprobanteSeleccionado);

            if (prestamoAux.EstadoPrestamo == EstadoPrestamo.Cancelado)
            {

                MessageBox.Show("Este Prestamo Esta Cancelado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var cuota = new MiniGym.Cuota.CobrarCuota(IdComprobanteSeleccionado, PersonaId);
            cuota.ShowDialog();

            ObtenerPrestamoCliente(PersonaId);
            FormatearGrilla(dgvGrilla);

        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (checkHabilitar.Checked == false)
            {
                MessageBox.Show("|==== No Esta Habilitado Para Cancelar Prestamos! ====|", "PELIGRO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvGrilla.RowCount == 0)
            {
                MessageBox.Show(@"No hay Prestamos seleccionados", @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (_prestamoServicio.BuscarPrestamoPorId(IdComprobanteSeleccionado).EstadoPrestamo == EstadoPrestamo.Cancelado)
            {

                MessageBox.Show("Este Prestamo Ya Esta Cancelado!", "NotFound", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_prestamoServicio.BuscarPrestamoPorId(IdComprobanteSeleccionado).EstadoPrestamo == EstadoPrestamo.Terminado)
            {

                MessageBox.Show("Este Prestamo Se Encuentra TERMINADO", "NotFound", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (_prestamoServicio.BuscarPrestamoPorId(IdComprobanteSeleccionado).EstadoPrestamo == EstadoPrestamo.EnProceso)
            {

                var cuotas = _cuotaServicio.ObtenerCuotasPorIDComprobante(IdComprobanteSeleccionado);

                foreach (var item in cuotas)
                {
                    if (item.ValorParcial > 0)
                    {
                        MessageBox.Show("Este Prestamo Registra Movimientos, No Puede Cancelarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

            }

            if (MessageBox.Show("Esta Seguro De Cancelar Este Prestamo? Con Sus Respectivas Cuotas", "PELIGRO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                //cancelar prestamo
                _prestamoServicio.EliminarPrestamoCuotasComprobante(IdComprobanteSeleccionado);

                MessageBox.Show("---- Prestamo Cancelado Exitosamente! ----", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (PersonaId != 0)
                {
                    ObtenerPrestamoCliente(PersonaId);
                }
            }
            else
            {
                MessageBox.Show("Operacion Cancelada", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
