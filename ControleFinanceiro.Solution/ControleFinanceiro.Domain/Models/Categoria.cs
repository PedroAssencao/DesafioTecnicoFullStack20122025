using ControleFinanceiro.Domain.Enums.Base;

namespace ControleFinanceiro.Domain.Models;

public partial class Categoria
{
    public int CatId { get; set; }
    public string CatDescricao { get; set; } = null!;
    public ECategoriaEnum CatFinalidade { get; set; }
    public virtual ICollection<Transaco> Transacos { get; set; } = new List<Transaco>();
}
