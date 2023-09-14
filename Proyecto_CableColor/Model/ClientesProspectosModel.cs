using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class ClientesProspectosModel
    {
        public int Cod_Cliente_Prospecto { get; set; }
        public string Nombre { get; set; }
        public int Cod_Paquete { get; set; }
        public DateTime Fecha_Estimada_Contratar { get; set; }
        public string Celular { get; set; }
        public int Cod_Empleado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public static DataTable ListarProspectos { get; set; }
        public static DataTable Data { get; set; }
    }
}
