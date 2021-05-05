using CRUD_ProdFinanceiro.Interface;
using CRUD_ProdFinanceiro.ViewModel;
using Moq;
using NUnit.Framework;


namespace UnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeveriaRetornarUmItemSelecionadoParaDeletar()
        {
            //ARRANGE
            Mock<IProdutoFinanceiro> mockProdutoFinanceiro = new Mock<IProdutoFinanceiro>();
            ProdutoFinanceiroViewModel sutProdutoFinanceiroViewModel = new ProdutoFinanceiroViewModel();

            //ACT
            bool resultado = sutProdutoFinanceiroViewModel.DeleteProdutoFinanceiroCanUse(mockProdutoFinanceiro.Object);


            //ASSERT
            Assert.IsTrue(resultado);
        }

        [Test]
        public void DeveriaRetornarUmItemSelecionadoParaEditar()
        {
            //ARRANGE
            Mock<IProdutoFinanceiro> mockProdutoFinanceiro = new Mock<IProdutoFinanceiro>();
            ProdutoFinanceiroViewModel sutProdutoFinanceiroViewModel = new ProdutoFinanceiroViewModel();

            //ACT
            bool resultado = sutProdutoFinanceiroViewModel.UpdateProdutoFinanceiroCanUse(mockProdutoFinanceiro.Object);

            //ASSERT
            Assert.IsTrue(resultado);
        }

    }
}