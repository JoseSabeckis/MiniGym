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

namespace MiniGym.Cuota
{
    public partial class ModificarNotas : Form
    {
        private IPrestamoServicio prestamoServicio;

        long _PrestamoId;

        public ModificarNotas(long prestamoId)
        {
            InitializeComponent();

            prestamoServicio = new PrestamoServicio();

            var notas = prestamoServicio.BuscarPrestamoPorId(prestamoId);

            txtNotas.Text = notas.Notas;

            _PrestamoId = prestamoId;
        }

        private void txtVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            prestamoServicio.ModificarNotas(_PrestamoId, txtNotas.Text);

            MessageBox.Show("Notas Guardadas", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
