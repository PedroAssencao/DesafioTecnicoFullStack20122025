using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Infra;

public partial class Categoria
{
    public int CatId { get; set; }

    public string CatDescricao { get; set; } = null!;

    public int CatFinalidade { get; set; }

    public virtual ICollection<Transaco> Transacos { get; set; } = new List<Transaco>();
}
