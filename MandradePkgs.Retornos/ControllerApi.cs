using MandradePkgs.Mensagens;
using Microsoft.AspNetCore.Mvc;


namespace MandradePkgs.Retornos
{
    public class ControllerApi : ControllerBase
    {
        public ControllerApi() {
        }

        protected RespostaApi RespostaPadrao() {
            var _mensagens = (IMensagensApi)HttpContext.RequestServices.GetService(typeof(IMensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() || _mensagens.PossuiFalhasValidacao() ? 400 : 204;
            return new RespostaApi(_mensagens.Mensagens);
        }

        protected RespostaApi RespostaPadrao(bool sucesso) {
            var _mensagens = (IMensagensApi)HttpContext.RequestServices.GetService(typeof(IMensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() || _mensagens.PossuiFalhasValidacao() ? 400 : 200;
            return new RespostaApi(sucesso, _mensagens.Mensagens);
        }

        protected RespostaApi<T> RespostaPadrao<T>(T dados) {
            var _mensagens = (IMensagensApi)HttpContext.RequestServices.GetService(typeof(IMensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() || _mensagens.PossuiFalhasValidacao() ? 400 : 200;
            return new RespostaApi<T>(dados, _mensagens.Mensagens);
        }

        protected RespostaApi<T> RespostaPadrao<T>(bool sucesso, T dados) {
            var _mensagens = (IMensagensApi)HttpContext.RequestServices.GetService(typeof(IMensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() || _mensagens.PossuiFalhasValidacao() ? 400 : 200;
            return new RespostaApi<T>(sucesso, dados, _mensagens.Mensagens);
        }
    }
}
