using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Domain.Models;

public partial class Pessoa
{
    public int PesId { get; set; }
    public string PesNome { get; set; } = null!;
    public int PesIdade { get; set; }    
    public virtual ICollection<Transaco> Transacos { get; set; } = new List<Transaco>();
    public string validate() //Metodo para validação da entidade
    {
        string errorMsg = string.Empty;
        errorMsg = validateIdade(this); //Metodo para validar a idade da pessoa

        if (errorMsg != "") return errorMsg;

        return string.Empty;
    }
    private static string validateIdade(Pessoa Model) //Implementação do metodo para validar idade da pessoa
    {
        if (Model.PesIdade <= 0)
        {
            return "Idade da pessoa precisa ser um numero positivo";
        }

        return "";
    }
}
