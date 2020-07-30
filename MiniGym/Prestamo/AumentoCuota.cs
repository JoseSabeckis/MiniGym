using MiniGym.Cuota.Servicios;
using MiniGym.Helpers;
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
    public partial class AumentoCuota : Form
    {
        MiniGym.Cuota.Servicios.ICuotaServicio _CuotaServicio;
        IPrestamoServicio _PrestamoServicio;

        private long _CuotaId;

        public AumentoCuota(long cuotaId)
        {
            InitializeComponent();

            _CuotaServicio = new MiniGym.Cuota.Servicios.CuotaServicio();
            _PrestamoServicio = new PrestamoServicio();

            _CuotaId = cuotaId;


            CargarDatos();
        }

        public void CargarDatos()
        {
            var cuota = _CuotaServicio.ObtenerCuotaPorId(_CuotaId);

            txtNroCuota.Text = $"{cuota.NumeroCuota}";

            txtValorCuota.Text = $"{cuota.ValorCuota}";


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudAumentar_ValueChanged(object sender, EventArgs e)
        {
            if (nudAumentar.Value <= 0)
            {
                MessageBox.Show("Ingrese Un Valor ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cuota = _CuotaServicio.ObtenerCuotaPorId(_CuotaId);

            txtValorCuota.Text = $"{cuota.ValorCuota + (cuota.ValorCuota * nudAumentar.Value / 100) }";
        }

        private void txtValorCuota_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtValorCuota.KeyPress += Validacion.NoLetras;
            txtValorCuota.KeyPress += Validacion.NoSimbolos;

            if (string.IsNullOrWhiteSpace(txtValorCuota.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValorCuota.Text))
            {
                MessageBox.Show("Ingrese Un Valor a la Cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cuota = _CuotaServicio.ObtenerCuotaPorId(_CuotaId);

            if (Convert.ToDecimal(txtValorCuota.Text) <= cuota.ValorCuota)
            {
                MessageBox.Show("El Valor De La Cuota No Puede Ser Igual o Menor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Modificacion Del Valor Cuota
            var nuevoValor = Convert.ToDecimal(txtValorCuota.Text);

            if (MessageBox.Show($"Esta Seguro De Cambiar El Valor De La Cuota:\nValor Anterior:{cuota.ValorCuota}\nNuevo Valor:{nuevoValor}", "Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _CuotaServicio.ModificarValorCuota(_CuotaId, nuevoValor);

                MessageBox.Show($"Modificacion Del Valor De La Cuota Realizado Exitosamente!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Se Cancelo El Cambio De Valor Cuota", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
