using ControleFinanceiro.Domain.Enums.Base;

namespace ControleFinanceiro.Domain.Models;

public partial class Categoria
{
    public int CatId { get; set; }
    public string CatDescricao { get; set; } = null!;
    public ECategoriaEnum CatFinalidade { get; set; }
    public virtual ICollection<Transaco> Transacos { get; set; } = new List<Transaco>();
    public string validate(bool? isUpdate = false) //Metodo para validação da entidade
    {
        string errorMsg = string.Empty;
        errorMsg = validateDescricao(this); //Metodo para validar a descricao da categoria
        if (isUpdate.HasValue && isUpdate.Value == true) //metodos que precisam ser validados apenas na atualização
        {
            errorMsg = validateId(this);
        }
        if (errorMsg != "") return errorMsg;

        return string.Empty;
    }
    private static string validateDescricao(Categoria model)
    {
        if (model.CatDescricao.Length > 100)
        {
            return "A descricao informada contem mais de 100 caracteres.";
        }

        return "";
    }
    private static string validateId(Categoria model)
    {
        if (model.CatId <= 0)
        {
            return "O id informado e invalido.";
        }
        return string.Empty;
    }
}
