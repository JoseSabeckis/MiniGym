using MiniGym.Cuota.Servicios;
using MiniGym.Helpers;
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
    public partial class VerificarAcceso : Form
    {
        private readonly ICuotaServicio cuotaServicio;

        private readonly IPersonaServicio personaServicio;

        private readonly IPrestamoServicio prestamoServicio;

        public VerificarAcceso()
        {
            InitializeComponent();

            cuotaServicio = new CuotaServicio();
            personaServicio = new PersonaServicio();
            prestamoServicio = new PrestamoServicio();
        }

        private void VerificarAcceso_Load(object sender, EventArgs e)
        {
            txtDni.KeyPress += Validacion.NoSimbolos;
            txtDni.KeyPress += Validacion.NoLetras;
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Ingrese un Dni", "Dni incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (txtDni.Text.Length <= 7)
            {
                MessageBox.Show("El Dni debe contener 8 cifras","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtDni.Focus();
                return;
            }

            if (txtDni.Text.Length >= 9)
            {
                MessageBox.Show("El Dni debe contener 8 cifras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
                return;
            }           

            var persona = personaServicio.ObtenerPorDni(txtDni.Text);           

            if (persona == null)
            {
                pnlAcceso.BackColor = Color.Yellow;
                lblAcceso.Text = "-- No Se Encontro El Cliente --";

                return;
            }

            if (prestamoServicio.ObtenerPrestamosPorClienteId(persona.Id).Count() == 0)
            {
                MessageBox.Show("Este Cliente No Tiene Un Plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (cuotaServicio.VerificarCuotasVencidasPorClienteDni(persona))
            {
                pnlAcceso.BackColor = Color.Red;
                lblAcceso.Text = "!-- Tiene Cuotas Impagas --!";
            }
            else
            {
                pnlAcceso.BackColor = Color.Green;
                lblAcceso.Text = "--- Puede Pasar Esta Al Dia ---";
            }

        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnVerificar.PerformClick();
            }
        }
    }
}
