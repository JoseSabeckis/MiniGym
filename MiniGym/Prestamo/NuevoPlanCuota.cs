using MiniGym.Cuota.Servicios;
using MiniGym.FormularioBase;
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
    public partial class NuevoPlanCuota : FormularioAbm
    {
        IPrestamoServicio prestamoServico;
        IPersonaServicio _clienteServicio;
        MiniGym.Cuota.Servicios.ICuotaServicio _CuotaServicio;

        public NuevoPlanCuota()
        {
            InitializeComponent();

            prestamoServico = new PrestamoServicio();
            _clienteServicio = new PersonaServicio();
            _CuotaServicio = new MiniGym.Cuota.Servicios.CuotaServicio();
        }

        public void TraerCodigoCredito()
        {
            txtCredito.Text = $"{prestamoServico.VerCodigoDeCredito().ToString("0000")}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NuevoPlanCuota_Load(object sender, EventArgs e)
        {
            TraerCodigoCredito();

            lblfecha.Text = $"{DateTime.Now.ToShortDateString()}";
            txtDescripcion.Text = $"{DateTime.Now.Year}";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var cliente = new PersonaCarpeta.ElejirCliente();
            cliente.ShowDialog();

            if (cliente.ClienteSeleccionado() != null)
            {
                var auxClienteEncontrado = _clienteServicio.ObtenerPorDni(cliente.ClienteSeleccionado());

                txtBusquedaCliente.Text = $"{auxClienteEncontrado.Apellido}, {auxClienteEncontrado.Nombre}";
                txtDni.Text = $"{auxClienteEncontrado.Dni}";

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusquedaCliente.Text))
            {
                MessageBox.Show("No Hay Ningun Cliente Seleccionado Por Favor Cargue Uno", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Agregue una Descripcion", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudValorCuota.Value <= 0)
            {
                MessageBox.Show("No Ingreso Ningun Monto A Cobrar", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Esta Seguro De Realizar El Plan?...", "Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show("Plan CANCELADO ...", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            var idpersona = _clienteServicio.ObtenerPorDni(txtDni.Text).Id;

            var nuevoPrestamo = new PrestamoDto
            {
                CantidadCuotas = 12,
                CodigoCredito = txtCredito.Text,
                EstadoPrestamo = EstadoPrestamo.EnProceso,
                FechaInicio = DateTime.Now,
                Notas = txtNotas.Text,
                PersonaId = idpersona,
                Descripcion = txtDescripcion.Text
                
            };

            decimal valorCuotas = nudValorCuota.Value;

            prestamoServico.NuevoPrestamo(nuevoPrestamo);//creacion del prestamo

            var idprestamo = prestamoServico.TrerIdDelPrestamoPorFechaIinicio(nuevoPrestamo.FechaInicio);

            var cuota = new MiniGym.Cuota.Servicios.CuotaDto
            {
                ValorCuota = Math.Round(valorCuotas, 2),
                Saldo = valorCuotas,
                PrestamoId = idprestamo
            };

            _CuotaServicio.CargarCuotas(12, cuota, dtpFechaPrestamo.Value);//creacion de las cuotas



            MessageBox.Show($"-----------------------------------------------------\nFelicidades Acabas De Realizar Un Nuevo Plan -----------------------------------------------------", "Plan Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            nudValorCuota.Value = 0;
            txtDescripcion.Text = $"{DateTime.Now.Year}";
            txtNotas.Text = "";
            TraerCodigoCredito();
        }
    }
}
