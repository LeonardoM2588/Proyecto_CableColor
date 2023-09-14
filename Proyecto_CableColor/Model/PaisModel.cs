using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class PaisModel
    {
        public int IDPAIS { get; set; }
        public string ISO { get; set; }

        public string PAIS { get; set; }
        public static DataTable ListarPaises { get; set; }
    }
}
