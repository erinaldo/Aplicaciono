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
        private static string valNif = @"^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKE]";
        private static string valNie = @"^[XYZ][0-9]{7}[TRWAGMYFPDXBNJZSQVHLCKE]";
        private static string valNombre = @"^([A-ZÁÉÍÓÚ]+[\s]*)+$";
        private static string valDireccion = @"^([A-ZÁÉÍÓÚ,0-9]+[\s]*)+$";
        private static string valCP = @"^(?:0[1-9]|[1-4]\d|5[0-2])\d{3}$";
        private static Match match;
        private static Match match2;

        //TODO Simplificar las validaciones para no repetir el introducir una y otra vez el mismo código

        public static bool ValidarDni(string editDni)
        {
            match = Regex.Match(editDni, valNif, RegexOptions.IgnoreCase);
            match2 = Regex.Match(editDni, valNie, RegexOptions.IgnoreCase);
            if (editDni != string.Empty && (Regex.IsMatch(editDni, valNif) || Regex.IsMatch(editDni, valNie)))
            {
                return true;
            }
            return false;
        }

        public static bool ValidarPalabras(string editNombre)
        {
            match = Regex.Match(editNombre, valNombre, RegexOptions.IgnoreCase);
            if (editNombre != string.Empty && Regex.IsMatch(editNombre, valNombre))
            {
                return true;
            }
            return false;
        }

        public static bool ValidarDireccion(string editDireccion)
        {
            match = Regex.Match(editDireccion, valDireccion, RegexOptions.IgnoreCase);
            if (editDireccion != string.Empty && Regex.IsMatch(editDireccion, valDireccion))
            {
                return true;
            }
            return false;
        }

        public static bool ValidarCodigoPostal(string editCP)
        {
            match = Regex.Match(editCP, valCP, RegexOptions.IgnoreCase);
            if (editCP != string.Empty && match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
