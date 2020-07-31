using MiniGym.FormularioBase;
using MiniGym.Helpers;
using MiniGym.Localidad.Servicios;
using MiniGym.PersonaCarpeta.Servicios;
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

namespace MiniGym.PersonaCarpeta
{
    public partial class PersonaABM : FormularioAbm
    {
        private readonly IPersonaServicio _clienteServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;


        public PersonaABM(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _clienteServicio = new PersonaServicio();
            _provinciaServicio = new ProvinciaServicio();
            _localidadServicio = new LocalidadServicio();



            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtApellido, "Apellido");
            // AgregarControlesObligatorios(txtNombre, "Nombre");
            AgregarControlesObligatorios(txtDni, "DNI");
            // AgregarControlesObligatorios(txtCuil, "CUIL");
            //  AgregarControlesObligatorios(txtEmail, "E-Mail");
            AgregarControlesObligatorios(txtCalle, "Calle");
            AgregarControlesObligatorios(cmbProvincia, "Provincia");
            AgregarControlesObligatorios(cmbLocalidad, "Localidad");

            //AgregarControlesObligatorios(nudMontoMaximo, "Monto Maximo");

            Inicializador(entidadId);

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");


            if (cmbProvincia.Items.Count > 0)
            {
                var provincia = (ProvinciaDto)cmbProvincia.Items[0];

                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(provincia.Id, string.Empty), "Descripcion", "Id");
            }

            // Asignando un Evento
            txtApellido.KeyPress += Validacion.NoSimbolos;
            txtApellido.KeyPress += Validacion.NoNumeros;

            txtDni.KeyPress += Validacion.NoSimbolos;
            txtDni.KeyPress += Validacion.NoLetras;

            txtCuil.KeyPress += Validacion.NoSimbolos;
            txtCuil.KeyPress += Validacion.NoLetras;

            txtTelefono.KeyPress += Validacion.NoSimbolos;
            txtTelefono.KeyPress += Validacion.NoLetras;

            txtCelular.KeyPress += Validacion.NoSimbolos;
            txtCelular.KeyPress += Validacion.NoLetras;

            txtNumero.KeyPress += Validacion.NoSimbolos;
            txtNumero.KeyPress += Validacion.NoLetras;


            txtApellido.Focus();
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

            var cliente = _clienteServicio.ObtenerPorId(entidadId.Value);
            var localidad = _localidadServicio.ObtenerPorId(cliente.LocalidadId);

            // Datos Personales
            txtApellido.Text = cliente.Apellido;
            txtNombre.Text = cliente.Nombre;
            txtDni.Text = cliente.Dni;
            txtTelefono.Text = cliente.Telefono;
            txtCelular.Text = cliente.Celular;
            txtEmail.Text = cliente.Mail;
            txtCuil.Text = cliente.Cuil;
            dtpFechaNacimiento.Value = cliente.FechaNacimiento;
            txtCalle.Text = cliente.Calle;
            txtNumero.Text = cliente.Numero.ToString();

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad, _localidadServicio.ObtenerPorProvincia(localidad.ProvinciaId, string.Empty), "Descripcion", "Id");
            }

            cmbProvincia.SelectedValue = localidad.ProvinciaId;
            cmbLocalidad.SelectedValue = cliente.LocalidadId;

        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (txtDni.Text.Length <= 7)
            {
                MessageBox.Show("El Dni debe contener 8 cifras");
                txtDni.Focus();
                return false;
            }

            if (!_clienteServicio.VerificarSiExiste(txtDni.Text))
            {
                var nuevoCliente = new PersonaDto
                {
                    Apellido = txtApellido.Text,
                    Nombre = txtNombre.Text,
                    Calle = txtCalle.Text,
                    Celular = txtCelular.Text,
                    Cuil = txtCuil.Text,
                    Dni = txtDni.Text,
                    Mail = txtEmail.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Telefono = txtTelefono.Text,
                    LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                    EstaEliminado = false,
                    Numero = txtNumero.Text
                };

                _clienteServicio.Insertar(nuevoCliente);

                return true;
            }
            else
            {

                MessageBox.Show(@"Ya Existe Cliente con ese Dni.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var clienteParaModificar = new PersonaDto
            {
                Id = EntidadId.Value,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Calle = txtCalle.Text,
                Celular = txtCelular.Text,
                Cuil = txtCuil.Text,
                Dni = txtDni.Text,
                Mail = txtEmail.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Numero = txtNumero.Text,
                Telefono = txtTelefono.Text,
                LocalidadId = ((LocalidadDto)cmbLocalidad.SelectedItem).Id,
                EstaEliminado = false,               

            };


            _clienteServicio.Modificar(clienteParaModificar);


            return true;
        }

        public override bool EjecutarComandoEliminar()
        {

            if (EntidadId == null) return false;

            _clienteServicio.Eliminar(EntidadId.Value);

            return true;


        }

        private void CmbProvincia_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion",
                    "Id");
            }
        }

        private void btnNuevaProvincia_Click(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new ProvinciaCarpeta.ProvinciaABM(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();

            if (!fNuevaProvincia.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

        private void btnLocalidad_Click(object sender, System.EventArgs e)
        {
            var fNuevaLocalidad = new LocalidadCarpeta.LocalidadABM(TipoOperacion.Nuevo);
            fNuevaLocalidad.ShowDialog();

            if (!fNuevaLocalidad.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbProvincia, _provinciaServicio.Obtener(string.Empty), "Descripcion", "Id");

            if (cmbProvincia.Items.Count > 0)
            {
                CargarComboBox(cmbLocalidad,
                    _localidadServicio.ObtenerPorProvincia(((ProvinciaDto)cmbProvincia.SelectedItem).Id, string.Empty),
                    "Descripcion", "Id");
            }
        }

        private void txtDni_Leave(object sender, System.EventArgs e)
        {
            //if (txtDni.Text.Length <= 7)
            //{
            //    MessageBox.Show("El Dni debe contener 8 cifras");
            //    txtDni.Focus();
            //}
        }

        private void txtCuil_Leave(object sender, System.EventArgs e)
        {
            //if (txtCuil.Text.Length <= 10)
            //{
            //    MessageBox.Show("El Cuil debe contener 11 cifras");
            //    txtCuil.Focus();
            //}
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        //private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtNombre.Text))
        //    {
        //        if ((char.IsWhiteSpace(e.KeyChar)))
        //        {
        //            e.Handled = true;
        //        }
        //    }
        //}

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        private void _0006_Cliente_Abm_Load(object sender, System.EventArgs e)
        {

        }

        private void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

    }
}
