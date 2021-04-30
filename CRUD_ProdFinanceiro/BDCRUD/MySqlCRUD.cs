using CRUD_ProdFinanceiro.Connection;
using CRUD_ProdFinanceiro.Interface;
using CRUD_ProdFinanceiro.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CRUD_ProdFinanceiro.BDCRUD
{
    public class MySqlCRUD
    {
        private DBConnection dbconnection;
        private MySqlCommand mysqlComando;
        private MySqlDataReader mysqldatareader;
        public MySqlCRUD()
        {
            dbconnection = new DBConnection(new MySqlConnection("Server=localhost;Database=produto_financeiro;Uid=root;Pwd=vjGfkY2Ee5@8ReF;"));
            mysqlComando = new MySqlCommand();
        }

        public void Create(string Sigla, string Nome, string Setor, string opcaoTabela, ICollection<IProdutoFinanceiro> produtoFinanceiros)
        {
            mysqlComando.Parameters.Clear();
            mysqlComando.CommandText = "INSERT INTO " + opcaoTabela + " (SIGLA, NOME, SETOR) VALUES (@SIGLA, @NOME, @SETOR)";
  
            mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);
            mysqlComando.Parameters.AddWithValue("@NOME", Nome);
            mysqlComando.Parameters.AddWithValue("@SETOR", Setor);  

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqlComando.ExecuteNonQuery();

                int Id = (int)mysqlComando.LastInsertedId;

                if (opcaoTabela == "produto_acao")
                {
                    produtoFinanceiros.Add(new AcaoModel(Id,Sigla,Nome,Setor));
                    
                }
                else if (opcaoTabela == "produto_fundo")
                {
                    produtoFinanceiros.Add(new FundoModel(Id, Sigla, Nome, Setor));
                }

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

        public void Read(string Sigla, ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            mysqlComando.Parameters.Clear();
            mysqlComando.CommandText = "SELECT * FROM produto_acao WHERE SIGLA = @SIGLA";
            

            mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqldatareader = mysqlComando.ExecuteReader();


                while (mysqldatareader.Read())
                {
                    produtoFinanceiro.Add(new AcaoModel(mysqldatareader.GetInt32(0), mysqldatareader.GetString(1), mysqldatareader.GetString(2), mysqldatareader.GetString(3)));

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbconnection.FecharConexao();
            }

            mysqlComando.Parameters.Clear();
            mysqlComando.CommandText = "SELECT * FROM produto_fundo WHERE SIGLA = @SIGLA";


            mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqldatareader = mysqlComando.ExecuteReader();


                while (mysqldatareader.Read())
                {
                    produtoFinanceiro.Add(new FundoModel(mysqldatareader.GetInt32(0), mysqldatareader.GetString(1), mysqldatareader.GetString(2), mysqldatareader.GetString(3)));

                }
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
            mysqlComando.Parameters.Clear();
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

        public void Delete(int Id, string opcaoTabela, IProdutoFinanceiro itemSelecionado, ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            mysqlComando.Parameters.Clear();
            mysqlComando.CommandText = "DELETE FROM "+opcaoTabela+" WHERE ID = @ID";

            mysqlComando.Parameters.AddWithValue("@ID", Id);

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqlComando.ExecuteNonQuery();
                produtoFinanceiro.Remove(itemSelecionado);
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

        public void ReadAll(ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            mysqlComando.Parameters.Clear();
            mysqlComando.CommandText = "SELECT * FROM produto_acao";

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqldatareader = mysqlComando.ExecuteReader();

                    
                while (mysqldatareader.Read())
                {
                    produtoFinanceiro.Add(new AcaoModel(mysqldatareader.GetInt32(0), mysqldatareader.GetString(1), mysqldatareader.GetString(2), mysqldatareader.GetString(3)));
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbconnection.FecharConexao();
            }

            mysqlComando.CommandText = "SELECT * FROM produto_fundo";

            try
            {
                mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                mysqldatareader = mysqlComando.ExecuteReader();


                while (mysqldatareader.Read())
                {
                    produtoFinanceiro.Add(new FundoModel(mysqldatareader.GetInt32(0), mysqldatareader.GetString(1), mysqldatareader.GetString(2), mysqldatareader.GetString(3)));

                }
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
