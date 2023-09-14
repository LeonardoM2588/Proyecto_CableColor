using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_CableColor.Control_System;


namespace Proyecto_CableColor.View
{
    public partial class Frm_Panel : Form
    {
        Control_System.Helpers H = new Control_System.Helpers();
        Control_System.DataBase D = new Control_System.DataBase();
        Control_System.DataUser U = new Control_System.DataUser();

        public Frm_Panel()
        {
            InitializeComponent();
        }

        private void Cargar()
        {
            lbluserlogin.Text = Control_System.DataUser.REALNAMEUSER + " | ";
            lblfecha.Text = DateTime.Now.ToLongDateString().ToUpper() + " | ";
            lblusermanager.Text = Control_System.DataUser.ROLE;
            lbluser.Text = Control_System.DataUser.USERNAME;

            switch (Control_System.DataUser.ROLE)
            {
                case "Administrador":
                    Btn_Clientes.Enabled = true;
                    Btn_Configuracion.Enabled = false;
                    Btn_Empleados.Enabled = true;
                    Btn_Marketing.Enabled = true;
                    break;

                case "Programador":
                    Btn_Clientes.Enabled = true;
                    Btn_Configuracion.Enabled = true;
                    Btn_Empleados.Enabled = true;
                    Btn_Marketing.Enabled = true;
                    break;

                case "IT":
                    Btn_Clientes.Enabled = true;
                    Btn_Configuracion.Enabled = false;
                    Btn_Empleados.Enabled = true;
                    Btn_Marketing.Enabled = false;
                    break;

                case "Supervisor Residencial":
                    Btn_Clientes.Enabled = true;
                    Btn_Configuracion.Enabled = false;
                    Btn_Empleados.Enabled = true;
                    Btn_Marketing.Enabled = false;
                    break;

                case "Gerente":
                    Btn_Clientes.Enabled = true;
                    Btn_Configuracion.Enabled = false;
                    Btn_Empleados.Enabled = true;
                    Btn_Marketing.Enabled = true;
                    break;

                case "Vendedor":
                    Btn_Clientes.Enabled = true;
                    Btn_Configuracion.Enabled = false;
                    Btn_Empleados.Enabled = false;
                    Btn_Marketing.Enabled = false;
                    break;
            }

        }

        private void Frm_Panel_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Cerrar La Sesion Actual?") == "S")
            {
                Login.Frm_Login Login = new Login.Frm_Login();
                this.Hide();
                Login.ShowDialog();
            }
        }

        private void Btn_Clientes_Click(object sender, EventArgs e)
        {
            View.Frm_Adicionales Adicionales = new Frm_Adicionales();
            DataUser.Contador = 1;
            this.Hide();
            Adicionales.ShowDialog();
        }

        private void Btn_Empleados_Click(object sender, EventArgs e)
        {
            View.Frm_Adicionales Adicionales = new Frm_Adicionales();
            DataUser.Contador = 2;
            this.Hide();
            Adicionales.ShowDialog();
        }

        private void Btn_Marketing_Click(object sender, EventArgs e)
        {
            View.Frm_Adicionales Adicionales = new Frm_Adicionales();
            DataUser.Contador = 3;
            this.Hide();
            Adicionales.ShowDialog();
        }

        private void Btn_Configuracion_Click(object sender, EventArgs e)
        {
            View.Frm_Adicionales Adicionales = new Frm_Adicionales();
            DataUser.Contador = 4;
            this.Hide();
            Adicionales.ShowDialog();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
