namespace mytodo.shareable.Excecoes;

public class ExcecaoAplicacao : Exception
{
    public ExcecaoAplicacao(ResultadoErro erro)
        : base(erro.Descricao) => ResponseErro = erro;

    public ResultadoErro ResponseErro { get; }
}