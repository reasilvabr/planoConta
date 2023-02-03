using MediatR;

namespace PlanoContas.Domain.Conta.Command;

public class ContaDeleteCommand : IRequest
{
    public string Codigo { get; set; }
}