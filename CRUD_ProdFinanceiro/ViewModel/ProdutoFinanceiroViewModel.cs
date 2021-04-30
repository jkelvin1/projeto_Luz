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
        public MySqlCRUD mysqlcrud;
        public SqLiteCRUD sqlitecrud;
         
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
        

        public ProdutoFinanceiroViewModel()
        {
            ProdutoFinanceiro = new ObservableCollection<IProdutoFinanceiro>();

            mysqlcrud = new MySqlCRUD();
            sqlitecrud = new SqLiteCRUD();

            mysqlcrud.ReadAll(ProdutoFinanceiro);


            this.MyCommands();
        }

        private void MyCommands()
        {
            CreateProdutoFinanceiroCommand = new RelayCommand(CreateProdutoFinanceiro, CreateProdutoFinanceiroCanUse);
            ReadProdutoFinanceiroCommand = new RelayCommand(ReadProdutoFinanceiro, ReadProdutoFinanceiroCanUse);
            UpdateProdutoFinanceiroCommand = new RelayCommand(UpdateProdutoFinanceiro, UpdateProdutoFinanceiroCanUse);
            DeleteProdutoFinanceiroCommand = new RelayCommand(DeleteProdutoFinanceiro, DeleteProdutoFinanceiroCanUse);
        }
        

        public void CreateProdutoFinanceiro(object objRelayCommand)
        {
            if (Tipo == "Ação")
            {
                opcaoTabela = "produto_acao";
                
            }
            else if (Tipo == "Fundo")
            {
                opcaoTabela = "produto_fundo";
            }
            mysqlcrud.Create(Sigla, Nome, Setor, opcaoTabela, ProdutoFinanceiro);
            //sqlitecrud.Create(Sigla, Nome, Setor, opcaoTabela, ProdutoFinanceiro);

            
        }
        public bool CreateProdutoFinanceiroCanUse(object objRelayCommand)
        {
            return true;
        }

        public void ReadProdutoFinanceiro(object objRelayCommand)
        {
            ProdutoFinanceiro.Clear();
            mysqlcrud.Read(Sigla, ProdutoFinanceiro);
            if(Sigla == "")
            {
                mysqlcrud.ReadAll(ProdutoFinanceiro);
            }
        }
        public bool ReadProdutoFinanceiroCanUse(object objRelayCommand)
        {
            return true;
        }

        public void UpdateProdutoFinanceiro(object objRelayCommand)
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
            mysqlcrud.Update(itemSelecionado.Id, Sigla, Nome, Setor, opcaoTabela);
            
        }
        public bool UpdateProdutoFinanceiroCanUse(object objRelayCommand)
        {
            if (objRelayCommand == null)
                return false;
            return true;
        }

        public void DeleteProdutoFinanceiro(object objRelayCommand)
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

            mysqlcrud.Delete(itemSelecionado.Id, opcaoTabela, itemSelecionado, ProdutoFinanceiro);
        }
        public bool DeleteProdutoFinanceiroCanUse(object objRelayCommand)
        {
            if (objRelayCommand == null)
                return false;
            return true;
        }
    }
}
