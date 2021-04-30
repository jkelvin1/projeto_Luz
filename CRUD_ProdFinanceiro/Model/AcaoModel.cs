using CRUD_ProdFinanceiro.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace CRUD_ProdFinanceiro.Model
{
    public class AcaoModel : INotifyPropertyChanged, IProdutoFinanceiro
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomePropriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }


        public AcaoModel(int mdlId, string mdlSigla, string mdlNome, string mdlSetor)
        {
            Id = mdlId;
            Sigla = mdlSigla;
            Nome = mdlNome;
            Setor = mdlSetor;
            Tipo = "Ação";
        }

        private int _id;
        private string _sigla;
        private string _nome;
        private string _setor;
        private string _tipo;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Sigla
        {
            get { return _sigla; }
            set
            {
                _sigla = value;
                OnPropertyChanged("Sigla");
            }
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged("Nome");
            }
        }


        public string Setor
        {
            get { return _setor; }
            set
            {
                _setor = value;
                OnPropertyChanged("Setor");
            }
        }

        public string Tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value;
                OnPropertyChanged("Tipo");
            }
        }
    }
}
