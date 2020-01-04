using MandradePkgs.Retornos.Erros;
using MandradePkgs.Retornos.Erros.Exceptions;
using MandradePkgs.Retornos.Mensagens;
using System;
using System.Collections.Generic;

namespace MandradePkgs.Retornos.Models
{
    public class RespostaApi
    {
        public RespostaApi(MensagensApi mensagens)
        {
            Sucesso = true;
            Dados = "Método executado com sucesso";
            Mensagens = mensagens.ObterMensagens();
        }

        public RespostaApi(bool sucesso, dynamic dados, MensagensApi mensagens)
        {
            Sucesso = sucesso;
            Dados = dados;
            Mensagens = mensagens.ObterMensagens();
        }

        public RespostaApi(bool sucesso, MensagensApi mensagens) {
            Sucesso = sucesso;
            Dados = null;
            Mensagens = mensagens.ObterMensagens();
        }

        public RespostaApi(dynamic dados, MensagensApi mensagens) {
            Sucesso = true;
            Dados = dados;
            Mensagens = mensagens.ObterMensagens();
        }

        public RespostaApi(Exception ex, MensagensApi mensagens) {
            Sucesso = false;
            Dados = new FalhaExecucaoException(ex.Message);
            Mensagens = mensagens.ObterMensagens();
        }

        public RespostaApi(ApiExceptionModel erro, MensagensApi mensagens) {
            Sucesso = false;
            Dados = erro;
            Mensagens = mensagens.ObterMensagens();
        }

        public bool Sucesso { get; }
        public dynamic Dados { get; }
        public List<Mensagem> Mensagens { get; }
    }
}