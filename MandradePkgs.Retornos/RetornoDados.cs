using System;
using System.Threading;
using MandradePkgs.Retornos.Exceptions;
using MandradePkgs.Retornos.Models;

namespace MandradePkgs.Retornos
{
    public static class RetornoDados
    {
        public static RespostaApi GerarRetornoPadrao(){
            return new RespostaApi();
        }

        public static RespostaApi GerarRetornoPadrao(dynamic parametros){
            return new RespostaApi(true, parametros);
        }
    }
}