using ControleFinanceiro.Domain.Enums.Base;

namespace ControleFinanceiro.API.DTO
{
    public class CategoriaDTO
    {
        public class CategoriaDTOView
        {
            public int Codigo { get; set; }
            public string Nome { get; set; } = string.Empty;
            public CategoriaFinalidadeDTO Finalidade { get; set; } = new CategoriaFinalidadeDTO();
            public List<TransacoesDTO.TranscacoesDTOView> Transcacoes { get; set; } = new List<TransacoesDTO.TranscacoesDTOView>();
        }
        public class CategoriaDTOViewForTransacoes
        {
            public int Codigo { get; set; }
            public string Nome { get; set; } = string.Empty;
            public CategoriaFinalidadeDTO Finalidade { get; set; } = new CategoriaFinalidadeDTO();

        }
        public class CategoriaDTOCreate
        {
            public string Nome { get; set; } = string.Empty;
            public ECategoriaEnum Finalidade { get; set; }
        }
        public class CategoriaDTOUpdate
        {
            public int Codigo { get; set; }
            public string Nome { get; set; } = string.Empty;
            public ECategoriaEnum Finalidade { get; set; }
        }

        public class CategoriaFinalidadeDTO
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; } = string.Empty;
        }
    }
}
