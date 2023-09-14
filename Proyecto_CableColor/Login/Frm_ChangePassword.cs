using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto_CableColor.Login
{
    public partial class Frm_ChangePassword : Form
    {

        Control_System.Helpers H = new Control_System.Helpers();
        Control_System.DataBase D = new Control_System.DataBase();
        Control_System.DataUser U = new Control_System.DataUser();

        int errors;
        string name, password, confirmate;

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Frm_ChangePassword()
        {
            InitializeComponent();
        }

        private void txt_nombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txt_contraseña.Focus();
            }
        }

        private void txt_contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txt_confirmacion.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txt_nombre.Focus();
            }
        }

        private void txt_confirmacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txt_contraseña.Focus();
            }
        }

        private new void Validate()
        {

            if (txt_nombre.Text.Trim().Length == 0)
            {
                H.MsgWarning("Ingresar un usuario!");
                txt_nombre.Focus();
                errors++;
                return;
            }
            if (txt_contraseña.Text.Trim().Length == 0)
            {
                H.MsgWarning("Ingrese Una Contraseña Valida!");
                txt_contraseña.Focus();
                errors++;
                return;
            }
            if (txt_confirmacion.Text.Trim().Length == 0)
            {
                H.MsgWarning("Ingrese La Confirmacion De La Contraseña!");
                txt_confirmacion.Focus();
                errors++;
                return;
            }
        }

        private void link_confirmar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Validate();
            Enter();
        }

        private void Frm_ChangePassword_Load(object sender, EventArgs e)
        {
            txt_nombre.Select();
        }

        private new void Enter()
        {

            name = H.SanitizeStr(txt_nombre.Text);
            password = U.MakeHash(txt_contraseña.Text);
            confirmate = H.SanitizeStr(txt_confirmacion.Text);

            DataTable Busqueda = new DataTable();
            Busqueda = D.Find("Usuarios", "*", "Usuario='" + name + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (name == DATOS["Usuario"].ToString() && password.Trim().Length > 0 && confirmate.Trim().Length > 0)
                {
                    string data = "Contrasena ='" + password + "'";
                    string condition = "Usuario='" + name + "'";
                    if (D.Update("Usuarios", data, condition) > 0)
                    {
                        H.MsgSuccess("Contraseña Actualizada. Pase Feliz Tarde :)!");
                        Close();
                    }
                }
            }
            else
            {
                H.MsgWarning("Nombre De Usuario Inexistente!");
            }

        }
    }
}
