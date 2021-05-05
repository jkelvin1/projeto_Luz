using CRUD_ProdFinanceiro.Command;
using CRUD_ProdFinanceiro.Interface;
using CRUD_ProdFinanceiro.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MySqlConnector;
using CRUD_ProdFinanceiro.Connection;
using CRUD_ProdFinanceiro.BDCRUD;
using System.Windows.Controls;

namespace CRUD_ProdFinanceiro.ViewModel
{
    public class ProdutoFinanceiroViewModel
    {
        private string opcaoTabela;
        private MySqlCRUD mysqlcrud;
        //private SqLiteCRUD sqlitecrud;
        public ProdutoFinanceiroViewModel()
        {
            ProdutoFinanceiro = new ObservableCollection<IProdutoFinanceiro>();

            this.mysqlcrud = new MySqlCRUD();
            //sqlitecrud = new SqLiteCRUD();

            this.mysqlcrud.ReadAll(ProdutoFinanceiro);


            this.MyCommands();
        }

        public ObservableCollection<IProdutoFinanceiro> ProdutoFinanceiro { get; set; }
        
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Tipo { get; set; }


        public ICommand CreateProdutoFinanceiroCommand { get; private set; }
        public ICommand ReadProdutoFinanceiroCommand { get; private set; }
        public ICommand UpdateProdutoFinanceiroCommand { get; private set; }
        public ICommand DeleteProdutoFinanceiroCommand { get; private set; }
        

        #region Comandos
        private void MyCommands()
        {
            CreateProdutoFinanceiroCommand = new RelayCommand(CreateProdutoFinanceiro, CreateProdutoFinanceiroCanUse);
            ReadProdutoFinanceiroCommand = new RelayCommand(ReadProdutoFinanceiro, ReadProdutoFinanceiroCanUse);
            UpdateProdutoFinanceiroCommand = new RelayCommand(UpdateProdutoFinanceiro, UpdateProdutoFinanceiroCanUse);
            DeleteProdutoFinanceiroCommand = new RelayCommand(DeleteProdutoFinanceiro, DeleteProdutoFinanceiroCanUse);
        }

        
        private void CreateProdutoFinanceiro(object objRelayCommand)
        {
            if (Tipo == "Ação")
            {
                this.opcaoTabela = "produto_acao";
                
            }
            else if (Tipo == "Fundo")
            {
                this.opcaoTabela = "produto_fundo";
            }

            int Id =  mysqlcrud.Create(Sigla, Nome, Setor, opcaoTabela);
            
            if ( Id != 0 )
            {
                if (this.opcaoTabela == "produto_acao")
                {
                    ProdutoFinanceiro.Add(new AcaoModel(Id, Sigla, Nome, Setor));

                }
                else if (this.opcaoTabela == "produto_fundo")
                {
                    ProdutoFinanceiro.Add(new FundoModel(Id, Sigla, Nome, Setor));
                }
            }

            //sqlitecrud.Create(Sigla, Nome, Setor, opcaoTabela, ProdutoFinanceiro);


        }
        private bool CreateProdutoFinanceiroCanUse(object objRelayCommand)
        {
            return true;
        }

        private void ReadProdutoFinanceiro(object objRelayCommand)
        {
            ProdutoFinanceiro.Clear();

            if (Sigla == "")
            {
                mysqlcrud.ReadAll(ProdutoFinanceiro);
            }

            mysqlcrud.Read(Sigla, ProdutoFinanceiro);
        }
        private bool ReadProdutoFinanceiroCanUse(object objRelayCommand)
        {
            return true;
        }

        private void UpdateProdutoFinanceiro(object objRelayCommand)
        {
            IProdutoFinanceiro itemSelecionado = (IProdutoFinanceiro)objRelayCommand;
            
            if (itemSelecionado.Tipo == "Ação")
            {
                this.opcaoTabela = "produto_acao";
            }
            else if (itemSelecionado.Tipo == "Fundo")
            {
                this.opcaoTabela = "produto_fundo";
            }
            mysqlcrud.Update(itemSelecionado.Id, Sigla, Nome, Setor, opcaoTabela);
            
        }
        private bool UpdateProdutoFinanceiroCanUse(object objRelayCommand)
        {
            if (objRelayCommand == null)
                return false;
            return true;
        }

        private void DeleteProdutoFinanceiro(object objRelayCommand)
        {
            IProdutoFinanceiro itemSelecionado = (IProdutoFinanceiro)objRelayCommand;

            if (itemSelecionado.Tipo == "Ação")
            {
                opcaoTabela = "produto_acao";
            }
            else if (itemSelecionado.Tipo == "Fundo")
            {
                opcaoTabela = "produto_fundo";
            }
       
            if (mysqlcrud.Delete(itemSelecionado.Id, opcaoTabela))
            {
                ProdutoFinanceiro.Remove(itemSelecionado);
            }
        }
        private bool DeleteProdutoFinanceiroCanUse(object objRelayCommand)
        {
            if (objRelayCommand == null)
                return false;
            return true;
        }

        #endregion
    }
}
