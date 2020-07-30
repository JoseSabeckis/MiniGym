using MiniGym.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym.FormularioBase
{
    public partial class FormularioAbm : FormularioBase
    {
        protected TipoOperacion TipoOperacion;
        protected long? EntidadId;

        public bool RealizoAlgunaOperacion { get; set; }

        public FormularioAbm()
        {
            InitializeComponent();
        }

        public FormularioAbm(TipoOperacion tipoOperacion, long? entidadId)
            : this() // => Constructor Principal
        {
            TipoOperacion = tipoOperacion;
            EntidadId = entidadId;

            RealizoAlgunaOperacion = false;
            // Agregar
            //AsignarImagenBotones();
        }

        public virtual void EjecutarComando()
        {
            switch (TipoOperacion)
            {
                case TipoOperacion.Nuevo:
                    if (EjecutarComandoNuevo())
                    {
                        MessageBox.Show(@"Los datos se Guardaron Correctamente.", @"Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Limpiar(this);
                        RealizoAlgunaOperacion = true;
                    }
                    break;
                case TipoOperacion.Eliminar:
                    if (EjecutarComandoEliminar())
                    {
                        MessageBox.Show(@"Los datos se Eliminaron Correctamente.", @"Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        RealizoAlgunaOperacion = true;
                        this.Close();
                    }
                    break;
                case TipoOperacion.Modificar:
                    if (EjecutarComandoModificar())
                    {
                        MessageBox.Show(@"Los datos se Modificaron Correctamente.", @"Atención", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        RealizoAlgunaOperacion = true;
                        this.Close();
                    }
                    break;
            }
        }

        public virtual bool EjecutarComandoModificar()
        {
            return false;
        }

        public virtual bool EjecutarComandoEliminar()
        {
            return false;
        }

        public virtual bool EjecutarComandoNuevo()
        {
            return false;
        }

        public virtual void CargarDatos(long? entidadId)
        {

        }

        public virtual void Inicializador(long? entidadId)
        {

        }

        private void FormularioAbm_Load_1(object sender, EventArgs e)
        {
            if (TipoOperacion == TipoOperacion.Eliminar
                || TipoOperacion == TipoOperacion.Modificar)
                CargarDatos(EntidadId);
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta seguro de Limpiar los Datos", @"Atención", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(this);
            }
        }

        private void btnEjecutar_Click_1(object sender, EventArgs e)
        {
            EjecutarComando();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
