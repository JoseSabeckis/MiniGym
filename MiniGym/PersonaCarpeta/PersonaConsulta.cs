using MiniGym.FormularioBase;
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

namespace MiniGym.PersonaCarpeta
{
    public partial class PersonaConsulta : FormularioConsulta
    {
        private readonly IPersonaServicio _personaServicio;
        private readonly IPrestamoServicio _prestamoServicio;

        public PersonaConsulta()
            : this(new PersonaServicio())
        {
            InitializeComponent();

            _prestamoServicio = new PrestamoServicio();
        }

        public PersonaConsulta(IPersonaServicio empleadoServicio)
        {
            _personaServicio = empleadoServicio;
            
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Apellido"].Visible = true;
            grilla.Columns["Apellido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Apellido"].HeaderText = @"Apellido y Nombre";
            grilla.Columns["Apellido"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Dni"].Visible = true;
            grilla.Columns["Dni"].Width = 100;
            grilla.Columns["Dni"].HeaderText = @"DNI";
            grilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Celular"].Visible = true;
            grilla.Columns["Celular"].Width = 150;
            grilla.Columns["Celular"].HeaderText = @"Celular";
            grilla.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Calle"].Visible = true;
            grilla.Columns["Calle"].Width = 150;
            grilla.Columns["Calle"].HeaderText = @"Calle";
            grilla.Columns["Calle"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Numero"].Visible = true;
            grilla.Columns["Numero"].Width = 150;
            grilla.Columns["Numero"].HeaderText = @"Numero";
            grilla.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _personaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fClienteAbm = new PersonaABM(TipoOperacion.Nuevo);
            fClienteAbm.ShowDialog();

            ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (dgvGrilla.RowCount == 0)
            {

            }
            else
            {

                if (!((PersonaDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarModificar();

                    if (!PuedeEjecutarComando) return;

                    var fClienteAbm = new PersonaABM(TipoOperacion.Modificar, EntidadId);
                    fClienteAbm.ShowDialog();

                    ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
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
                if (EntidadId.Value == 1)
                {
                    MessageBox.Show("Este Cliente Fue Creado Como Administrador, No Puede Eliminarse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (_prestamoServicio.ObtenerPrestamosPorClienteIdSinPrestamosTerminados(EntidadId.Value).Count() != 0)
                {
                    MessageBox.Show("Este Cliente Tiene Planes EnProceso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (!((PersonaDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarEliminar();

                    if (!PuedeEjecutarComando) return;

                    var fClienteAbm = new PersonaABM(TipoOperacion.Eliminar, EntidadId);

                    fClienteAbm.ShowDialog();

                    ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
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
