using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class TiposPaquetesModel
    {
        public int Cod_TipoPaquete { get; set; }
        public string Tipo_Paquete { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public static DataTable ListarTipoPaquetes { get; set; }
    }
}
