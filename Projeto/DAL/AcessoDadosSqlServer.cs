using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BLL
{
    public class AcessoDadosSqlServer
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private SqlDataReader Dr;
        private DataTable data;
        private SqlDataAdapter da;
        private SqlCommandBuilder cb;

        public void AbrirConexao()
        {
            try
            {   
                //Connection String
                Con = new SqlConnection("Data Source=MATTHEW-PC;Initial Catalog=CrudBasico;Integrated Security=True");//Connection String
                Con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  void FecharConexao()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ExecutarComandoSql(string comandoSql)
        {
            SqlCommand comando = new SqlCommand(comandoSql, Con);
            comando.ExecuteNonQuery();
            Con.Close();
        }

        public SqlDataReader RetDataReader(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, Con);
            Dr = comando.ExecuteReader();
            Dr.Read();
            return Dr;
        }

        public DataTable RedDataTable(string sql)
        {
            data = new DataTable();
            da = new SqlDataAdapter(sql, Con);
            cb = new SqlCommandBuilder(da);
            da.Fill(data);

            return data;
        }
    }
}
