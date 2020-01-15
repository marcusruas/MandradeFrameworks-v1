using Dapper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;

namespace MandradePkgs.Conexoes.Mapeamentos
{
    public static class DboSqlMapper
    {

        public static DynamicParameters MapearParaDbo<T>(T dados) {
            DynamicParameters parametros = new DynamicParameters();
            var parametrosClasse = typeof(T).GetProperties();

            foreach (var prop in parametrosClasse) {
                var dadosProp = dados.GetType().GetProperty(prop.Name).GetValue(dados);

                var descricao = ObterDescription(prop);
                var tipo = ObterTipo(prop.PropertyType);
                var tamanho = ObterTamanho(prop);

                if (tipo.HasValue && (tipo.Value == DbType.Int16 || tipo.Value == DbType.Int32 || tipo.Value == DbType.Int64))
                    if ((int)dadosProp == 0)
                        continue;
                if (dadosProp == null) continue;


                parametros.Add(descricao, dadosProp, tipo, size: tamanho);

            }

            return parametros;
        }

        private static string ObterDescription(PropertyInfo prop) {
            var description = prop.GetCustomAttribute<DescriptionAttribute>();
            return description == null ? prop.Name : description.Description;
        }

        private static int? ObterTamanho(PropertyInfo prop) {
            var description = prop.GetCustomAttribute<StringLengthAttribute>();

            if (description == null)
                return null;
            if (description.MinimumLength != 0 && description.MaximumLength == 0)
                return description.MinimumLength;

            return description.MaximumLength;
        }

        private static DbType? ObterTipo(Type prop) {
            var tiposSQL = Enum.GetValues(typeof(DbType));
            foreach (var tipo in tiposSQL)
                if (tipo.ToString() == prop.Name)
                    return (DbType)tipo;

            if (prop.Name == "Long")
                return DbType.Int64;

            return null;
        }
    }
}
