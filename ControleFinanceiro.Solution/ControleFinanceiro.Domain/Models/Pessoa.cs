using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Infra;

public partial class Pessoa
{
    public int PesId { get; set; }

    public string PesNome { get; set; } = null!;

    public int PesIdade { get; set; }

    public virtual ICollection<Transaco> Transacos { get; set; } = new List<Transaco>();
}
