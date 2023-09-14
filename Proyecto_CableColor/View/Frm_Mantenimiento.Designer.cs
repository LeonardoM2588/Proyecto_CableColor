
namespace Proyecto_CableColor.View
{
    partial class Frm_Mantenimiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Mantenimiento));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_registros = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbn_Empleado = new System.Windows.Forms.RadioButton();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.rbn_Nombre = new System.Windows.Forms.RadioButton();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_CancelarBusqueda = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Lbl_Registros = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_Celular = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Cmb_Empleado = new System.Windows.Forms.ComboBox();
            this.Cmb_Cliente = new System.Windows.Forms.ComboBox();
            this.Txt_CodMantenimiento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Txt_UsuarioLogeado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Dtp_FechaMantenimiento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.Btn_Nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Editar = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Cancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_Datos = new System.Windows.Forms.ToolStripMenuItem();
            this.correoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarPorPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarPorExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_minimizar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_registros)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_registros);
            this.groupBox3.Location = new System.Drawing.Point(393, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 130);
            this.groupBox3.TabIndex = 340;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Clientes";
            // 
            // dgv_registros
            // 
            this.dgv_registros.AllowUserToAddRows = false;
            this.dgv_registros.AllowUserToDeleteRows = false;
            this.dgv_registros.AllowUserToResizeColumns = false;
            this.dgv_registros.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_registros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_registros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_registros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgv_registros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_registros.Location = new System.Drawing.Point(6, 19);
            this.dgv_registros.Name = "dgv_registros";
            this.dgv_registros.RowHeadersWidth = 51;
            this.dgv_registros.Size = new System.Drawing.Size(518, 100);
            this.dgv_registros.TabIndex = 361;
            this.dgv_registros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_registros_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbn_Empleado);
            this.groupBox2.Controls.Add(this.txt_buscar);
            this.groupBox2.Controls.Add(this.dgv_Data);
            this.groupBox2.Controls.Add(this.rbn_Nombre);
            this.groupBox2.Controls.Add(this.Btn_Imprimir);
            this.groupBox2.Controls.Add(this.Btn_CancelarBusqueda);
            this.groupBox2.Controls.Add(this.Btn_Buscar);
            this.groupBox2.Location = new System.Drawing.Point(393, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 72);
            this.groupBox2.TabIndex = 339;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Cliente";
            // 
            // rbn_Empleado
            // 
            this.rbn_Empleado.AutoSize = true;
            this.rbn_Empleado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbn_Empleado.Location = new System.Drawing.Point(100, 22);
            this.rbn_Empleado.Name = "rbn_Empleado";
            this.rbn_Empleado.Size = new System.Drawing.Size(86, 20);
            this.rbn_Empleado.TabIndex = 332;
            this.rbn_Empleado.Text = "Empleado";
            this.rbn_Empleado.UseVisualStyleBackColor = true;
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(15, 44);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(365, 20);
            this.txt_buscar.TabIndex = 327;
            this.txt_buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged);
            // 
            // dgv_Data
            // 
            this.dgv_Data.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Enabled = false;
            this.dgv_Data.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgv_Data.Location = new System.Drawing.Point(513, 22);
            this.dgv_Data.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.RowHeadersWidth = 51;
            this.dgv_Data.RowTemplate.Height = 24;
            this.dgv_Data.Size = new System.Drawing.Size(10, 10);
            this.dgv_Data.TabIndex = 334;
            this.dgv_Data.Visible = false;
            // 
            // rbn_Nombre
            // 
            this.rbn_Nombre.AutoSize = true;
            this.rbn_Nombre.Checked = true;
            this.rbn_Nombre.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbn_Nombre.Location = new System.Drawing.Point(15, 21);
            this.rbn_Nombre.Name = "rbn_Nombre";
            this.rbn_Nombre.Size = new System.Drawing.Size(74, 20);
            this.rbn_Nombre.TabIndex = 331;
            this.rbn_Nombre.TabStop = true;
            this.rbn_Nombre.Text = "Nombre";
            this.rbn_Nombre.UseVisualStyleBackColor = true;
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Imprimir.Image")));
            this.Btn_Imprimir.Location = new System.Drawing.Point(486, 41);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(41, 23);
            this.Btn_Imprimir.TabIndex = 330;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Btn_CancelarBusqueda
            // 
            this.Btn_CancelarBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("Btn_CancelarBusqueda.Image")));
            this.Btn_CancelarBusqueda.Location = new System.Drawing.Point(436, 41);
            this.Btn_CancelarBusqueda.Name = "Btn_CancelarBusqueda";
            this.Btn_CancelarBusqueda.Size = new System.Drawing.Size(41, 23);
            this.Btn_CancelarBusqueda.TabIndex = 328;
            this.Btn_CancelarBusqueda.UseVisualStyleBackColor = true;
            this.Btn_CancelarBusqueda.Click += new System.EventHandler(this.Btn_CancelarBusqueda_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.Location = new System.Drawing.Point(386, 41);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(41, 23);
            this.Btn_Buscar.TabIndex = 329;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.Lbl_Registros});
            this.toolStrip1.Location = new System.Drawing.Point(0, 287);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(940, 25);
            this.toolStrip1.TabIndex = 338;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(123, 22);
            this.toolStripLabel1.Text = "Cantidad De Registros";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Lbl_Registros
            // 
            this.Lbl_Registros.Name = "Lbl_Registros";
            this.Lbl_Registros.Size = new System.Drawing.Size(13, 22);
            this.Lbl_Registros.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_Celular);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Cmb_Empleado);
            this.groupBox1.Controls.Add(this.Cmb_Cliente);
            this.groupBox1.Controls.Add(this.Txt_CodMantenimiento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.Dtp_FechaMantenimiento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 211);
            this.groupBox1.TabIndex = 337;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingresar Datos De Mantenimiento";
            // 
            // Txt_Celular
            // 
            this.Txt_Celular.Location = new System.Drawing.Point(116, 134);
            this.Txt_Celular.Mask = "0000-0000";
            this.Txt_Celular.Name = "Txt_Celular";
            this.Txt_Celular.Size = new System.Drawing.Size(72, 20);
            this.Txt_Celular.TabIndex = 374;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(41, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 373;
            this.label6.Text = "Telefono:";
            // 
            // Cmb_Empleado
            // 
            this.Cmb_Empleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Empleado.FormattingEnabled = true;
            this.Cmb_Empleado.Location = new System.Drawing.Point(116, 107);
            this.Cmb_Empleado.Name = "Cmb_Empleado";
            this.Cmb_Empleado.Size = new System.Drawing.Size(253, 21);
            this.Cmb_Empleado.TabIndex = 367;
            // 
            // Cmb_Cliente
            // 
            this.Cmb_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Cliente.FormattingEnabled = true;
            this.Cmb_Cliente.Location = new System.Drawing.Point(116, 54);
            this.Cmb_Cliente.Name = "Cmb_Cliente";
            this.Cmb_Cliente.Size = new System.Drawing.Size(253, 21);
            this.Cmb_Cliente.TabIndex = 335;
            // 
            // Txt_CodMantenimiento
            // 
            this.Txt_CodMantenimiento.Enabled = false;
            this.Txt_CodMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_CodMantenimiento.Location = new System.Drawing.Point(140, 28);
            this.Txt_CodMantenimiento.Name = "Txt_CodMantenimiento";
            this.Txt_CodMantenimiento.Size = new System.Drawing.Size(173, 20);
            this.Txt_CodMantenimiento.TabIndex = 331;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(38, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 365;
            this.label4.Text = "Empleado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(53, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 363;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 362;
            this.label2.Text = "Codigo Mantenimiento:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Txt_UsuarioLogeado);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(12, 160);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(363, 40);
            this.groupBox4.TabIndex = 331;
            this.groupBox4.TabStop = false;
            // 
            // Txt_UsuarioLogeado
            // 
            this.Txt_UsuarioLogeado.Enabled = false;
            this.Txt_UsuarioLogeado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_UsuarioLogeado.Location = new System.Drawing.Point(104, 14);
            this.Txt_UsuarioLogeado.Name = "Txt_UsuarioLogeado";
            this.Txt_UsuarioLogeado.Size = new System.Drawing.Size(80, 20);
            this.Txt_UsuarioLogeado.TabIndex = 336;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 335;
            this.label10.Text = "Usuarios Logeado:";
            // 
            // Dtp_FechaMantenimiento
            // 
            this.Dtp_FechaMantenimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FechaMantenimiento.Location = new System.Drawing.Point(116, 81);
            this.Dtp_FechaMantenimiento.Name = "Dtp_FechaMantenimiento";
            this.Dtp_FechaMantenimiento.Size = new System.Drawing.Size(96, 20);
            this.Dtp_FechaMantenimiento.TabIndex = 366;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(5, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 364;
            this.label3.Text = "Fecha Mantenimiento:";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_Nuevo,
            this.Btn_Guardar,
            this.Btn_Editar,
            this.Btn_Eliminar,
            this.Btn_Cancelar,
            this.Btn_Datos});
            this.menuStrip2.Location = new System.Drawing.Point(-1, 33);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(942, 32);
            this.menuStrip2.TabIndex = 336;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(54, 28);
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(61, 28);
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(49, 28);
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(62, 28);
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(65, 28);
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Datos
            // 
            this.Btn_Datos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.correoToolStripMenuItem,
            this.exportarPorPDFToolStripMenuItem,
            this.exportarPorExcelToolStripMenuItem});
            this.Btn_Datos.Name = "Btn_Datos";
            this.Btn_Datos.Size = new System.Drawing.Size(95, 28);
            this.Btn_Datos.Text = "Exportar Datos";
            // 
            // correoToolStripMenuItem
            // 
            this.correoToolStripMenuItem.Name = "correoToolStripMenuItem";
            this.correoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.correoToolStripMenuItem.Text = "Exportar Por Correo";
            this.correoToolStripMenuItem.Click += new System.EventHandler(this.correoToolStripMenuItem_Click);
            // 
            // exportarPorPDFToolStripMenuItem
            // 
            this.exportarPorPDFToolStripMenuItem.Name = "exportarPorPDFToolStripMenuItem";
            this.exportarPorPDFToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exportarPorPDFToolStripMenuItem.Text = "Exportar Por PDF";
            this.exportarPorPDFToolStripMenuItem.Click += new System.EventHandler(this.exportarPorPDFToolStripMenuItem_Click);
            // 
            // exportarPorExcelToolStripMenuItem
            // 
            this.exportarPorExcelToolStripMenuItem.Name = "exportarPorExcelToolStripMenuItem";
            this.exportarPorExcelToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exportarPorExcelToolStripMenuItem.Text = "Exportar Por Excel";
            this.exportarPorExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarPorExcelToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_minimizar);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 31);
            this.panel1.TabIndex = 335;
            // 
            // btn_close
            // 
            this.btn_close.AutoSize = true;
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.Location = new System.Drawing.Point(906, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(24, 24);
            this.btn_close.TabIndex = 294;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.AutoSize = true;
            this.btn_minimizar.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimizar.Image")));
            this.btn_minimizar.Location = new System.Drawing.Point(876, 4);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(24, 24);
            this.btn_minimizar.TabIndex = 295;
            this.btn_minimizar.UseVisualStyleBackColor = false;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(371, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Mantenimientos";
            // 
            // Frm_Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 312);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Mantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.Frm_Mantenimiento_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_registros)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_registros;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbn_Empleado;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.RadioButton rbn_Nombre;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Button Btn_CancelarBusqueda;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel Lbl_Registros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox Txt_Celular;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Cmb_Empleado;
        private System.Windows.Forms.ComboBox Cmb_Cliente;
        private System.Windows.Forms.TextBox Txt_CodMantenimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox Txt_UsuarioLogeado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.DateTimePicker Dtp_FechaMantenimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Btn_Nuevo;
        private System.Windows.Forms.ToolStripMenuItem Btn_Guardar;
        private System.Windows.Forms.ToolStripMenuItem Btn_Editar;
        private System.Windows.Forms.ToolStripMenuItem Btn_Eliminar;
        private System.Windows.Forms.ToolStripMenuItem Btn_Cancelar;
        private System.Windows.Forms.ToolStripMenuItem Btn_Datos;
        private System.Windows.Forms.ToolStripMenuItem correoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarPorPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarPorExcelToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_minimizar;
        private System.Windows.Forms.Label label8;
    }
}