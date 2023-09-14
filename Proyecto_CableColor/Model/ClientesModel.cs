using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CableColor.Model
{
    class ClientesModel
    {
        public int Cod_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Identidad_Cliente { get; set; }
        public string Celular { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Cod_Genero { get; set; }
        public int Cod_EstadoCivil { get; set; }
        public int Cod_Nacionalidad { get; set; }
        public int IDSECTOR { get; set; }
        public string Referencia_Direccion { get; set; }
        public string Referencia_Personal { get; set; }
        public string Numero_Referencia { get; set; }
        public int Cod_Paquete { get; set; }
        public bool Contrato_Anual { get; set; }
        public string Observacion { get; set; }
        public string Contrato_Fisico { get; set; }
        public string Factura_Fisica { get; set; }
        public string Fecha_Maxima_Pago { get; set; }
        public string Vendedor { get; set; }
        public DateTime Fecha_Elaborado { get; set; }
        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public static DataTable ListarClientes { get; set; }
        public static DataTable Data { get; set; }
    }
}
