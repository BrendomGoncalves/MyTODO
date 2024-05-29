namespace mytodo.shareable.Excecoes;

public class SemResultadosExcecao : ExcecaoAplicacao
{
    public SemResultadosExcecao() : 
        base(Enums.Cadastro.SemResultados){}
}