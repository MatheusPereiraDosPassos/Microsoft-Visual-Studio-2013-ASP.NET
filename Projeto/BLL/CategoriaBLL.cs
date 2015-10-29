using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class CategoriaBLL
    {
        AcessoDadosSqlServer bd = new AcessoDadosSqlServer();
        public DataTable selecionaTodasCategorias()
        {
            bd.AbrirConexao();
            DataTable dt = new DataTable();
            dt = bd.RedDataTable("SELECT ID , DESCRICAO FROM CATEGORIA ORDER BY DESCRICAO");
            return dt;
        } 
    }
}
