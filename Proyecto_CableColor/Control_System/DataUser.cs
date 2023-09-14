using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Proyecto_CableColor.Control_System
{
    class DataUser
    {
        //propiedades del usuario logeado
        public static int ID;
        public static string USERNAME;
        public static string REALNAMEUSER;
        public static string ROLE;
        public static string CORREO;
        public static int IDEMPLEADO;

        //Variable De Acceso
        public static int Contador;

        //metodo para crear hash de la contraseña
        public string MakeHash(string key)
        {
            string hash = "";
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] inputbytes = (new UnicodeEncoding()).GetBytes(key);
            byte[] result = sha512.ComputeHash(inputbytes);
            hash = Convert.ToBase64String(result);
            return hash;
        }
    }
}
