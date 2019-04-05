using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplicaciono.CrearUsuario
{
    static class ValidacionesUtils
    {
        private static string valNif = "/^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKE]";
        private static string valNie = "/^[XYZ][0-9]{7}[TRWAGMYFPDXBNJZSQVHLCKE]";
        private static string valNombre = @"/^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$";
        private static Match match;
        private static Match match2;

        //TODO Simplificar las validaciones para no repetir el introducir una y otra vez el mismo código

        public static bool ValidarDni(string editDni)
        {
            match = Regex.Match(editDni, valNif, RegexOptions.IgnoreCase);
            match2 = Regex.Match(editDni, valNie, RegexOptions.IgnoreCase);
            if (editDni != string.Empty && match.Success && match2.Success)
            {
                return true;
            }
            return false;
        }

        public static bool ValidarNombreApellidos(string editNombre)
        {
            match = Regex.Match(editNombre, valNombre, RegexOptions.IgnoreCase);
            if (editNombre != string.Empty && match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
