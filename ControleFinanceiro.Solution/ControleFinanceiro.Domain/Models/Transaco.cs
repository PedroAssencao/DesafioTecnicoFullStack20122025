using ControleFinanceiro.Domain.Enums.Base;

namespace ControleFinanceiro.Domain.Models;

public partial class Transaco
{
    public int TraId { get; set; }

    public string TraDescricao { get; set; } = null!;

    public decimal TraValor { get; set; }

    public ETipoTransacaoEnum TraTipo { get; set; }

    public int PesId { get; set; }

    public int CatId { get; set; }

    public virtual Categoria Cat { get; set; } = null!;

    public virtual Pessoa Pes { get; set; } = null!;

    public string validate(bool? isUpdate = false) //Metodo para validação da entidade
    {
        string errorMsg = string.Empty;
        errorMsg += validateDescricao(this) + ","; //Metodo para validar descrição
        errorMsg += validateValor(this) + ","; //Metodo para validar valor
        errorMsg += validadePessoa(this) + ","; //Metodo para validar pessoa
        errorMsg += validateCategoria(this) + ","; //Metodo para validar categoria
        errorMsg += validateTipoEPessoa(this) + ","; //Metodo para validar TipoParaPessoa

        if (isUpdate.HasValue && isUpdate.Value)
        {
            errorMsg = validateId(this) + ",";
        }

        if (errorMsg != "") return errorMsg;

        return string.Empty;
    }

    private static string validateDescricao(Transaco model)
    {
        if (model.TraDescricao.Length > 200)
        {
            return "A descricao informada contem mais de 200 caracteres.";
        }

        if (model.TraDescricao.Length == 0)
        {
            return "O campo descrição e obrigatorio";
        }

        return string.Empty;
    }

    private static string validateValor(Transaco model)
    {
        if (model.TraValor <= 0)
        {
            return "O valor da transação deve ser maior que zero.";
        }
        return string.Empty;
    }
    private static string validateId(Transaco model)
    {
        if (model.TraId <= 0)
        {
            return "O id informado e invalido.";
        }
        return string.Empty;
    }

    private static string validadePessoa(Transaco model)
    {
        if (model.PesId == 0)
        {
            return "E obrigatorio informar uma pessoa para transação";
        }

        return string.Empty;
    }

    private static string validateCategoria(Transaco model)
    {
        if (model.CatId == 0)
        {
            return "E obrigatorio informar uma categoria para transação";
        }

        return string.Empty;
    }

    private static string validateTipoEPessoa(Transaco model)
    {
        if (model.Pes.PesIdade < 18 && model.TraTipo != ETipoTransacaoEnum.Despesa)
        {
            return $"Pessoas menores de idades, não podem conter transações do tipo {model.TraTipo.ToString()}. Apenas transações do tipo despesa são validas";
        }

        return string.Empty;
    }
}
