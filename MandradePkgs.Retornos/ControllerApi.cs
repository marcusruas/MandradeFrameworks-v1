using MandradePkgs.Retornos.Mensagens;
using MandradePkgs.Retornos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos
{
    public class ControllerApi : ControllerBase
    {
        private MensagensApi _mensagens { get; }
        public ControllerApi() {
            _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
        }
        public RespostaApi RespostaPadrao() {
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi(_mensagens);
        }

        public RespostaApi RespostaPadrao(dynamic dados) {
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi(dados, _mensagens);
        }

        public RespostaApi RespostaPadrao(bool sucesso, dynamic dados) {
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi(sucesso, dados, _mensagens);
        }
    }
}
