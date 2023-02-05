using PlanoContas.Domain.Conta.Entity;

namespace PlanoContas.Domain.Conta.Dto;

public class SugestaoCodigoContaDto
{
    public SugestaoCodigoContaDto(CodigoConta? codigoContaPai, CodigoConta codigoConta)
    {
        CodigoContaPai = codigoContaPai?.ToString();
        CodigoConta = codigoConta.ToString();
    }
    public string? CodigoContaPai { get; set; }
    public string CodigoConta { get; set; }
}