using System;

namespace MandradePkgs.Autenticacao.Estrutura.Token
{
    public class Token
    {
        public Token(string tokenAcesso, DateTime dataCriacao, DateTime dataExpiracao)
        {
            this.TokenAcesso = tokenAcesso;
            this.DataCriacao = dataCriacao;
            this.DataExpiracao = dataExpiracao;
        }
        public string TokenAcesso { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}