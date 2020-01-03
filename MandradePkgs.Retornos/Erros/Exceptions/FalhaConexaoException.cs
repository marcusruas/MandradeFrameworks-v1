namespace MandradePkgs.Retornos.Erros.Exceptions
{
    public class FalhaConexaoException : ApiException
    {
        public FalhaConexaoException(string mensagem) {
            MensagemPadrao = "Ocorreu uma falha ao enviar as informações. Reinicie o navegador ou tente novamente mais tarde";
            DescricaoErro = mensagem;
        }

        public FalhaConexaoException(string mensagem, string mensagemPadrao) {
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = mensagem;
        }

        public override int CodigoRetorno => 7030;

        public override string MensagemPadrao { get; }

        public override string DescricaoErro { get; }
    }
}
