using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace MandradePkgs.Autenticacao.Estrutura.Token
{
    public class AssinaturaToken
    {
        public AssinaturaToken()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            credenciais = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
        public SecurityKey Key { get; }
        public SigningCredentials credenciais { get; }
    }
}