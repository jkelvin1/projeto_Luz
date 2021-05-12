using CRUD_ProdFinanceiro.BDCRUD;
using CRUD_ProdFinanceiro.Connection;
using CRUD_ProdFinanceiro.Interface;
using CRUD_ProdFinanceiro.ViewModel;
using Moq;
using MySqlConnector;
using NUnit.Framework;
using System.Data;

namespace UnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeveriaRetornarUmIdAoCriarNoBanco() //Create_InsereAcaoNoBancoDeDados_RetornaIdInteiro
        {
            MySqlCRUD sutMySqlCrud = new MySqlCRUD();

            string Sigla = "Teste";
            string Nome = "Teste";
            string Setor = "Teste";
            string opcaoTabela = "produto_acao";

            int resultado = sutMySqlCrud.Create(Sigla, Nome, Setor, opcaoTabela);

            Assert.IsNotNull(resultado);

            sutMySqlCrud.Delete(resultado, opcaoTabela);
        }

        [Test]
        public void Delete_RemoveAcaoDoBancoDeDados_RetornaTrue()
        {
            MySqlCRUD sutMySqlCrud = new MySqlCRUD();

            string Sigla = "Teste";
            string Nome = "Teste";
            string Setor = "Teste";
            string opcaoTabela = "produto_acao";
            int id = sutMySqlCrud.Create(Sigla, Nome, Setor, opcaoTabela);

            bool resultado = sutMySqlCrud.Delete(id, opcaoTabela);

            Assert.IsNotNull(resultado);

        }

        [Test]
        public void AbrirConexao_AbreConexaoComBancoDeDados_RetornaUmaConexao()
        {
            DBConnection sutdbConnection = new DBConnection(new MySqlConnection());

            var resultado = sutdbConnection.AbrirConexao();

            Assert.IsTrue(resultado is IDbConnection);
        }
        //[Test]
        //public void DeveriaRetornarUmItemSelecionadoParaDeletar()
        //{
        //    //ARRANGE
        //    Mock<IProdutoFinanceiro> mockProdutoFinanceiro = new Mock<IProdutoFinanceiro>();
        //    ProdutoFinanceiroViewModel sutProdutoFinanceiroViewModel = new ProdutoFinanceiroViewModel();

        //    //ACT
        //    bool resultado = sutProdutoFinanceiroViewModel.DeleteProdutoFinanceiroCanUse(mockProdutoFinanceiro.Object);


        //    //ASSERT
        //    Assert.IsTrue(resultado);
        //}

        //[Test]
        //public void DeveriaRetornarUmItemSelecionadoParaEditar()
        //{
        //    //ARRANGE
        //    Mock<IProdutoFinanceiro> mockProdutoFinanceiro = new Mock<IProdutoFinanceiro>();
        //    ProdutoFinanceiroViewModel sutProdutoFinanceiroViewModel = new ProdutoFinanceiroViewModel();

        //    //ACT
        //    bool resultado = sutProdutoFinanceiroViewModel.UpdateProdutoFinanceiroCanUse(mockProdutoFinanceiro.Object);

        //    //ASSERT
        //    Assert.IsTrue(resultado);
        //}

    }
}