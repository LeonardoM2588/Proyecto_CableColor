using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_CableColor.View
{
    public partial class Frm_Adicionales : Form
    {
        public Frm_Adicionales()
        {
            InitializeComponent();
        }
        private void StarForm() {


            if (Control_System.DataUser.Contador == 1)
            {
                //Datos De Configuracion
                Btn_Pais.Enabled = false;
                Btn_Usuarios.Enabled = false;
                Btn_Departamentos.Enabled = false;
                Btn_Generos.Enabled = false;

                //Marketing
                Btn_Paquetes.Enabled = false;
                Btn_TiposPaquetes.Enabled = false;

                //Empleados
                Btn_Empleados.Enabled = false;
                Btn_Turnos.Enabled = false;

                //Clientes
                Btn_Clientes.Enabled = true;
                Btn_ClientesProspectos.Enabled = true;
                Btn_OrdenInstalacion.Enabled = true;
                Btn_OrdenesMantenimiento.Enabled = true;
            }
            else if (Control_System.DataUser.Contador == 2)
            {
                //Datos De Configuracion
                Btn_Pais.Enabled = false;
                Btn_Usuarios.Enabled = false;
                Btn_Departamentos.Enabled = false;
                Btn_Generos.Enabled = false;

                //Marketing
                Btn_Paquetes.Enabled = false;
                Btn_TiposPaquetes.Enabled = false;

                //Empleados
                Btn_Empleados.Enabled = true;
                Btn_Turnos.Enabled = true;

                //Clientes
                Btn_Clientes.Enabled = false;
                Btn_ClientesProspectos.Enabled = false;
                Btn_OrdenInstalacion.Enabled = false;
                Btn_OrdenesMantenimiento.Enabled = false;
            }
            else if (Control_System.DataUser.Contador == 3)
            {
                //Datos De Configuracion
                Btn_Pais.Enabled = false;
                Btn_Usuarios.Enabled = false;
                Btn_Departamentos.Enabled = false;
                Btn_Generos.Enabled = false;

                //Marketing
                Btn_Paquetes.Enabled = true;
                Btn_TiposPaquetes.Enabled = true;

                //Empleados
                Btn_Empleados.Enabled = false;
                Btn_Turnos.Enabled = false;

                //Clientes
                Btn_Clientes.Enabled = false;
                Btn_ClientesProspectos.Enabled = false;
                Btn_OrdenInstalacion.Enabled = false;
                Btn_OrdenesMantenimiento.Enabled = false;
            }
            else if (Control_System.DataUser.Contador == 4)
            {
                //Datos De Configuracion
                Btn_Pais.Enabled = true;
                Btn_Usuarios.Enabled = true;
                Btn_Departamentos.Enabled = true;
                Btn_Generos.Enabled = true;

                //Marketing
                Btn_Paquetes.Enabled = false;
                Btn_TiposPaquetes.Enabled = false;

                //Empleados
                Btn_Empleados.Enabled = false;
                Btn_Turnos.Enabled = false;

                //Clientes
                Btn_Clientes.Enabled = false;
                Btn_ClientesProspectos.Enabled = false;
                Btn_OrdenInstalacion.Enabled = false;
                Btn_OrdenesMantenimiento.Enabled = false;
            }

            else if (Control_System.DataUser.ROLE == "Gerente")
            {
                //Datos De Configuracion
                Btn_Pais.Enabled = true;
                Btn_Usuarios.Enabled = true;
                Btn_Departamentos.Enabled = true;
                Btn_Generos.Enabled = true;

                //Marketing
                Btn_Paquetes.Enabled = true;
                Btn_TiposPaquetes.Enabled = true;

                //Empleados
                Btn_Empleados.Enabled = true;
                Btn_Turnos.Enabled = true;

                //Clientes
                Btn_Clientes.Enabled = true;
                Btn_ClientesProspectos.Enabled = true;
                Btn_OrdenInstalacion.Enabled = true;
                Btn_OrdenesMantenimiento.Enabled = true;
            }

            else if (Control_System.DataUser.ROLE == "Vendedor")
            {
                //Datos De Configuracion
                Btn_Pais.Enabled = false;
                Btn_Usuarios.Enabled = false;
                Btn_Departamentos.Enabled = false;
                Btn_Generos.Enabled = false;

                //Marketing
                Btn_Paquetes.Enabled = false;
                Btn_TiposPaquetes.Enabled = false;

                //Empleados
                Btn_Empleados.Enabled = false;
                Btn_Turnos.Enabled = false;

                //Clientes
                Btn_Clientes.Enabled = true;
                Btn_ClientesProspectos.Enabled = true;
                Btn_OrdenInstalacion.Enabled = true;
                Btn_OrdenesMantenimiento.Enabled = true;
            }

        }

        private void Frm_Adicionales_Load(object sender, EventArgs e)
        {
            StarForm();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Frm_Panel Panel = new Frm_Panel();
            this.Hide();
            Panel.ShowDialog();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Paquetes_Click(object sender, EventArgs e)
        {
            View.Frm_Paquetes Admin = new Frm_Paquetes();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_TiposPaquetes_Click(object sender, EventArgs e)
        {
            View.Frm_TipoPaquetes Admin = new Frm_TipoPaquetes();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_Generos_Click(object sender, EventArgs e)
        {
            View.Frm_Generos Admin = new Frm_Generos();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_Turnos_Click(object sender, EventArgs e)
        {
            View.Frm_Turnos Admin = new Frm_Turnos();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_Pais_Click(object sender, EventArgs e)
        {
            View.Frm_Pais Admin = new Frm_Pais();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_Clientes_Click(object sender, EventArgs e)
        {
            View.Frm_Clientes Admin = new Frm_Clientes();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_OrdenInstalacion_Click(object sender, EventArgs e)
        {
            View.Frm_Ordenes Admin = new Frm_Ordenes();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_ClientesProspectos_Click(object sender, EventArgs e)
        {
            View.Frm_ProspectosClientes Admin = new Frm_ProspectosClientes();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_Empleados_Click(object sender, EventArgs e)
        {
            View.Frm_Empleados Admin = new Frm_Empleados();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_Usuarios_Click(object sender, EventArgs e)
        {
            View.Frm_Usuarios Admin = new Frm_Usuarios();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_Departamentos_Click(object sender, EventArgs e)
        {
            View.Frm_Departamento_Emp Admin = new Frm_Departamento_Emp();
            this.Hide();
            Admin.ShowDialog();
        }

        private void Btn_OrdenesMantenimiento_Click(object sender, EventArgs e)
        {
            View.Frm_Mantenimiento Admin = new Frm_Mantenimiento();
            this.Hide();
            Admin.ShowDialog();
        }
    }
}
