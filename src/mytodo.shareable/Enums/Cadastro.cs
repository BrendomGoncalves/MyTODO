using mytodo.shareable.Excecoes;

namespace mytodo.shareable.Enums;

public class Cadastro
{
    public static readonly ResultadoErro Generico = new()
    {
        Titulo = "Erro ao processar sua solicitação",
        Descricao = "No momento, nosso sistema está indisponível. Por favor tente novamente.",
        Tipo = ETipoErro.Erro
    };
    
    public static readonly ResultadoErro FalhaAoAtualizar = new()
    {
        Titulo = "Erro ao processar atualização",
        Descricao = "Infelizmente, ocorreu um erro ao tentarmos atualizar. Por favor tente novamente.",
        Tipo = ETipoErro.Erro
    };
    
    public static readonly ResultadoErro FalhaAoDeletar = new()
    {
        Titulo = "Erro ao processar deleção",
        Descricao = "Infelizmente, ocorreu um erro ao tentarmos deletar. Por favor tente novamente.",
        Tipo = ETipoErro.Erro
    };

    public static readonly ResultadoErro FalhaAoCriar = new()
    {
        Titulo = "Erro ao processar criação",
        Descricao = "Infelizmente, ocorreu um erro ao tentarmos criar. Por favor tente novamente.",
        Tipo = ETipoErro.Erro
    };

    public static readonly ResultadoErro SemResultados = new()
    {
        Titulo = "Busca sem resultados",
        Descricao =
            "Infelizmente, não encontramos resultados para sua solicitação. Tente novamente com outros parâmetros.",
        Tipo = ETipoErro.Alerta
    };

    public static readonly ResultadoErro BuscaNaoEncontrada = new()
    {
        Titulo = "Busca sem resultados",
        Descricao =
            "Infelizmente, não encontramos resultados para sua solicitação. Verifique se o ID fornecido existe.",
        Tipo = ETipoErro.Alerta
    };
}