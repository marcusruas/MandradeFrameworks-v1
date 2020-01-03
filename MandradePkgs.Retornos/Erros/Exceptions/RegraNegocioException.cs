namespace MandradePkgs.Retornos.Erros.Exceptions
{
    public class RegraNegocioException : ApiException
    {
        public RegraNegocioException(string mensagem) {
            MensagemPadrao = "Informações digitadas inválidas. Verifique as informações e tente novamente.";
            DescricaoErro = mensagem;
        }

        public RegraNegocioException(string mensagem, string mensagemPadrao) {
            MensagemPadrao = mensagemPadrao;
            DescricaoErro = mensagem;
        }

        public override int CodigoRetorno => 7010;

        public override string MensagemPadrao { get; }

        public override string DescricaoErro { get; }
    }
}
