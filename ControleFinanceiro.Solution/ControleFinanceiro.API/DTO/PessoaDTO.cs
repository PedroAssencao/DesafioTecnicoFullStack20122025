namespace ControleFinanceiro.API.DTO
{
    public class PessoaDTO
    {
        public class PessoaDTOView
        {
            public int Codigo { get; set; }
            public string Nome { get; set; } = string.Empty;
            public int Idade { get; set; }
            public List<TransacoesDTO.TranscacoesDTOViewForPessoa> Transacoes { get; set; } = new List<TransacoesDTO.TranscacoesDTOViewForPessoa>();
        }
        public class PessoaDTOViewForTransacoes
        {
            public int Codigo { get; set; }
            public string Nome { get; set; } = string.Empty;
            public int Idade { get; set; }
        }

        public class PessoaDTOCreate
        {
            public string Nome { get; set; } = string.Empty;
            public int Idade { get; set; }
        }

        public class PessoaDTOUpdate
        {
            public int Codigo { get; set; }
            public string Nome { get; set; } = string.Empty;
            public int Idade { get; set; }
        }
    }
}
