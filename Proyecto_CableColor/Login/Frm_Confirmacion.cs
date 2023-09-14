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
    public partial class Frm_Confirmacion : Form
    {
        Control_System.Helpers H = new Control_System.Helpers();
        Control_System.DataBase D = new Control_System.DataBase();
        Control_System.DataUser U = new Control_System.DataUser();

        int errors;
        string username, password;

        public Frm_Confirmacion()
        {
            InitializeComponent();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void link_siguiente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Verificacion();
            Enter();
        }

        private void Verificacion()
        {
            if (txt_username.Text.Trim().Length == 0)
            {
                H.MsgWarning("Ingresar un usuario!");
                txt_username.Focus();
                errors++;
                return;
            }
            if (txt_password.Text.Trim().Length == 0)
            {
                H.MsgWarning("Ingrese Un Password Valido!");
                txt_username.Focus();
                errors++;
                return;
            }
            H.SanitizeStr(txt_username.Text.Trim());
        }
        private new void Enter()
        {
            username = H.SanitizeStr(txt_username.Text.Trim());
            password = U.MakeHash(txt_password.Text.Trim());

            DataTable Usuario = new DataTable();
            Usuario = D.Find("Usuarios", "*", "IdNivelUser='1'");
            if (Usuario.Rows.Count > 0)
            {
                DataRow INFOUSUARIO = Usuario.Rows[0];
                if (username == INFOUSUARIO["Usuario"].ToString() && password == INFOUSUARIO["Contrasena"].ToString() && INFOUSUARIO["IdNivelUser"].ToString() == "1")
                {
                        H.MsgSuccess("Bienvenido: " + username + " Un Usuario Le Solicito Un Cambio De Contraseña :)!");
                        Frm_ChangePassword ChangePassword = new Frm_ChangePassword();
                        this.Hide();
                        ChangePassword.ShowDialog();
                   
                }
                else
                {
                    H.MsgWarning("CREDENCIALES INVALIDAS,CONTACTAR ADMINISTRADOR!");
                }
                ClearForm();
            }
            else
            {
                H.MsgWarning("USUARIO NO EXISTE");

            }
            ClearForm();
            Usuario.Dispose();
        }

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txt_password.Focus();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txt_username.Focus();
            }
        }

        private void Frm_Confirmacion_Load(object sender, EventArgs e)
        {
            txt_username.Select();
        }

        private void ClearForm()
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_username.Select();
        }
    }
}
