using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Infra;

public partial class Transaco
{
    public int TraId { get; set; }

    public string TraDescricao { get; set; } = null!;

    public decimal TraValor { get; set; }

    public int TraTipo { get; set; }

    public int PesId { get; set; }

    public int CatId { get; set; }

    public virtual Categoria Cat { get; set; } = null!;

    public virtual Pessoa Pes { get; set; } = null!;
}
