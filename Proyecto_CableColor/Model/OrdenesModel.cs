using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class OrdenesModel
    {
        public int Cod_Cliente_Pendiente { get; set; }
        public int Cod_Cliente { get; set; }
        public DateTime Fecha_Instalacion { get; set; }
        public int Cod_Empleado { get; set; }
        public string Telefono { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public static DataTable ListarOrdenes { get; set; }
        public static DataTable Data { get; set; }
    }
}
