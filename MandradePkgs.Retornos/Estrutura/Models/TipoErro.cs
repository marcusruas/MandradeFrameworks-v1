using System;
using System.Collections.Generic;
using System.Text;

namespace MandradePkgs.Retornos.Estrutura.Models
{
    public enum TipoErro
    {
        RegraNegocio,
        FalhaConexaoBanco,
        FalhaConexaoExterna,
        FalhaExecucao,
        Generico
    }
}
