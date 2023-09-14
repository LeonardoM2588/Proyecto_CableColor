using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class EmpleadosModel
    {
        public int Cod_Empleado { get; set; }
        public string Identidad_Empleado { get; set; }
        public string Nombre_Empleado { get; set; }
        public int Edad { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Cod_Genero { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Cod_EstadoCivil { get; set; }
        public int IDMUNICIPIO { get; set; }
        public string Num_Contador { get; set; }
        public bool Propietario_Vivienda { get; set; }
        public int Cod_Cargo { get; set; }
        public int Cod_Turno { get; set; }
        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public static DataTable ListarEmpleados { get; set; }
        public static DataTable Data { get; set; }
    }
}
