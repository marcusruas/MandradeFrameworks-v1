using MandradePkgs.Retornos.Exceptions;
using System;

namespace MandradePkgs.Retornos.Models
{
    public class RespostaApi
    {
        public RespostaApi()
        {
            Sucesso = true;
            Dados = "Método executado com sucesso";
        }
        public RespostaApi(bool sucesso)
        {
            Sucesso = sucesso;
            Dados = null;
        }

        public RespostaApi(bool sucesso, dynamic dados)
        {
            Sucesso = sucesso;
            Dados = dados;
        }

        public RespostaApi(Exception ex) {
            Sucesso = false;
            Dados = ex;
        }

        public bool Sucesso { get; }
        public dynamic Dados { get; }
    }
}