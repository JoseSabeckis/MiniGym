using MiniGym.Cuota.Servicios;
using MiniGym.FormularioBase;
using MiniGym.Helpers;
using MiniGym.PersonaCarpeta.Servicios;
using MiniGym.Plan.Servicios;
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
        ICuotaServicio _CuotaServicio;
        IPlanServicio _PlanServicio;

        bool bandera = false;

        public NuevoPlanCuota(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            prestamoServico = new PrestamoServicio();
            _clienteServicio = new PersonaServicio();
            _CuotaServicio = new CuotaServicio();
            _PlanServicio = new PlanServicio();

            btnLimpiar.Visible = false;

            CargarComboBox(cmbPlan, _PlanServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (_PlanServicio.Obtener(string.Empty) == null)
            {
                lblCategoria.Visible = true;
                bandera = true;
            }
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

            TraerCodigoCredito();
        }

        public override bool EjecutarComandoNuevo()
        {
            if (bandera)
            {
                MessageBox.Show("Cree una Categoria para el Plan 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (string.IsNullOrEmpty(txtBusquedaCliente.Text))
            {
                MessageBox.Show("No Hay Ningun Cliente Seleccionado Por Favor Cargue Uno", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nudValorCuota.Value <= 0)
            {
                MessageBox.Show("No Ingreso Ningun Monto A Cobrar", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nudNumeroCuotas.Value <= 0)
            {
                MessageBox.Show("El Numero De Cuotas Tiene Que Ser Mayor a Cero", "error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (MessageBox.Show("Esta Seguro De Realizar El Plan?...", "Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                MessageBox.Show("Plan CANCELADO ...", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            var idpersona = _clienteServicio.ObtenerPorDni(txtDni.Text).Id;

            var nuevoPrestamo = new PrestamoDto
            {
                CantidadCuotas = (int)nudNumeroCuotas.Value,
                CodigoCredito = txtCredito.Text,
                EstadoPrestamo = EstadoPrestamo.EnProceso,
                FechaInicio = DateTime.Now,
                Notas = txtNotas.Text,
                PersonaId = idpersona,
                PlanId = ((PlanDto)cmbPlan.SelectedItem).Id,

            };

            decimal valorCuotas = nudValorCuota.Value;

            prestamoServico.NuevoPrestamo(nuevoPrestamo);//creacion del prestamo

            var idprestamo = prestamoServico.TrerIdDelPrestamoPorFechaIinicio(nuevoPrestamo.FechaInicio);

            var cuota = new CuotaDto
            {
                ValorCuota = Math.Round(valorCuotas, 2),
                Saldo = valorCuotas,
                PrestamoId = idprestamo
            };

            _CuotaServicio.CargarCuotas(12, cuota, dtpFechaPrestamo.Value);//creacion de las cuotas

            nudNumeroCuotas.Value = 12;
            txtNotas.Text = "";
            TraerCodigoCredito();

            return true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                MessageBox.Show("Cree una Categoria para el Plan 2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (string.IsNullOrEmpty(txtBusquedaCliente.Text))
            {
                MessageBox.Show("No Hay Ningun Cliente Seleccionado Por Favor Cargue Uno", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                PlanId = ((PlanDto)cmbPlan.SelectedItem).Id,

            };

            decimal valorCuotas = nudValorCuota.Value;

            prestamoServico.NuevoPrestamo(nuevoPrestamo);//creacion del prestamo

            var idprestamo = prestamoServico.TrerIdDelPrestamoPorFechaIinicio(nuevoPrestamo.FechaInicio);

            var cuota = new CuotaDto
            {
                ValorCuota = Math.Round(valorCuotas, 2),
                Saldo = valorCuotas,
                PrestamoId = idprestamo
            };

            _CuotaServicio.CargarCuotas(12, cuota, dtpFechaPrestamo.Value);//creacion de las cuotas



            MessageBox.Show($"-----------------------------------------------------\nFelicidades Acabas De Realizar Un Nuevo Plan -----------------------------------------------------", "Plan Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            nudNumeroCuotas.Value = 12;
            txtNotas.Text = "";
            TraerCodigoCredito();
        }

        private void nudValorCuota_ValueChanged(object sender, EventArgs e)
        {
            TraerCodigoCredito();
        }
    }
}
