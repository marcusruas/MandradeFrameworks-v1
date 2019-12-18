using System;
using MandradePkgs.Retornos.Exceptions;
using MandradePkgs.Retornos.Models;

namespace MandradePkgs.Retornos
{
    public static class FormatadorRetornos
    {
        public static RespostaApi GerarRetornoPadrao(){
            return new RespostaApi();
        }

        public static RespostaApi GerarRetornoPadrao(Func<dynamic> metodo){
            try{
                var dados = metodo.Invoke();
                return new RespostaApi(true, dados);
            }catch(Exception ex){
                throw new FalhaExecucaoException(ex.Message);
            }
        }

        public static RespostaApi GerarRetornoPadrao(Action metodo){
            try{
                metodo.Invoke();
                return new RespostaApi();
            }catch(Exception ex){
                throw new FalhaExecucaoException(ex.Message);
            }
        }

        public static RespostaApi ErroNegocio(string mensagem) {

        }
    }
}