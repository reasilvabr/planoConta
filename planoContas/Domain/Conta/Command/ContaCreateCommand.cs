using MediatR;

namespace PlanoContas.Domain.Conta.Command;

public class ContaCreateCommand : IRequest
{
    public string Codigo { get; set; }
    public string CodigoPai { get; set; }
    public string Nome { get; set; }
    public int Tipo { get; set; }
    public bool AceitaLancamento { get; set; }
}