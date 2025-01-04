namespace DevFreela.Application.UtilMessage
{
    public static class DialogMessage
    {
        public static string ProjectNotFound = "Project not found.";
        public static string EmailOuSenhaInvalidos = "Email ou senha inválidos.";


        #region Validators

        public static string NaoPodeSerVazio = "Não pode ser vazio.";
        public static string ValorMinimoProjeto(decimal valorMinimo) => $"Valor minimo do projeto é de R$ {valorMinimo}";
        public static string TamanhoMaximo(int quantidade) => $"Tamanho máximo é de {quantidade} caracteres.";
        public static string EmailInvalido = "E-mail inválido.";
        public static string IdadeInvalida = "Deve ser maior de 18 anos para continuar.";


        #endregion
    }
}
