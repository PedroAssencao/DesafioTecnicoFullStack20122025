namespace ControleFinanceiro.Domain.Models;

public partial class Pessoa
{
    public int PesId { get; set; }
    public string PesNome { get; set; } = null!;
    public int PesIdade { get; set; }    
    public virtual ICollection<Transaco> Transacos { get; set; } = new List<Transaco>();
    public string validate(bool? isUpdate = false) //Metodo para validação da entidade
    {
        string errorMsg = string.Empty;
        errorMsg += validateIdade(this) + ","; //Metodo para validar a idade da pessoa
        errorMsg += validateNome(this) + ","; //Metodo para validar a nome da pessoa

        if (isUpdate.HasValue && isUpdate.Value == true) //metodos que precisam ser validados apenas na atualização
        {
            errorMsg += validateId(this) + ",";
        }

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
    private static string validateNome(Pessoa Model) //Implementação do metodo para validar nome da pessoa
    {
        if (Model.PesNome.Length > 150)
        {
            return "O nome informado contem mais de 150 caracteres.";
        }

        if (Model.PesNome.Length == 0)
        {
            return "O campo nome deve ser informado";
        }

        return "";
    }
    public static string validateId(Pessoa Model) //Metodo para validar o id da pessoa
    {
        if (Model.PesId <= 0)
        {
            return "O id informado e invalido.";
        }

        return string.Empty;
    }
}
