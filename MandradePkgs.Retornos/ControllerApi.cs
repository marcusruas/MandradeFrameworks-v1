using MandradePkgs.Retornos.Mensagens;
using Microsoft.AspNetCore.Mvc;


namespace MandradePkgs.Retornos
{
    public class ControllerApi : ControllerBase
    {
        public RespostaApi RespostaPadrao() {
            var _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 204;
            return new RespostaApi(_mensagens);
        }

        public RespostaApi RespostaPadrao(bool sucesso) {
            var _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi(sucesso, _mensagens);
        }

        public RespostaApi<T> RespostaPadrao<T>(T dados) {
            var _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi<T>(dados, _mensagens);
        }

        public RespostaApi<T> RespostaPadrao<T>(bool sucesso, T dados) {
            var _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi<T>(sucesso, dados, _mensagens);
        }
    }
}
