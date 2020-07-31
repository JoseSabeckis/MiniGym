namespace MiniGym.Cuota
{
    partial class CobrarCuota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CobrarCuota));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblFinal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalCobrar = new System.Windows.Forms.TextBox();
            this.txtBusquedaCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdeudado = new System.Windows.Forms.TextBox();
            this.txtCobrado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gpbFacturas = new System.Windows.Forms.GroupBox();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.brnCobrar = new System.Windows.Forms.Button();
            this.txtNumeroCuota = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporteRecibido = new System.Windows.Forms.TextBox();
            this.txtImporteSeleccionado = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtPendientes = new System.Windows.Forms.TextBox();
            this.txtParciales = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCuotasImpagas = new System.Windows.Forms.TextBox();
            this.txtCuotasPagadas = new System.Windows.Forms.TextBox();
            this.txtCantCuotas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnNotas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gpbFacturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.lblFinal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 33);
            this.panel1.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Silver;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(714, 0);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(104, 27);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinal.Location = new System.Drawing.Point(268, 0);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(231, 25);
            this.lblFinal.TabIndex = 0;
            this.lblFinal.Text = "Cobrar Cuota a Clientes";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtTotalCobrar);
            this.panel2.Controls.Add(this.txtBusquedaCliente);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtAdeudado);
            this.panel2.Controls.Add(this.txtCobrado);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 69);
            this.panel2.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(416, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 59;
            this.label2.Text = "Cliente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 19);
            this.label12.TabIndex = 5;
            this.label12.Text = "Total Cobrar:";
            // 
            // txtTotalCobrar
            // 
            this.txtTotalCobrar.Enabled = false;
            this.txtTotalCobrar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCobrar.Location = new System.Drawing.Point(116, 3);
            this.txtTotalCobrar.Multiline = true;
            this.txtTotalCobrar.Name = "txtTotalCobrar";
            this.txtTotalCobrar.Size = new System.Drawing.Size(62, 20);
            this.txtTotalCobrar.TabIndex = 9;
            // 
            // txtBusquedaCliente
            // 
            this.txtBusquedaCliente.BackColor = System.Drawing.SystemColors.Info;
            this.txtBusquedaCliente.Enabled = false;
            this.txtBusquedaCliente.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusquedaCliente.Location = new System.Drawing.Point(420, 28);
            this.txtBusquedaCliente.Name = "txtBusquedaCliente";
            this.txtBusquedaCliente.Size = new System.Drawing.Size(389, 22);
            this.txtBusquedaCliente.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Adeudado:";
            // 
            // txtAdeudado
            // 
            this.txtAdeudado.Enabled = false;
            this.txtAdeudado.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdeudado.Location = new System.Drawing.Point(141, 43);
            this.txtAdeudado.Multiline = true;
            this.txtAdeudado.Name = "txtAdeudado";
            this.txtAdeudado.Size = new System.Drawing.Size(62, 20);
            this.txtAdeudado.TabIndex = 7;
            // 
            // txtCobrado
            // 
            this.txtCobrado.Enabled = false;
            this.txtCobrado.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCobrado.Location = new System.Drawing.Point(141, 23);
            this.txtCobrado.Multiline = true;
            this.txtCobrado.Name = "txtCobrado";
            this.txtCobrado.Size = new System.Drawing.Size(62, 20);
            this.txtCobrado.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Total Cobrado:";
            // 
            // gpbFacturas
            // 
            this.gpbFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFacturas.Controls.Add(this.dgvGrilla);
            this.gpbFacturas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpbFacturas.Location = new System.Drawing.Point(3, 108);
            this.gpbFacturas.Name = "gpbFacturas";
            this.gpbFacturas.Size = new System.Drawing.Size(820, 318);
            this.gpbFacturas.TabIndex = 64;
            this.gpbFacturas.TabStop = false;
            this.gpbFacturas.Text = "Cuotas";
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.Location = new System.Drawing.Point(3, 23);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(814, 292);
            this.dgvGrilla.TabIndex = 0;
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            this.dgvGrilla.DoubleClick += new System.EventHandler(this.dgvGrilla_DoubleClick);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.btnNotas);
            this.panel8.Controls.Add(this.brnCobrar);
            this.panel8.Controls.Add(this.txtNumeroCuota);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.txtSubtotal);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.txtImporteRecibido);
            this.panel8.Controls.Add(this.txtImporteSeleccionado);
            this.panel8.Location = new System.Drawing.Point(6, 441);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(544, 148);
            this.panel8.TabIndex = 65;
            // 
            // brnCobrar
            // 
            this.brnCobrar.BackColor = System.Drawing.Color.Lime;
            this.brnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnCobrar.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnCobrar.Location = new System.Drawing.Point(382, 88);
            this.brnCobrar.Name = "brnCobrar";
            this.brnCobrar.Size = new System.Drawing.Size(155, 55);
            this.brnCobrar.TabIndex = 67;
            this.brnCobrar.Text = "Cobrar";
            this.brnCobrar.UseVisualStyleBackColor = false;
            this.brnCobrar.Click += new System.EventHandler(this.brnCobrar_Click);
            // 
            // txtNumeroCuota
            // 
            this.txtNumeroCuota.Enabled = false;
            this.txtNumeroCuota.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroCuota.Location = new System.Drawing.Point(112, 46);
            this.txtNumeroCuota.Name = "txtNumeroCuota";
            this.txtNumeroCuota.Size = new System.Drawing.Size(68, 29);
            this.txtNumeroCuota.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Importe Seleccionado:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(186, 47);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(169, 27);
            this.txtSubtotal.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LawnGreen;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 45);
            this.label5.TabIndex = 2;
            this.label5.Text = "Importe Recibido:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nro. Cuota:";
            // 
            // txtImporteRecibido
            // 
            this.txtImporteRecibido.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteRecibido.Location = new System.Drawing.Point(186, 96);
            this.txtImporteRecibido.Multiline = true;
            this.txtImporteRecibido.Name = "txtImporteRecibido";
            this.txtImporteRecibido.Size = new System.Drawing.Size(169, 45);
            this.txtImporteRecibido.TabIndex = 0;
            this.txtImporteRecibido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteRecibido_KeyPress);
            // 
            // txtImporteSeleccionado
            // 
            this.txtImporteSeleccionado.BackColor = System.Drawing.SystemColors.Info;
            this.txtImporteSeleccionado.Enabled = false;
            this.txtImporteSeleccionado.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteSeleccionado.Location = new System.Drawing.Point(186, 9);
            this.txtImporteSeleccionado.Name = "txtImporteSeleccionado";
            this.txtImporteSeleccionado.Size = new System.Drawing.Size(169, 27);
            this.txtImporteSeleccionado.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkGray;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.txtPendientes);
            this.panel6.Controls.Add(this.txtParciales);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.txtCuotasImpagas);
            this.panel6.Controls.Add(this.txtCuotasPagadas);
            this.panel6.Controls.Add(this.txtCantCuotas);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(556, 441);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(264, 148);
            this.panel6.TabIndex = 66;
            // 
            // txtPendientes
            // 
            this.txtPendientes.Enabled = false;
            this.txtPendientes.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPendientes.Location = new System.Drawing.Point(195, 108);
            this.txtPendientes.Multiline = true;
            this.txtPendientes.Name = "txtPendientes";
            this.txtPendientes.Size = new System.Drawing.Size(62, 22);
            this.txtPendientes.TabIndex = 15;
            // 
            // txtParciales
            // 
            this.txtParciales.Enabled = false;
            this.txtParciales.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParciales.Location = new System.Drawing.Point(195, 88);
            this.txtParciales.Multiline = true;
            this.txtParciales.Name = "txtParciales";
            this.txtParciales.Size = new System.Drawing.Size(62, 20);
            this.txtParciales.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(4, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "Cant. Cuotas Pendientes:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(171, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "Cant. Cuotas Parciales:";
            // 
            // txtCuotasImpagas
            // 
            this.txtCuotasImpagas.Enabled = false;
            this.txtCuotasImpagas.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuotasImpagas.Location = new System.Drawing.Point(195, 53);
            this.txtCuotasImpagas.Multiline = true;
            this.txtCuotasImpagas.Name = "txtCuotasImpagas";
            this.txtCuotasImpagas.Size = new System.Drawing.Size(62, 20);
            this.txtCuotasImpagas.TabIndex = 11;
            // 
            // txtCuotasPagadas
            // 
            this.txtCuotasPagadas.Enabled = false;
            this.txtCuotasPagadas.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuotasPagadas.Location = new System.Drawing.Point(195, 33);
            this.txtCuotasPagadas.Multiline = true;
            this.txtCuotasPagadas.Name = "txtCuotasPagadas";
            this.txtCuotasPagadas.Size = new System.Drawing.Size(62, 20);
            this.txtCuotasPagadas.TabIndex = 10;
            // 
            // txtCantCuotas
            // 
            this.txtCantCuotas.Enabled = false;
            this.txtCantCuotas.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantCuotas.Location = new System.Drawing.Point(111, 7);
            this.txtCantCuotas.Multiline = true;
            this.txtCantCuotas.Name = "txtCantCuotas";
            this.txtCantCuotas.Size = new System.Drawing.Size(62, 20);
            this.txtCantCuotas.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Cant. Cuotas Impagas:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Cant. Cuotas Pagas:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Cant. Cuotas:";
            // 
            // btnNotas
            // 
            this.btnNotas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNotas.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotas.Location = new System.Drawing.Point(414, 12);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(79, 44);
            this.btnNotas.TabIndex = 68;
            this.btnNotas.Text = "Notas";
            this.btnNotas.UseVisualStyleBackColor = false;
            this.btnNotas.Click += new System.EventHandler(this.btnNotas_Click);
            // 
            // CobrarCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(823, 595);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.gpbFacturas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CobrarCuota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CobrarCuota";
            this.Load += new System.EventHandler(this.CobrarCuota_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gpbFacturas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalCobrar;
        private System.Windows.Forms.TextBox txtBusquedaCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAdeudado;
        private System.Windows.Forms.TextBox txtCobrado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gpbFacturas;
        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button brnCobrar;
        private System.Windows.Forms.TextBox txtNumeroCuota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImporteRecibido;
        private System.Windows.Forms.TextBox txtImporteSeleccionado;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtPendientes;
        private System.Windows.Forms.TextBox txtParciales;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCuotasImpagas;
        private System.Windows.Forms.TextBox txtCuotasPagadas;
        private System.Windows.Forms.TextBox txtCantCuotas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNotas;
    }
}