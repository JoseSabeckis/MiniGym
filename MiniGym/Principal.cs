﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGym
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void consultaProvinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var provincia = new Provincia.ProvinciaConsulta();
            provincia.ShowDialog();
        }

        private void consultaLocalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var localidad = new Localidad.LocalidadConsulta();
            localidad.ShowDialog();
        }

        private void nuevaLocalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nuevo = new LocalidadCarpeta.LocalidadABM(Helpers.TipoOperacion.Nuevo);
            nuevo.ShowDialog();
        }

        private void nuevaProvinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nuevo = new ProvinciaCarpeta.ProvinciaABM(Helpers.TipoOperacion.Nuevo);
            nuevo.ShowDialog();
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir de la aplicacion?","Stop",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void consultaClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cliente = new PersonaCarpeta.PersonaConsulta();
            cliente.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nuevo = new PersonaCarpeta.PersonaABM(Helpers.TipoOperacion.Nuevo);
            nuevo.ShowDialog();
        }
    }
}
