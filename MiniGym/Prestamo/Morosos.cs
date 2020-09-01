using MiniGym.Cuota.Servicios;
using MiniGym.Localidad.Servicios;
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
    public partial class Morosos : Form
    {
        ICuotaServicio cuotaServicio;
        IPersonaServicio clienteServicio;
        IPrestamoServicio prestamoServicio;
        ILocalidadServicio localidadServicio;


        private string _dni;
        private long _ComprobanteId;

        public Morosos()
        {
            InitializeComponent();

            cuotaServicio = new CuotaServicio();
            clienteServicio = new PersonaServicio();
            prestamoServicio = new PrestamoServicio();
            localidadServicio = new LocalidadServicio();

            cuotaServicio.VerificarVencimientoDeCuotasYPonerImpagas();
        }

        private void ClientesAdeudados_Load(object sender, EventArgs e)
        {

            CargarGrilla();

        }


        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _dni = (string)dgvGrilla["Dni", e.RowIndex].Value;
            }
            else
            {
                _dni = null;
            }
        }

        public void CargarGrilla()
        {
            //traer los clientes
            var ListaClientes = clienteServicio.ObtenerList(string.Empty);

            var resultado = prestamoServicio.ObtenerPrestamosAdeudadosList(ListaClientes);


            dgvGrilla.DataSource = resultado;

            FormaltearGrilla();
        }

        private void FormaltearGrilla()
        {
            for (var i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["Dni"].Visible = true;
            dgvGrilla.Columns["Dni"].Width = 150;
            dgvGrilla.Columns["Dni"].HeaderText = @"Dni";
            dgvGrilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrilla.Columns["TotalAdeudado"].Visible = true;
            dgvGrilla.Columns["TotalAdeudado"].Width = 300;
            dgvGrilla.Columns["TotalAdeudado"].HeaderText = @"TotalAdeudado";
            dgvGrilla.Columns["TotalAdeudado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["TotalAdeudado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount == 0)
            {
                MessageBox.Show(@"No hay Cliente seleccionados", @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            var prestamo = new PrestamosDeUnCliente(_dni);
            prestamo.ShowDialog();

            CargarGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusquedaCliente.Text == string.Empty)
            {
                return;
            }

            //traer los clientes
            var ListaClientes = clienteServicio.ObtenerList(txtBusquedaCliente.Text);

            var resultado = prestamoServicio.ObtenerPrestamosAdeudadosList(ListaClientes);


            dgvGrilla.DataSource = resultado;

            FormaltearGrilla();
        }
    }
}
