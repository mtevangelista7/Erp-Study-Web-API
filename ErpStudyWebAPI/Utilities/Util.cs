using Microsoft.Extensions.Configuration;

namespace ErpStudyWebAPI.Utilities
{
    public abstract class Util
    {   
        public static string StringConexao { get; set; }
        
        public abstract class MensagensStrings
        {
            public const string RecursoNaoEncontrado = "O recurso especificado não foi encontrado";
            public const string ErroTentarAtualizarRecurso = "Erro ao tentar atualizar recurso fornecido";
            public const string ErroTentarGerarRecurso = "Erro ao tentar gerar recurso";
            public const string ErroTentarCadastrarRecurso = "Erro ao tentar cadastrar recurso";
            public const string ErroTentarDeletarRecurso = "Erro ao tentar deletar o usuário";
            public const string RecursoFornecidoForaEsperado = "O objeto fornecido no corpo da solicitação não está de acordo com o esperado";
            public const string AcessoNaoAutorizado = "Acesso não autorizado. Verifique seu token de acesso e tente novamente.";
        }
    }
}
