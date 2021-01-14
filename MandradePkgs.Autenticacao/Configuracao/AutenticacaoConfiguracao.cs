using Microsoft.Extensions.DependencyInjection;
using MandradePkgs.Autenticacao.Estrutura.Token;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace MandradePkgs.Autenticacao.Configuracao
{
    public static class AutenticacaoConfiguracao
    {
        public static void ImplementarAutenticacaoJWT(this IServiceCollection servicos, IConfiguration configuracao) {
            var assinatura = new AssinaturaToken();
            var configuracoes = new ConfiguracoesToken();
            string sectionTokenDados = "ConfiguracoesToken";

            new ConfigureFromConfigurationOptions<ConfiguracoesToken>(configuracao.GetSection(sectionTokenDados))
            .Configure(configuracoes);

            servicos.AddSingleton(assinatura);
            servicos.AddSingleton(configuracoes);

            servicos.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var parametrosValidacao = bearerOptions.TokenValidationParameters;
                parametrosValidacao.IssuerSigningKey = assinatura.Key;
                parametrosValidacao.ValidIssuer = configuracoes.Originador;
                parametrosValidacao.ClockSkew = TimeSpan.Zero;

                parametrosValidacao.ValidateIssuerSigningKey = true;
                parametrosValidacao.ValidateLifetime = true;
            });

            servicos.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }

        public static void ImplementarAutenticacaoJWTSwagger(this SwaggerGenOptions swaggerCnf) {
            swaggerCnf.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                In = ParameterLocation.Header, 
                Description = "Por favor insira o token JWT no campo abaixo.",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey 
            });
            swaggerCnf.AddSecurityRequirement(new OpenApiSecurityRequirement {
            { 
                new OpenApiSecurityScheme 
                { 
                Reference = new OpenApiReference 
                { 
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer" 
                } 
                },
                new string[] { } 
                } 
            });
        }
    }
}
