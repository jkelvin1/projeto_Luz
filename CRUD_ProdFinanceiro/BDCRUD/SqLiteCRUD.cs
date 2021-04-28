using CRUD_ProdFinanceiro.Connection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace CRUD_ProdFinanceiro.BDCRUD
{
    public class SqLiteCRUD
    {
        private DBConnection dbconnection;
        private SQLiteCommand sqlitecommand;
       
        public SqLiteCRUD()
        {
            dbconnection = new DBConnection(new SQLiteConnection("Data Source = C:\\Users\\User\\Desktop\\projeto_Luz\\SQLite\\produto_financeiro.db"));
            sqlitecommand = new SQLiteCommand();        
        }

        public void Create(string Sigla, string Nome, string Setor, string opcaoTabela)
        {
            try
            {
                using (sqlitecommand.Connection = (SQLiteConnection)dbconnection.AbrirConexao())
                {
                    sqlitecommand.CommandText = "INSERT INTO " + opcaoTabela + "(SIGLA, NOME, SETOR) VALUES(@SIGLA, @NOME, @SETOR)";
                    sqlitecommand.Parameters.AddWithValue("@SIGLA", Sigla);
                    sqlitecommand.Parameters.AddWithValue("@NOME", Nome);
                    sqlitecommand.Parameters.AddWithValue("@SETOR", Setor);
                    sqlitecommand.ExecuteNonQuery();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        public void Read(string Sigla, string opcaoTabela)
        {

        }
        public void Update(int Id, string Sigla, string Nome, string Setor, string opcaoTabela)
        {

        }
        public void Delete(int Id, string opcaoTabela)
        {

        }
        public void ReadAll()
        {

        }
    }
}
