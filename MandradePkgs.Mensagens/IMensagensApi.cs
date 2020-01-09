using System.Collections.Generic;

namespace MandradePkgs.Mensagens
{
    public interface IMensagensApi
    {
        List<Mensagem> Mensagens { get; }
        void AdicionarMensagem(string mensagem);
        void AdicionarMensagem(TipoMensagem tipoMensagem, string mensagem);
        bool PossuiMensagensErro();
    }
}
