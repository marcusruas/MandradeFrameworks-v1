namespace MandradePkgs.Retornos.Erros.Exceptions
{
    public class FalhaConexaoExternaException : ApiException
    {
        public FalhaConexaoExternaException(string mensagem) {
            MensagemPadrao = "Ocorreu uma falha ao enviar as informações. Contate o suporte para mais informações.";
            DescricaoErro = mensagem;
        }

        public FalhaConexaoExternaException(string mensagem, string mensagemPadrao) {
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = mensagem;
        }

        public override int CodigoRetorno => 7040;

        public override string MensagemPadrao { get; }

        public override string DescricaoErro { get; }
    }
}
