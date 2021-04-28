using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_ProdFinanceiro.Interface
{
    public interface IProdutoFinanceiro
    {
        int Id { get; set; }
        string Sigla { get; set; }
        string Nome { get; set; }
        string Setor { get; set; }
        string Tipo { get; set; }
    }
}
