
namespace Proyecto_CableColor.Login
{
    partial class Frm_ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ChangePassword));
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.link_confirmar = new System.Windows.Forms.LinkLabel();
            this.txt_contraseña = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_confirmacion = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_minimizar = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_nombre
            // 
            this.txt_nombre.BackColor = System.Drawing.Color.White;
            this.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nombre.ForeColor = System.Drawing.Color.DimGray;
            this.txt_nombre.Location = new System.Drawing.Point(52, 90);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(311, 20);
            this.txt_nombre.TabIndex = 57;
            this.txt_nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_nombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_nombre_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(71, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 22);
            this.label4.TabIndex = 56;
            this.label4.Text = "Ingrese el nombre de usuario";
            // 
            // link_confirmar
            // 
            this.link_confirmar.AutoSize = true;
            this.link_confirmar.LinkColor = System.Drawing.Color.White;
            this.link_confirmar.Location = new System.Drawing.Point(341, 270);
            this.link_confirmar.Name = "link_confirmar";
            this.link_confirmar.Size = new System.Drawing.Size(51, 13);
            this.link_confirmar.TabIndex = 55;
            this.link_confirmar.TabStop = true;
            this.link_confirmar.Text = "Confirmar";
            this.link_confirmar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_confirmar_LinkClicked);
            // 
            // txt_contraseña
            // 
            this.txt_contraseña.BackColor = System.Drawing.Color.White;
            this.txt_contraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_contraseña.ForeColor = System.Drawing.Color.DimGray;
            this.txt_contraseña.Location = new System.Drawing.Point(52, 158);
            this.txt_contraseña.Name = "txt_contraseña";
            this.txt_contraseña.Size = new System.Drawing.Size(311, 20);
            this.txt_contraseña.TabIndex = 54;
            this.txt_contraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_contraseña.UseSystemPasswordChar = true;
            this.txt_contraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_contraseña_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 22);
            this.label2.TabIndex = 53;
            this.label2.Text = "Ingrese la nueva contraseña";
            // 
            // txt_confirmacion
            // 
            this.txt_confirmacion.BackColor = System.Drawing.Color.White;
            this.txt_confirmacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_confirmacion.ForeColor = System.Drawing.Color.DimGray;
            this.txt_confirmacion.Location = new System.Drawing.Point(52, 225);
            this.txt_confirmacion.Name = "txt_confirmacion";
            this.txt_confirmacion.Size = new System.Drawing.Size(311, 20);
            this.txt_confirmacion.TabIndex = 52;
            this.txt_confirmacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_confirmacion.UseSystemPasswordChar = true;
            this.txt_confirmacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_confirmacion_KeyDown);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(71, 189);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(292, 22);
            this.Label1.TabIndex = 51;
            this.Label1.Text = "Confirme la nueva contraseña";
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.AutoSize = true;
            this.btn_minimizar.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimizar.Image")));
            this.btn_minimizar.Location = new System.Drawing.Point(339, 15);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(24, 24);
            this.btn_minimizar.TabIndex = 50;
            this.btn_minimizar.UseVisualStyleBackColor = false;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // btn_close
            // 
            this.btn_close.AutoSize = true;
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.Location = new System.Drawing.Point(369, 15);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(24, 24);
            this.btn_close.TabIndex = 49;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(140, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 48;
            this.label3.Text = "Cable Color";
            // 
            // Frm_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(412, 300);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.link_confirmar);
            this.Controls.Add(this.txt_contraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_confirmacion);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btn_minimizar);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio De Contraseña";
            this.Load += new System.EventHandler(this.Frm_ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel link_confirmar;
        private System.Windows.Forms.TextBox txt_contraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_confirmacion;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btn_minimizar;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label3;
    }
}