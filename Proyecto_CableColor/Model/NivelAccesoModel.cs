using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class NivelAccesoModel
    {
        public int IdNivelUser { get; set; }
        public string Nivel_Acceso { get; set; }

        public static DataTable ListarAccesos { get; set; }
    }
}
