using CRUD_ProdFinanceiro.Connection;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CRUD_ProdFinanceiro.BDCRUD
{
    public class MySqlCRUD
    {
        private DBConnection dbconnection;
        private MySqlCommand mysqlComando;
        public MySqlCRUD()
        {
            dbconnection = new DBConnection(new MySqlConnection("Server=localhost;Database=produto_financeiro;Uid=root;Pwd=vjGfkY2Ee5@8ReF;"));
            mysqlComando = new MySqlCommand();
        }

        public void Create(string Sigla, string Nome, string Setor, string opcaoTabela)
        {
            mysqlComando.CommandText = "INSERT INTO " + opcaoTabela + " (SIGLA, NOME, SETOR) VALUES (@SIGLA, @NOME, @SETOR)";

            mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);
            mysqlComando.Parameters.AddWithValue("@NOME", Nome);
            mysqlComando.Parameters.AddWithValue("@SETOR", Setor);

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqlComando.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbconnection.FecharConexao();
            }
        }

        public void Read(string Sigla, string opcaoTabela)
        {
            mysqlComando.CommandText = "SELECT * FROM " + opcaoTabela + " WHERE SIGLA = @SIGLA";

            mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqlComando.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbconnection.FecharConexao();
            }
        }

        public void Update(int Id, string Sigla, string Nome, string Setor, string opcaoTabela)
        {
            mysqlComando.CommandText = "UPDATE " + opcaoTabela + " SET SIGLA = @SIGLA, NOME = @NOME, SETOR = @SETOR WHERE ID = @ID";

            mysqlComando.Parameters.AddWithValue("@ID", Id);
            mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);
            mysqlComando.Parameters.AddWithValue("@NOME", Nome);
            mysqlComando.Parameters.AddWithValue("@SETOR", Setor);

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqlComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbconnection.FecharConexao();
            }
        }

        public void Delete(int Id, string opcaoTabela)
        {
            mysqlComando.CommandText = "DELETE FROM " + opcaoTabela + " WHERE ID = @ID";

            mysqlComando.Parameters.AddWithValue("@ID", Id);

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqlComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbconnection.FecharConexao();
            }
        }

        public void ReadAll()
        {
            mysqlComando.CommandText = "SELECT * FROM produto_acao";

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqlComando.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbconnection.FecharConexao();
            }
        }
    }
}
