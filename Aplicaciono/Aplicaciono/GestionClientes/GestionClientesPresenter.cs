using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicaciono.Conexion;
using Aplicaciono.GestionUsuarios;
using Aplicaciono.Modelos;

namespace Aplicaciono.GestionClientes
{
    class GestionClientesPresenter : IGestionImpuestosPresenter
    {
        GestionClientesView view;
        Conexione repo;

        public GestionClientesPresenter(GestionClientesView view, Conexione repo)
        {
            this.view = view;
            this.repo = repo;
        }

        public List<Clientes> cargarClientes(SqlConnection con)
        {
            List<Clientes> clientes = new List<Clientes>();
            con = repo.AbrirConexion();
            clientes = repo.LeerClientes(con);
            repo.CerrarConexion(con);
            return clientes;
        }

        public void salirClick()
        {
            throw new NotImplementedException();
        }
    }
}
