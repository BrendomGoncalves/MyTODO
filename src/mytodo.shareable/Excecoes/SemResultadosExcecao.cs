using System.Diagnostics.CodeAnalysis;

namespace mytodo.shareable.Excecoes;

[ExcludeFromCodeCoverage]
public class SemResultadosExcecao : ExcecaoAplicacao
{
    public SemResultadosExcecao() : 
        base(Enums.Cadastro.SemResultados){}
}