using ControleFinanceiro.Domain.Enums.Base;

namespace ControleFinanceiro.API.DTO
{
    public class TransacoesDTO
    {
        public class TranscacoesDTOView
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; } = string.Empty;
            public decimal Valor { get; set; }
            public TipoTransacao Tipo { get; set; } = new TipoTransacao();
            public CategoriaDTO.CategoriaDTOViewForTransacoes Categoria { get; set; } = new CategoriaDTO.CategoriaDTOViewForTransacoes();
            public PessoaDTO.PessoaDTOViewForTransacoes Pessoa { get; set; } = new PessoaDTO.PessoaDTOViewForTransacoes();

        }

        public class TranscacoesDTOViewForPessoa
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; } = string.Empty;
            public decimal Valor { get; set; }
            public TipoTransacao Tipo { get; set; } = new TipoTransacao();
            public CategoriaDTO.CategoriaDTOViewForTransacoes Categoria { get; set; } = new CategoriaDTO.CategoriaDTOViewForTransacoes();

        }

        public class transacoesDTOCreate
        {
            public string Descricao { get; set; } = string.Empty;
            public decimal Valor { get; set; }
            public ETipoTransacaoEnum Tipo { get; set; }
            public int CategoriaCodigo { get; set; }
            public int PessoaCodigo { get; set; }
        }

        public class transacoesDTOUpdate
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; } = string.Empty;
            public decimal Valor { get; set; }
            public ETipoTransacaoEnum Tipo { get; set; }
            public int CategoriaCodigo { get; set; }
            public int PessoaCodigo { get; set; }
        }

        public class TipoTransacao
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; } = string.Empty;
        }
    }
}
