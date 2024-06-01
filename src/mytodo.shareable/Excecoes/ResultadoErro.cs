using mytodo.shareable.Enums;

namespace mytodo.shareable.Excecoes;

public class ResultadoErro
{
    public string Titulo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public ETipoErro Tipo { get; set; }
}