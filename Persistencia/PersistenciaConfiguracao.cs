﻿using MandradePkgs.Persistencia;
using MandradePkgs.Persistencia.Estrutura.Implementacao;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia
{
    public static class PersistenciaConfiguracao
    {
        public static void ImplementarConexaoSQL(this IServiceCollection servicos, Type classe) {
            servicos.AddSingleton<IConexaoSQL, ConexaoSQL>(imp => new ConexaoSQL(classe));
        }
    }
}
