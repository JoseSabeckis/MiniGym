using MiniGym.FormularioBase;
using MiniGym.Helpers;
using MiniGym.Provincia.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym.Provincia
{
    public partial class ProvinciaConsulta : FormularioConsulta
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public ProvinciaConsulta()
            : this(new ProvinciaServicio())
        {
            InitializeComponent();
        }

        public ProvinciaConsulta(IProvinciaServicio provinciaServicio)
        {
            _provinciaServicio = provinciaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Provincia";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _provinciaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new ProvinciaCarpeta.ProvinciaABM(TipoOperacion.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (dgvGrilla.RowCount == 0)
            {

            }
            else
            {
                if (!((ProvinciaDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarModificar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new ProvinciaCarpeta.ProvinciaABM(TipoOperacion.Modificar, EntidadId);
                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        public override void EjecutarEliminar()
        {
            if (dgvGrilla.RowCount == 0)
            {

            }
            else
            {
                if (_provinciaServicio.ObtenerClientesConProvincia(((ProvinciaDto)EntidadSeleccionada).Id))
                {
                    MessageBox.Show("Esta Provincia Tiene Localidades Asociadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (!((ProvinciaDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarEliminar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new ProvinciaCarpeta.ProvinciaABM(TipoOperacion.Eliminar, EntidadId);

                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
