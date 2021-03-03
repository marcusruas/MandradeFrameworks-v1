namespace MandradePkgs.Autenticacao.Estrutura.Token
{
    public sealed class UsuarioToken
    {
        public UsuarioToken(int usuario, int grupo, int pessoa)
        {
            Usuario = usuario;
            Grupo = grupo;
            Pessoa = pessoa;
        }
        public int Usuario;
        public int Grupo;
        public int Pessoa;
    }
}