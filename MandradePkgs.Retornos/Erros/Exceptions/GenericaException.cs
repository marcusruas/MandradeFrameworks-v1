namespace MandradePkgs.Retornos.Erros.Exceptions
{
    public class GenericaException : ApiException
    {
        public GenericaException(string mensagem) {
            MensagemPadrao = "Ocorreu uma falha ao realizar a ação solicitada. Reinicie o navegador ou tente novamente mais tarde";
            DescricaoErro = mensagem;
        }

        public GenericaException(string mensagem, string mensagemPadrao) {
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = mensagem;
        }

        public override int CodigoRetorno => 7050;

        public override string MensagemPadrao { get; }

        public override string DescricaoErro { get; }
    }
}
