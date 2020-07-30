using MiniGym.PersonaCarpeta.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym.PersonaCarpeta
{
    public partial class ElejirCliente : Form
    {
        private readonly IPersonaServicio _clienteServicio;

        public ElejirCliente()
        {
            InitializeComponent();

            _clienteServicio = new PersonaServicio();

            CargarDatos();
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
            dgvGrilla.Columns["Dni"].Width = 250;
            dgvGrilla.Columns["Dni"].HeaderText = @"Dni";
            dgvGrilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["Dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarDatos()
        {
            dgvGrilla.DataSource = _clienteServicio.Obtener(string.Empty);
        }

        private string _dni;

        private string _id;

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _dni = (string)dgvGrilla["Dni", e.RowIndex].Value;
                //_id = (string)dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                _dni = null;
                //_id = null;
            }
        }

        public string ClienteSeleccionado()
        {
            return _dni;
        }

        public string ClienteSeleccionadoId()
        {
            return _id;
        }

        private void dgvGrilla_DoubleClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusqueda.Text))
            {
                MessageBox.Show("Por Favor Escriba Para Poder Buscar, Se Puede Buscar Por DNI, Apellido, Nombre", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            dgvGrilla.DataSource = _clienteServicio.Obtener(txtBusqueda.Text);
            FormaltearGrilla();
        }
    }
}
