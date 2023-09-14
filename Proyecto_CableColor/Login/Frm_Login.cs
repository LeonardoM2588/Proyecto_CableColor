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
    public partial class Frm_Login : Form
    {

        Control_System.Helpers H = new Control_System.Helpers();
        Control_System.DataBase D = new Control_System.DataBase();
        Control_System.DataUser U = new Control_System.DataUser();

        int errors, IdEmpleado, idniveluser;
        string username, password;

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public Frm_Login()
        {
            InitializeComponent();
        }

        //Boton De Cierre
        private void btn_close_Click(object sender, EventArgs e)
        {
            if (H.MsgQuestion("¿Desea Cerrar el Programa?") == "S")
            {
                Application.Exit();
            }
        }

        private void txt_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txt_contraseña.Focus();
            }
        }

        private void txt_contraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_acceder.PerformClick();
            }
        }

        private void txt_contraseña_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txt_user.Focus();
            }
        }

        private void link_cambioclave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (H.MsgQuestion("Solo un usuario Administrador puede modificar tu contraseña, ¿Deseas Continuar?") == "S")
            {
                Frm_Confirmacion Confirmacion = new Frm_Confirmacion();
                Confirmacion.ShowDialog();
            }
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            txt_user.Select();
        }

        private new void Validate()
        {

            if (txt_user.Text.Trim().Length == 0)
            {
                H.MsgWarning("Ingresar un usuario");
                txt_user.Focus();
                errors++;
                return;
            }
            if (txt_contraseña.Text.Trim().Length == 0)
            {
                H.MsgWarning("Ingrese Una Contraseña Valida");
                txt_contraseña.Focus();
                errors++;
                return;
            }
        }

        private void user()
        {

            DataTable Busqueda = new DataTable();
            Busqueda = D.Find("Nivel_Acceso", "*", "IdNivelUser='" + idniveluser + "'");

            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (idniveluser == int.Parse(DATOS["IdNivelUser"].ToString()))
                {
                    Control_System.DataUser.ROLE = DATOS["Nivel_Acceso"].ToString();
                }
            }

            Busqueda = D.Find("Empleados", "*", "Cod_Empleado='" + IdEmpleado + "'");
            if (Busqueda.Rows.Count > 0)
            {
                DataRow DATOS = Busqueda.Rows[0];
                if (IdEmpleado == int.Parse(DATOS["Cod_Empleado"].ToString()))
                {
                    Control_System.DataUser.REALNAMEUSER = DATOS["Nombre_Empleado"].ToString();
                }
            }

        }
        private void btn_acceder_Click(object sender, EventArgs e)
        {
            Validate();
            Enter();
        }

        private void ClearForm()
        {
            txt_user.Clear();
            txt_contraseña.Clear();
            txt_user.Select();
        }

        private new void Enter()
        {
            username = H.SanitizeStr(txt_user.Text.Trim());
            password = H.SanitizeStr(txt_contraseña.Text.Trim());

            DataTable Usuario = new DataTable();
            Usuario = D.Find("Usuarios", "*", "Usuario='" + username + "'");

            if (Usuario.Rows.Count > 0)
            {
                DataRow INFOUSUARIO = Usuario.Rows[0];
                if (username == INFOUSUARIO["Usuario"].ToString() && U.MakeHash(password) == INFOUSUARIO["Contrasena"].ToString())
                {
                    H.MsgSuccess("BIENVENID@ " + username);
                    //REGISTRO DE INFORMACION
                    Control_System.DataUser.ID = int.Parse(INFOUSUARIO["Cod_Usuario"].ToString());
                    idniveluser = int.Parse(INFOUSUARIO["IdNivelUser"].ToString());
                    IdEmpleado = int.Parse(INFOUSUARIO["Cod_Empleado"].ToString());
                    Control_System.DataUser.IDEMPLEADO = int.Parse(INFOUSUARIO["Cod_Empleado"].ToString());
                    Control_System.DataUser.USERNAME = username;
                    user();
                    //NOS VAMOS AL FORMULARIO PRINCIPAL
                    View.Frm_Panel biblioteca = new View.Frm_Panel();
                    this.Hide();
                    biblioteca.ShowDialog();
                }
                else
                {
                    H.MsgWarning("CREDENCIALES INVALIDAS,CONTACTAR ADMINISTRADOR!");
                    ClearForm();
                }
            }
            else
            {
                H.MsgWarning("USUARIO NO EXISTE");
                ClearForm();
            }

            Usuario.Dispose();
        }
       
    }
}
