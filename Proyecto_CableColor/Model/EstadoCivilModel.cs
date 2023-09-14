using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class EstadoCivilModel
    {
        public int Cod_EstadoCivil { get; set; }
        public string Estado_Civil { get; set; }

        public static DataTable ListarEstadoCivil { get; set; }
    }
}
