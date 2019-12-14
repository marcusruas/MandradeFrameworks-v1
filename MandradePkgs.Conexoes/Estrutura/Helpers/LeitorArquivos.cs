using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MandradePkgs.Conexoes.Estrutura.Models;
using Newtonsoft.Json;

namespace MandradePkgs.Conexoes.Estrutura.Helpers
{
    internal static class LeitorArquivos
    {   
        public static string LerArquivoSQL(Type classe, string nomeArquivo) {
            string pathApi = Path.GetDirectoryName(classe.Assembly.CodeBase);
            string conteudoArquivo = string.Empty;

            try {
                string namespaceOriginal = classe.Namespace.Split('.')[1]; //Repositorio.NameSpace
                string pathArquivo = Path.Combine(pathApi, namespaceOriginal, "SQL", $"{nomeArquivo}.sql");
                pathArquivo = pathArquivo.Replace("file:\\", "");

                string[] linhas;

                if (!File.Exists(pathArquivo))
                    throw new Exception("Não foi possível localizar o arquivo de consulta ao banco com este nome.");

                linhas = File.ReadAllLines(pathArquivo);
                foreach (string linha in linhas)
                    conteudoArquivo += (linha + " ");
            } catch (ArgumentNullException) {
                throw new Exception("O arquivo de consulta ao banco de dados está vazio.");
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return conteudoArquivo;
        }

        public static string BuscarConnectionString(Type classe, string nomeBanco) {
            string pathApi = Path.GetDirectoryName(classe.Assembly.CodeBase);
            string arquivoConexao = Path.Combine(pathApi, "conexoes.json").Replace("file:\\", "");

            if(!File.Exists(arquivoConexao))
                throw new Exception($"Arquivo de conexões não existe em {arquivoConexao}");

            List<PadraoConexao> conexoes;
            try {
                using (StreamReader r = new StreamReader(arquivoConexao)) {
                    var json = r.ReadToEnd();
                    conexoes = JsonConvert.DeserializeObject<PadraoConexao[]>(json).ToList();
                }
                foreach (var con in conexoes)
                    if (con.Nome == nomeBanco)
                        return con.ConnectionString;
                return null;
            } catch (Exception) {
                throw new Exception("Ocorreu um erro ao obter as conexões necessárias.");
            }
        }
    }
}
