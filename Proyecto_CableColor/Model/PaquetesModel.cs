using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class PaquetesModel
    {
        public int Cod_Paquete { get; set; }
        public int Cod_TipoPaquete { get; set; }
        public string Paquete { get; set; }
        public string Precio_Paquete { get; set; }
        public bool Estado { get; set; }

        public static DataTable ListarPaquetes { get; set; }
        public static DataTable Data { get; set; }
    }
}
