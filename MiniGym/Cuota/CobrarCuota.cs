using MiniGym.Cuota.Servicios;
using MiniGym.Helpers;
using MiniGym.Localidad.Servicios;
using MiniGym.PersonaCarpeta.Servicios;
using MiniGym.Prestamo;
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
    public partial class CobrarCuota : Form
    {
        private long _ComprobanteId;
        private long _ClienteId;
        private long _CuotaId;
        private decimal _MontoCuota;

        Servicios.ICuotaServicio cuotaServicio;
        IPersonaServicio clienteServicio;
        IPrestamoServicio prestamoServicio;

        ILocalidadServicio localidadServicio;

        Servicios.CuotaDto _cuota = new Servicios.CuotaDto();

        public CobrarCuota(long idComprobante, long idPersona)
        {
            InitializeComponent();

            cuotaServicio = new Servicios.CuotaServicio();
            clienteServicio = new PersonaServicio();
            prestamoServicio = new PrestamoServicio();

            localidadServicio = new LocalidadServicio();

            _ComprobanteId = idComprobante;
            _ClienteId = idPersona;
            
            CargarGrilla();
            CalcularTotalesHistorial();
            VerificarSiEstaTodoPagado();
            cuotaServicio.VerificarVencimientoDeCuotasYPonerImpagas();
        }

        private void VerificarSiEstaTodoPagado()
        {
            var lista = cuotaServicio.ObtenerCuotasPorIDComprobante(_ComprobanteId);

            var bandera = false;
            var semaforo = 0;
            var totalcuotascount = lista.Count();

            foreach (var item in lista)
            {
                if (item.EstadoCuota == EstadoCuota.Cobrado)
                {
                    semaforo++;
                }

                if (totalcuotascount == semaforo)
                {
                    bandera = true;
                }

            }

            if (bandera)
            {
                lblFinal.Text = "Total Las Cuotas Estan Pagadas";
                lblFinal.BackColor = Color.Green;
                txtImporteRecibido.Enabled = false;
                txtImporteRecibido.Text = "Todo Saldado!";

                prestamoServicio.ModificarFechaFinDePrestamo(_ComprobanteId);
            }
        }

        private void CalcularTotalesHistorial()
        {
            var listaCuotas = cuotaServicio.ObtenerCuotasPorIDComprobante(_ComprobanteId);

            decimal sumaTotalACobrar = listaCuotas.Sum(x => x.ValorCuota);
            txtTotalCobrar.Text = $"${sumaTotalACobrar}";

            decimal totalAdeudado = listaCuotas.Sum(x => x.Saldo);

            decimal totalCobrado = listaCuotas.Sum(x => x.ValorParcial);
            txtAdeudado.Text = $"${sumaTotalACobrar - totalCobrado}";
            txtCobrado.Text = $"${totalCobrado}";

            //CantCuotas

            int cantidadCuotas = listaCuotas.Count();
            txtCantCuotas.Text = $"{cantidadCuotas}";

            var CuotasPagadas = listaCuotas.Where(x => x.EstadoCuota == EstadoCuota.Cobrado);
            int CantPagadas = CuotasPagadas.Count();

            txtCuotasPagadas.Text = $"{CantPagadas}";

            var CuotasImpagas = listaCuotas.Where(x => x.EstadoCuota == EstadoCuota.Impaga);
            int CantImpagas = CuotasImpagas.Count();

            txtCuotasImpagas.Text = $"{CantImpagas}";

            var CuotasPendientes = listaCuotas.Where(x => x.EstadoCuota == EstadoCuota.Pendiente);
            int CantPendientes = CuotasPendientes.Count();

            txtPendientes.Text = $"{CantPendientes}";

            var CuotasParcial = listaCuotas.Where(x => x.EstadoCuota == EstadoCuota.Parcial);
            int CantParcial = CuotasParcial.Count();

            txtParciales.Text = $"{CantParcial}";
        }

        private void CargarGrilla()
        {
            dgvGrilla.DataSource = cuotaServicio.ObtenerCuotasPorIDComprobante(_ComprobanteId);

            FormatearGrilla(dgvGrilla);
        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["NumeroCuota"].Visible = true;
            grilla.Columns["NumeroCuota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["NumeroCuota"].HeaderText = @"NroCuota";
            grilla.Columns["NumeroCuota"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstadoCuota"].Visible = true;
            grilla.Columns["EstadoCuota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoCuota"].HeaderText = @"EstadoCuota";
            grilla.Columns["EstadoCuota"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["ValorCuota"].Visible = true;
            grilla.Columns["ValorCuota"].Width = 100;
            grilla.Columns["ValorCuota"].HeaderText = @"ValorCuota";
            grilla.Columns["ValorCuota"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["ValorParcial"].Visible = true;
            grilla.Columns["ValorParcial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ValorParcial"].HeaderText = @"ValorParcial";
            grilla.Columns["ValorParcial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["FechaInicio"].Visible = true;
            grilla.Columns["FechaInicio"].Width = 180;
            grilla.Columns["FechaInicio"].HeaderText = @"FechaInicio";
            grilla.Columns["FechaInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["FechaInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["FechaVencimiento"].Visible = true;
            grilla.Columns["FechaVencimiento"].Width = 190;
            grilla.Columns["FechaVencimiento"].HeaderText = @"FechaVencimiento";
            grilla.Columns["FechaVencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["FechaVencimiento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CobrarCuota_Load(object sender, EventArgs e)
        {

            var cliente = clienteServicio.ObtenerPorId(_ClienteId);

            txtBusquedaCliente.Text = $" | {cliente.Apellido} {cliente.Nombre} - DNI: {cliente.Dni} |";



            CargarGrilla();
            CalcularTotalesHistorial();
            VerificarSiEstaTodoPagado();
            cuotaServicio.VerificarVencimientoDeCuotasYPonerImpagas();// -------------- VERIFICA SI ESTA VENCIDA

            if (_cuota.EstadoCuota == EstadoCuota.Cobrado)
            {
                txtImporteRecibido.Enabled = false;
                txtImporteRecibido.Text = "Cuota Pagada";
            }
            else
            {
                txtImporteRecibido.Enabled = true;
                txtImporteRecibido.Text = string.Empty;
            }
        }

        private void brnCobrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImporteRecibido.Text))
            {
                MessageBox.Show("Ingrese Un Importe Para Poder Cobrar La Cuota", "Ingrese Monto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_cuota.EstadoCuota == EstadoCuota.Cobrado)
            {
                txtImporteRecibido.Enabled = false;
                txtImporteRecibido.Text = "Cuota Pagada";
                MessageBox.Show("La Cuota Ya Esta Pagada", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Convert.ToDecimal(txtImporteRecibido.Text) > _cuota.ValorCuota)
            {
                MessageBox.Show("No Puede Pagar Un Monto Mayor A La Cuota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Si Esta Vencida
            if (_cuota.EstadoCuota == EstadoCuota.Impaga)
            {


                if (Convert.ToDecimal(txtImporteRecibido.Text) > _cuota.Saldo)
                {
                    MessageBox.Show("No Puede Pagar Mas, Que El Valor Que Debe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToDecimal(txtImporteRecibido.Text) < _cuota.Saldo)
                {
                    decimal monto = _cuota.Saldo - Convert.ToDecimal(txtImporteRecibido.Text);
                    decimal valorparcial = Convert.ToDecimal(txtImporteRecibido.Text);

                    var parcialCuota = new Servicios.CuotaDto
                    {
                        EstadoCuota = EstadoCuota.Impaga,
                        Saldo = monto,
                        CuotaId = _CuotaId,
                        FechaInicio = _cuota.FechaInicio,
                        FechaVencimiento = _cuota.FechaVencimiento,
                        NumeroCuota = _cuota.NumeroCuota,
                        PrestamoId = _cuota.PrestamoId,
                        ValorCuota = _cuota.ValorCuota,
                        ValorParcial = valorparcial
                    };

                    cuotaServicio.CobrarCuota(parcialCuota);

                    MessageBox.Show($"|------Cobro De Cuota Realizado Exitosamente------|\nMonto:${Convert.ToDecimal(txtImporteRecibido.Text)}", "Cobro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla();
                    CalcularTotalesHistorial();
                    VerificarSiEstaTodoPagado();

                    return;

                }

                if (Convert.ToDecimal(txtImporteRecibido.Text) == _cuota.Saldo)
                {
                    decimal monto = _cuota.Saldo - Convert.ToDecimal(txtImporteRecibido.Text);
                    decimal valorparcial = Convert.ToDecimal(txtImporteRecibido.Text);

                    var parcialCuota = new Servicios.CuotaDto
                    {
                        EstadoCuota = EstadoCuota.Cobrado,
                        Saldo = monto,
                        CuotaId = _CuotaId,
                        FechaInicio = _cuota.FechaInicio,
                        FechaVencimiento = _cuota.FechaVencimiento,
                        NumeroCuota = _cuota.NumeroCuota,
                        PrestamoId = _cuota.PrestamoId,
                        ValorCuota = _cuota.ValorCuota,
                        ValorParcial = valorparcial
                    };

                    cuotaServicio.CobrarCuota(parcialCuota);

                    MessageBox.Show($"|------Cobro De Cuota Realizado Exitosamente------|\nMonto:${Convert.ToDecimal(txtImporteRecibido.Text)}", "Cobro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla();
                    CalcularTotalesHistorial();
                    VerificarSiEstaTodoPagado();

                    return;

                }


                //-------------------------------------------------------------------------------//

                //Pago Parcial
                if (Convert.ToDecimal(txtImporteRecibido.Text) < _cuota.ValorCuota)
                {
                    decimal monto = _cuota.ValorCuota - Convert.ToDecimal(txtImporteRecibido.Text);
                    decimal valorparcial = Convert.ToDecimal(txtImporteRecibido.Text);

                    var parcialCuota = new Servicios.CuotaDto
                    {
                        EstadoCuota = EstadoCuota.Impaga,
                        Saldo = monto,
                        CuotaId = _CuotaId,
                        FechaInicio = _cuota.FechaInicio,
                        FechaVencimiento = _cuota.FechaVencimiento,
                        NumeroCuota = _cuota.NumeroCuota,
                        PrestamoId = _cuota.PrestamoId,
                        ValorCuota = _cuota.ValorCuota,
                        ValorParcial = valorparcial
                    };

                    cuotaServicio.CobrarCuota(parcialCuota);

                    MessageBox.Show($"|------Cobro De Cuota Realizado Exitosamente------|\nMonto:${Convert.ToDecimal(txtImporteRecibido.Text)}", "Cobro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla();
                    CalcularTotalesHistorial();
                    VerificarSiEstaTodoPagado();

                    return;

                }

                //Pago Total
                if (Convert.ToDecimal(txtImporteRecibido.Text) == _cuota.ValorCuota)
                {

                    decimal monto = Convert.ToDecimal(txtImporteRecibido.Text);
                    decimal valorparcial = monto;

                    var parcialCuota = new Servicios.CuotaDto
                    {
                        EstadoCuota = EstadoCuota.Cobrado,
                        Saldo = monto,
                        CuotaId = _CuotaId,
                        FechaInicio = _cuota.FechaInicio,
                        FechaVencimiento = _cuota.FechaVencimiento,
                        NumeroCuota = _cuota.NumeroCuota,
                        PrestamoId = _cuota.PrestamoId,
                        ValorCuota = _cuota.ValorCuota,
                        ValorParcial = valorparcial
                    };

                    cuotaServicio.CobrarCuota(parcialCuota);

                    MessageBox.Show($"|------Cobro De Cuota Realizado Exitosamente------|\nMonto:${Convert.ToDecimal(txtImporteRecibido.Text)}", "Cobro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla();
                    CalcularTotalesHistorial();
                    VerificarSiEstaTodoPagado();

                    return;

                }//------------

            }

            //Si ya Esta ParcialMentePagada
            //-------------------------------------------------------------------------------//----------------------------------

            if (_cuota.EstadoCuota == EstadoCuota.Parcial)
            {
                if (Convert.ToDecimal(txtImporteRecibido.Text) > _cuota.Saldo)
                {
                    MessageBox.Show("No Puede Pagar Mas, Que El Valor Que Debe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToDecimal(txtImporteRecibido.Text) < _cuota.Saldo)
                {
                    decimal monto = _cuota.Saldo - Convert.ToDecimal(txtImporteRecibido.Text);
                    decimal valorparcial = Convert.ToDecimal(txtImporteRecibido.Text);

                    var parcialCuota = new Servicios.CuotaDto
                    {
                        EstadoCuota = EstadoCuota.Parcial,
                        Saldo = monto,
                        CuotaId = _CuotaId,
                        FechaInicio = _cuota.FechaInicio,
                        FechaVencimiento = _cuota.FechaVencimiento,
                        NumeroCuota = _cuota.NumeroCuota,
                        PrestamoId = _cuota.PrestamoId,
                        ValorCuota = _cuota.ValorCuota,
                        ValorParcial = valorparcial
                    };

                    cuotaServicio.CobrarCuota(parcialCuota);

                    MessageBox.Show($"|------Cobro De Cuota Realizado Exitosamente------|\nMonto:${Convert.ToDecimal(txtImporteRecibido.Text)}", "Cobro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla();
                    CalcularTotalesHistorial();
                    VerificarSiEstaTodoPagado();

                    return;

                }

                if (Convert.ToDecimal(txtImporteRecibido.Text) == _cuota.Saldo)
                {
                    decimal monto = _cuota.Saldo - Convert.ToDecimal(txtImporteRecibido.Text);
                    decimal valorparcial = Convert.ToDecimal(txtImporteRecibido.Text);

                    var parcialCuota = new Servicios.CuotaDto
                    {
                        EstadoCuota = EstadoCuota.Cobrado,
                        Saldo = monto,
                        CuotaId = _CuotaId,
                        FechaInicio = _cuota.FechaInicio,
                        FechaVencimiento = _cuota.FechaVencimiento,
                        NumeroCuota = _cuota.NumeroCuota,
                        PrestamoId = _cuota.PrestamoId,
                        ValorCuota = _cuota.ValorCuota,
                        ValorParcial = valorparcial
                    };

                    cuotaServicio.CobrarCuota(parcialCuota);

                    MessageBox.Show($"|------Cobro De Cuota Realizado Exitosamente------|\nMonto:${Convert.ToDecimal(txtImporteRecibido.Text)}", "Cobro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla();
                    CalcularTotalesHistorial();
                    VerificarSiEstaTodoPagado();

                    return;

                }
            }

            //-------------------------------------------------------------------------------//

            //Pago Parcial
            if (Convert.ToDecimal(txtImporteRecibido.Text) < _cuota.ValorCuota)
            {
                decimal monto = _cuota.ValorCuota - Convert.ToDecimal(txtImporteRecibido.Text);
                decimal valorparcial = Convert.ToDecimal(txtImporteRecibido.Text);

                var parcialCuota = new Servicios.CuotaDto
                {
                    EstadoCuota = EstadoCuota.Parcial,
                    Saldo = monto,
                    CuotaId = _CuotaId,
                    FechaInicio = _cuota.FechaInicio,
                    FechaVencimiento = _cuota.FechaVencimiento,
                    NumeroCuota = _cuota.NumeroCuota,
                    PrestamoId = _cuota.PrestamoId,
                    ValorCuota = _cuota.ValorCuota,
                    ValorParcial = valorparcial
                };

                cuotaServicio.CobrarCuota(parcialCuota);

                MessageBox.Show($"|------Cobro De Cuota Realizado Exitosamente------|\nMonto:${Convert.ToDecimal(txtImporteRecibido.Text)}", "Cobro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
                CalcularTotalesHistorial();
                VerificarSiEstaTodoPagado();

                return;

            }

            //Pago Total
            if (Convert.ToDecimal(txtImporteRecibido.Text) == _cuota.ValorCuota)
            {

                decimal monto = Convert.ToDecimal(txtImporteRecibido.Text);
                decimal valorparcial = monto;

                var parcialCuota = new Servicios.CuotaDto
                {
                    EstadoCuota = EstadoCuota.Cobrado,
                    Saldo = monto,
                    CuotaId = _CuotaId,
                    FechaInicio = _cuota.FechaInicio,
                    FechaVencimiento = _cuota.FechaVencimiento,
                    NumeroCuota = _cuota.NumeroCuota,
                    PrestamoId = _cuota.PrestamoId,
                    ValorCuota = _cuota.ValorCuota,
                    ValorParcial = valorparcial
                };

                cuotaServicio.CobrarCuota(parcialCuota);

                MessageBox.Show($"|------Cobro De Cuota Realizado Exitosamente------|\nMonto:${Convert.ToDecimal(txtImporteRecibido.Text)}", "Cobro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
                CalcularTotalesHistorial();
                VerificarSiEstaTodoPagado();

                return;

            }
        }

        private void txtImporteRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtImporteRecibido.KeyPress += Validacion.NoLetras;
            txtImporteRecibido.KeyPress += Validacion.NoSimbolos;

            if (string.IsNullOrWhiteSpace(txtImporteRecibido.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RowEnter(e);
        }

        public virtual void RowEnter(DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _cuota = (Servicios.CuotaDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }

            _CuotaId = _cuota.CuotaId;
            _MontoCuota = _cuota.ValorCuota;

            txtSubtotal.Text = $"Monto Cuota: ${_MontoCuota}";

            if (_cuota.Saldo == _cuota.ValorParcial)
            {
                txtImporteSeleccionado.Text = "Debe: $0";
            }
            else
            {
                txtImporteSeleccionado.Text = $"Debe: ${_cuota.Saldo}";
            }


            txtNumeroCuota.Text = $"Nro: {_cuota.NumeroCuota}";

            if (_cuota.EstadoCuota == EstadoCuota.Cobrado)
            {
                txtImporteRecibido.Enabled = false;
                txtImporteRecibido.Text = "Cuota Pagada";
            }
            else
            {
                txtImporteRecibido.Enabled = true;
                txtImporteRecibido.Text = string.Empty;
            }
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (!cuotaServicio.VerificarSiLaCuotaEstaPagada(_CuotaId))
            {
                var aumento = new AumentoCuota(_CuotaId);
                aumento.ShowDialog();

                CargarGrilla();
                CalcularTotalesHistorial();
            }
            else
            {
                MessageBox.Show("Esta Cuota Se Encuentra Pagada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            var prestamo = prestamoServicio.BuscarPrestamoPorId(_ComprobanteId);

            if (prestamo.Notas != string.Empty)
            {
                MessageBox.Show($"Notas Del Plan: {prestamo.Notas} ", "Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Hay Notas En Este Plan", "Notas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
