using CRUD_ProdFinanceiro.Connection;
using CRUD_ProdFinanceiro.Interface;
using CRUD_ProdFinanceiro.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CRUD_ProdFinanceiro.BDCRUD
{
    public class MySqlCRUD
    {
        private DBConnection dbconnection;
        private MySqlCommand mysqlComando;
        private MySqlDataReader mysqldatareader;
        public MySqlCRUD()
        {
            this.dbconnection = new DBConnection(new MySqlConnection("Server=localhost;Database=produto_financeiro;Uid=root;Pwd=vjGfkY2Ee5@8ReF;"));
            this.mysqlComando = new MySqlCommand();
        }

        public int Create(string Sigla, string Nome, string Setor, string opcaoTabela)
        {
            this.mysqlComando.Parameters.Clear();
            this.mysqlComando.CommandText = "INSERT INTO " + opcaoTabela + " (SIGLA, NOME, SETOR) VALUES (@SIGLA, @NOME, @SETOR)";

            this.mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);
            this.mysqlComando.Parameters.AddWithValue("@NOME", Nome);
            this.mysqlComando.Parameters.AddWithValue("@SETOR", Setor);

            try
            {
                this.mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                this.mysqlComando.ExecuteNonQuery();

                int Id = (int)mysqlComando.LastInsertedId;
                return Id;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                this.dbconnection.FecharConexao();
            }
        }

        public void Read(string Sigla, ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            ReadAcao(Sigla, produtoFinanceiro);
            ReadFundo(Sigla, produtoFinanceiro);
        }

        public void Update(int Id, string Sigla, string Nome, string Setor, string opcaoTabela)
        {
            this.mysqlComando.Parameters.Clear();
            this.mysqlComando.CommandText = "UPDATE " + opcaoTabela + " SET SIGLA = @SIGLA, NOME = @NOME, SETOR = @SETOR WHERE ID = @ID";

            this.mysqlComando.Parameters.AddWithValue("@ID", Id);
            this.mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);
            this.mysqlComando.Parameters.AddWithValue("@NOME", Nome);
            this.mysqlComando.Parameters.AddWithValue("@SETOR", Setor);

            try
            {
                this.mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                this.mysqlComando.ExecuteNonQuery();
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

        public bool Delete(int Id, string opcaoTabela)
        {
            this.mysqlComando.Parameters.Clear();
            this.mysqlComando.CommandText = "DELETE FROM " + opcaoTabela + " WHERE ID = @ID";

            this.mysqlComando.Parameters.AddWithValue("@ID", Id);

            try
            {
                this.mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                this.mysqlComando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                this.dbconnection.FecharConexao();
            }
        }

        public void ReadAll(ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            ReadAllAcao(produtoFinanceiro);
            ReadAllFundo(produtoFinanceiro);
        }

        private void ReadAllAcao(ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            this.mysqldatareader = Select("produto_acao");
            while (this.mysqldatareader.Read())
            {
                produtoFinanceiro.Add(new AcaoModel(mysqldatareader.GetInt32(0), mysqldatareader.GetString(1), mysqldatareader.GetString(2), mysqldatareader.GetString(3)));

            }
            this.dbconnection.FecharConexao();
        }

        private void ReadAllFundo(ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            this.mysqldatareader = Select("produto_fundo");
            while (this.mysqldatareader.Read())
            {
                produtoFinanceiro.Add(new FundoModel(mysqldatareader.GetInt32(0), mysqldatareader.GetString(1), mysqldatareader.GetString(2), mysqldatareader.GetString(3)));

            }
            this.dbconnection.FecharConexao();
        }

        private void ReadAcao(string Sigla, ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            this.mysqldatareader = Select("produto_acao", Sigla);
            while (this.mysqldatareader.Read())
            {
                produtoFinanceiro.Add(new AcaoModel(mysqldatareader.GetInt32(0), mysqldatareader.GetString(1), mysqldatareader.GetString(2), mysqldatareader.GetString(3)));

            }
            this.dbconnection.FecharConexao();
        }

        private void ReadFundo(string Sigla, ICollection<IProdutoFinanceiro> produtoFinanceiro)
        {
            this.mysqldatareader = Select("produto_fundo", Sigla);
            while (this.mysqldatareader.Read())
            {
                produtoFinanceiro.Add(new FundoModel(mysqldatareader.GetInt32(0), mysqldatareader.GetString(1), mysqldatareader.GetString(2), mysqldatareader.GetString(3)));

            }
            this.dbconnection.FecharConexao();

        }

        private MySqlDataReader Select(string tabela, string Sigla = null)
        {
            this.mysqlComando.Parameters.Clear();
            this.mysqlComando.CommandText = "SELECT * FROM " + tabela;

            if (Sigla != null)
            {
                this.mysqlComando.CommandText += " WHERE SIGLA = @SIGLA";
                this.mysqlComando.Parameters.AddWithValue("@SIGLA", Sigla);
            }

            try
            {
                this.mysqlComando.Connection = (MySqlConnection)dbconnection.AbrirConexao();
                this.mysqldatareader = mysqlComando.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return this.mysqldatareader;
        }
    }
}
