using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplicaciono.CrearUsuario
{
    static class Validaciones
    {
        private static string valNif = "/^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKE]";
        private static string valNie = "/^[XYZ][0-9]{7}[TRWAGMYFPDXBNJZSQVHLCKE]";
        private static Match match;

        public static bool ValidarDni(string editDni)
        {
            match = Regex.Match(editDni, valNif, RegexOptions.IgnoreCase);
            if (editDni != string.Empty && match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
