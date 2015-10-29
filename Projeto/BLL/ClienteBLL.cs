using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class ClienteBLL
    {
        AcessoDadosSqlServer bd;

        public void inserir(DTO.ClienteDTO dto)
        {
            try
            {
                string nome = dto.Nome.Replace("'", "''");
                bd = new AcessoDadosSqlServer();
                bd.AbrirConexao();
                string comando = "INSERT INTO CLIENTES (nome, email, id_categoria) VALUES('" + nome + "','" + dto.Email + "','" + dto.Id_categoria + "')";
                bd.ExecutarComandoSql(comando);  
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentar cadastrar o cliente: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
            
        }

        public void alterar(DTO.ClienteDTO dto)
        {
            try
            {
                string nome = dto.Nome.Replace("'", "''");
                bd = new AcessoDadosSqlServer();
                bd.AbrirConexao();
                string comando = "UPDATE CLIENTES SET nome = '" + nome + "', email = '" + dto.Email + "', id_categoria = " + dto.Id_categoria + "WHERE id = " + dto.Id;
                bd.ExecutarComandoSql(comando);
            }
            catch (Exception ex)
            {
                
                throw new Exception("Erro ao tentar cadastrar o cliente: " + ex.Message);
            }finally{
                bd = null;
            }     
        }

        public void excluir(int id_cliente)
        {
            try
            {
                bd = new AcessoDadosSqlServer();
                bd.AbrirConexao();
                string comando = "DELETE FROM CLIENTES WHERE id = " + id_cliente;
                bd.ExecutarComandoSql(comando);
            }
            catch (Exception ex)
            {
                
                throw new Exception("Erro ao tentar excluir o cliente : " + ex.Message);
            }
            
        }

        public DataTable selecionaTodosClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                bd = new AcessoDadosSqlServer();
                bd.AbrirConexao();
                dt = bd.RedDataTable("select id, nome , email , id_categoria from clientes order by nome");
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentar selecionar todos os clientes: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
            return dt;
        } 
    }
}
