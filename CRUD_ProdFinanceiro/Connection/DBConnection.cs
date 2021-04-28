using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace CRUD_ProdFinanceiro.Connection
{
    public class DBConnection
    {
        private IDbConnection Conexao;
        

        public DBConnection(IDbConnection Conexao)
        {
            this.Conexao = Conexao;
        }

        public IDbConnection AbrirConexao()
        {
            if(Conexao.State == System.Data.ConnectionState.Closed)
            {
                Conexao.Open();
            }
            return Conexao;
        }

        public void FecharConexao()
        {
            if (Conexao.State == System.Data.ConnectionState.Open)
            {
                Conexao.Close();
            }
        }
    }
}
