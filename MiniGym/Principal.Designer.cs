namespace MiniGym
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provinciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaProvinciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaProvinciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaLocalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaLocalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblhora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.morososToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMorososToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMorosos = new System.Windows.Forms.Button();
            this.btnVerPlanes = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnVerClientes = new System.Windows.Forms.Button();
            this.btnEntrenadores = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.sistemaToolStripMenuItem,
            this.configuracionToolStripMenuItem,
            this.planesToolStripMenuItem,
            this.morososToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaClientesToolStripMenuItem,
            this.nuevoClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // consultaClientesToolStripMenuItem
            // 
            this.consultaClientesToolStripMenuItem.Name = "consultaClientesToolStripMenuItem";
            this.consultaClientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.consultaClientesToolStripMenuItem.Text = "Consulta Clientes";
            this.consultaClientesToolStripMenuItem.Click += new System.EventHandler(this.consultaClientesToolStripMenuItem_Click);
            // 
            // nuevoClienteToolStripMenuItem
            // 
            this.nuevoClienteToolStripMenuItem.Name = "nuevoClienteToolStripMenuItem";
            this.nuevoClienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevoClienteToolStripMenuItem.Text = "Nuevo Cliente";
            this.nuevoClienteToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.provinciaToolStripMenuItem,
            this.localidadToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // provinciaToolStripMenuItem
            // 
            this.provinciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaProvinciasToolStripMenuItem,
            this.nuevaProvinciaToolStripMenuItem});
            this.provinciaToolStripMenuItem.Name = "provinciaToolStripMenuItem";
            this.provinciaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.provinciaToolStripMenuItem.Text = "Provincia";
            // 
            // consultaProvinciasToolStripMenuItem
            // 
            this.consultaProvinciasToolStripMenuItem.Name = "consultaProvinciasToolStripMenuItem";
            this.consultaProvinciasToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.consultaProvinciasToolStripMenuItem.Text = "Consulta Provincias";
            this.consultaProvinciasToolStripMenuItem.Click += new System.EventHandler(this.consultaProvinciasToolStripMenuItem_Click);
            // 
            // nuevaProvinciaToolStripMenuItem
            // 
            this.nuevaProvinciaToolStripMenuItem.Name = "nuevaProvinciaToolStripMenuItem";
            this.nuevaProvinciaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.nuevaProvinciaToolStripMenuItem.Text = "Nueva Provincia";
            this.nuevaProvinciaToolStripMenuItem.Click += new System.EventHandler(this.nuevaProvinciaToolStripMenuItem_Click);
            // 
            // localidadToolStripMenuItem
            // 
            this.localidadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaLocalidadToolStripMenuItem,
            this.nuevaLocalidadToolStripMenuItem});
            this.localidadToolStripMenuItem.Name = "localidadToolStripMenuItem";
            this.localidadToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.localidadToolStripMenuItem.Text = "Localidad";
            // 
            // consultaLocalidadToolStripMenuItem
            // 
            this.consultaLocalidadToolStripMenuItem.Name = "consultaLocalidadToolStripMenuItem";
            this.consultaLocalidadToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.consultaLocalidadToolStripMenuItem.Text = "Consulta Localidad";
            this.consultaLocalidadToolStripMenuItem.Click += new System.EventHandler(this.consultaLocalidadToolStripMenuItem_Click);
            // 
            // nuevaLocalidadToolStripMenuItem
            // 
            this.nuevaLocalidadToolStripMenuItem.Name = "nuevaLocalidadToolStripMenuItem";
            this.nuevaLocalidadToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.nuevaLocalidadToolStripMenuItem.Text = "Nueva Localidad";
            this.nuevaLocalidadToolStripMenuItem.Click += new System.EventHandler(this.nuevaLocalidadToolStripMenuItem_Click);
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPlanesToolStripMenuItem,
            this.nuevoPlanToolStripMenuItem});
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.planesToolStripMenuItem.Text = "Planes";
            // 
            // verPlanesToolStripMenuItem
            // 
            this.verPlanesToolStripMenuItem.Name = "verPlanesToolStripMenuItem";
            this.verPlanesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.verPlanesToolStripMenuItem.Text = "Ver Planes";
            this.verPlanesToolStripMenuItem.Click += new System.EventHandler(this.verPlanesToolStripMenuItem_Click);
            // 
            // nuevoPlanToolStripMenuItem
            // 
            this.nuevoPlanToolStripMenuItem.Name = "nuevoPlanToolStripMenuItem";
            this.nuevoPlanToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.nuevoPlanToolStripMenuItem.Text = "Nuevo Plan";
            this.nuevoPlanToolStripMenuItem.Click += new System.EventHandler(this.nuevoPlanToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 394);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnEntrenadores);
            this.panel3.Controls.Add(this.btnVerClientes);
            this.panel3.Controls.Add(this.btnNuevoCliente);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 390);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNuevo);
            this.panel2.Controls.Add(this.btnVerPlanes);
            this.panel2.Controls.Add(this.btnMorosos);
            this.panel2.Controls.Add(this.lblFecha);
            this.panel2.Controls.Add(this.lblhora);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(372, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 390);
            this.panel2.TabIndex = 0;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Red;
            this.lblFecha.Location = new System.Drawing.Point(3, 315);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(418, 33);
            this.lblFecha.TabIndex = 42;
            this.lblFecha.Text = "Miercoles, 10  noviembre  2017";
            // 
            // lblhora
            // 
            this.lblhora.AutoSize = true;
            this.lblhora.BackColor = System.Drawing.Color.Transparent;
            this.lblhora.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblhora.Location = new System.Drawing.Point(3, 348);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(119, 33);
            this.lblhora.TabIndex = 41;
            this.lblhora.Text = "10:59:58";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // morososToolStripMenuItem
            // 
            this.morososToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verMorososToolStripMenuItem});
            this.morososToolStripMenuItem.Name = "morososToolStripMenuItem";
            this.morososToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.morososToolStripMenuItem.Text = "Morosos";
            // 
            // verMorososToolStripMenuItem
            // 
            this.verMorososToolStripMenuItem.Name = "verMorososToolStripMenuItem";
            this.verMorososToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verMorososToolStripMenuItem.Text = "Ver Morosos";
            this.verMorososToolStripMenuItem.Click += new System.EventHandler(this.verMorososToolStripMenuItem_Click);
            // 
            // btnMorosos
            // 
            this.btnMorosos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMorosos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMorosos.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMorosos.Location = new System.Drawing.Point(202, 57);
            this.btnMorosos.Name = "btnMorosos";
            this.btnMorosos.Size = new System.Drawing.Size(193, 46);
            this.btnMorosos.TabIndex = 43;
            this.btnMorosos.Text = "Clientes Con Deudas";
            this.btnMorosos.UseVisualStyleBackColor = false;
            this.btnMorosos.Click += new System.EventHandler(this.btnMorosos_Click);
            // 
            // btnVerPlanes
            // 
            this.btnVerPlanes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnVerPlanes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerPlanes.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerPlanes.Location = new System.Drawing.Point(202, 141);
            this.btnVerPlanes.Name = "btnVerPlanes";
            this.btnVerPlanes.Size = new System.Drawing.Size(193, 46);
            this.btnVerPlanes.TabIndex = 44;
            this.btnVerPlanes.Text = "Ver Planes";
            this.btnVerPlanes.UseVisualStyleBackColor = false;
            this.btnVerPlanes.Click += new System.EventHandler(this.btnVerPlanes_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(202, 221);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(193, 46);
            this.btnNuevo.TabIndex = 45;
            this.btnNuevo.Text = "Nuevo Plan";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCliente.Location = new System.Drawing.Point(31, 221);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(193, 46);
            this.btnNuevoCliente.TabIndex = 44;
            this.btnNuevoCliente.Text = "Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = false;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnVerClientes
            // 
            this.btnVerClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnVerClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerClientes.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerClientes.Location = new System.Drawing.Point(31, 141);
            this.btnVerClientes.Name = "btnVerClientes";
            this.btnVerClientes.Size = new System.Drawing.Size(193, 46);
            this.btnVerClientes.TabIndex = 45;
            this.btnVerClientes.Text = "Ver Clientes";
            this.btnVerClientes.UseVisualStyleBackColor = false;
            this.btnVerClientes.Click += new System.EventHandler(this.btnVerClientes_Click);
            // 
            // btnEntrenadores
            // 
            this.btnEntrenadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEntrenadores.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrenadores.Location = new System.Drawing.Point(31, 57);
            this.btnEntrenadores.Name = "btnEntrenadores";
            this.btnEntrenadores.Size = new System.Drawing.Size(193, 46);
            this.btnEntrenadores.TabIndex = 46;
            this.btnEntrenadores.Text = "Entrenadores";
            this.btnEntrenadores.UseVisualStyleBackColor = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::MiniGym.Properties.Resources.the_gym_948;
            this.ClientSize = new System.Drawing.Size(795, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(811, 457);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(811, 457);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provinciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem consultaProvinciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaProvinciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaLocalidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaLocalidadToolStripMenuItem;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPlanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morososToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMorososToolStripMenuItem;
        private System.Windows.Forms.Button btnMorosos;
        private System.Windows.Forms.Button btnVerPlanes;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnVerClientes;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnEntrenadores;
    }
}

