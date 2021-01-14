using MandradePkgs.ConfiguracaoAPI.Estrutura.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using static MandradePkgs.Conexoes.Configuracao.ConfiguracaoConexoes;
using static MandradePkgs.Mensagens.Configuracao.MensagensConfiguracao;
using static MandradePkgs.Retornos.Configuracao.RetornosConfiguracao;
using static MandradePkgs.Autenticacao.Configuracao.AutenticacaoConfiguracao;

namespace MandradePkgs.ConfiguracaoAPI.Configuracao
{
    public static class ConfiguracaoAPI
    {
        public static void ImplementarMandradePKGS(this IServiceCollection servicos, IConfiguration configuracoes, MvcOptions mvcConfiguracoes, Type startup) {
            servicos.ImplementarConexaoSQL(startup);
            servicos.ImplementarMensagensServico();
            servicos.ImplementarAutenticacaoJWT(configuracoes);
            mvcConfiguracoes.ImplementarFiltrosRetorno();
        }

        public static void ImplementarConfiguracoesServicos(this IServiceCollection servicos) {
            servicos.AddSwaggerGen(cnf => cnf.ImplementarAutenticacaoJWTSwagger());
            servicos.AddCors(options =>
            {
                options.AddPolicy("Permissionamentos",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowAnyOrigin());
            });
        }

        public static void ImplementarConfiguracoesMiddlewares(IApplicationBuilder aplicacao, SwaggerParametros swaggerParametros) {
            aplicacao.UseSwagger();
            aplicacao.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{swaggerParametros.NomeAPI} {swaggerParametros.Versao}");
            });

            aplicacao.UseCors("Permissionamentos");
            aplicacao.UseHttpsRedirection();

            aplicacao.UseMvc();
        }
        
    }
}