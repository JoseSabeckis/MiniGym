using MiniGym.FormularioBase;
using MiniGym.Helpers;
using MiniGym.Localidad.Servicios;
using MiniGym.Provincia.Servicios;
using MiniGym.ProvinciaCarpeta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym.LocalidadCarpeta
{
    public partial class LocalidadABM : FormularioAbm
    {
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;

        public LocalidadABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _provinciaServicio = new ProvinciaServicio();
            _localidadServicio = new LocalidadServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripción");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
            //CargarComboBox(cmbZona, _zonaservicio.Obtener(string.Empty), "Nombre", "Id");

            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
            //CargarComboBox(cmbZona, _zonaservicio.Obtener(string.Empty), "Nombre", "Id");

            var localidad = _localidadServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = localidad.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaLocalidad = new LocalidadDto
            {
                Descripcion = $"{txtDescripcion.Text}",
                ProvinciaId = ((ProvinciaDto)cmbProvincia.SelectedItem).Id,
                //ZonaId = ((ZonaDto)cmbZona.SelectedItem).Id
            };

            _localidadServicio.Insertar(nuevaLocalidad);

            /* CargarComboBox(cmbZona,
                     _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                     "Descripcion", "Id");*/

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var localidadParaModificar = new LocalidadDto
            {
                Id = EntidadId.Value,
                Descripcion = $"{txtDescripcion.Text}",
                ProvinciaId = ((ProvinciaDto)cmbProvincia.SelectedItem).Id,
                //ZonaId = ((ZonaDto)cmbZona.SelectedItem).Id
            };

            _localidadServicio.Modificar(localidadParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _localidadServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void BtnNuevaProvincia_Click(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new ProvinciaABM(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();

            if (fNuevaProvincia.RealizoAlgunaOperacion)
            {
                CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {/*
                CargarComboBox(cmbZona,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");

                CargarComboBox(cmbZona, _zonaservicio.Obtener(string.Empty), "Nombre", "Id");*/
            }
        }
    }
}
