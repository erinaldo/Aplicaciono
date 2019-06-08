using Aplicaciono.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaciono.GestionClientes
{
    interface IGestionImpuestosPresenter
    {
        List<Clientes> cargarClientes(SqlConnection con);
        void salirClick();
    }
}
