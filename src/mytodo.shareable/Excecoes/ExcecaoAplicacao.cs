using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Excecoes;

[ExcludeFromCodeCoverage]
public class ExcecaoAplicacao : Exception
{
    public ExcecaoAplicacao(ResultadoErro erro)
        : base(erro.Descricao) => ResponseErro = erro;

    public ResultadoErro ResponseErro { get; }
}