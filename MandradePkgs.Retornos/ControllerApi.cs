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
        public RespostaApi RespostaPadrao() {
            var _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi(_mensagens);
        }

        public RespostaApi RespostaPadrao(bool sucesso) {
            var _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi(sucesso, _mensagens);
        }

        public RespostaApi RespostaPadrao(dynamic dados) {
            var _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi(dados, _mensagens);
        }

        public RespostaApi RespostaPadrao(bool sucesso, dynamic dados) {
            var _mensagens = (MensagensApi)HttpContext.RequestServices.GetService(typeof(MensagensApi));
            Response.StatusCode = _mensagens.PossuiMensagensErro() ? 400 : 200;
            return new RespostaApi(sucesso, dados, _mensagens);
        }
    }
}
