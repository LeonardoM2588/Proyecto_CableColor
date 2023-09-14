using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class MantenimientoModel
    {
        public int Cod_Orden_Mant { get; set; }
        public int Cod_Cliente { get; set; }
        public DateTime Fecha_Mantenimiento { get; set; }
        public int Cod_Empleado { get; set; }
        public string Telefono { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public static DataTable ListarMantenimientos { get; set; }
        public static DataTable Data { get; set; }
    }
}
