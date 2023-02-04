using MediatR;

namespace PlanoContas.Domain.Conta.Command;

public class ContaDeleteCommand : IRequest
{
    public ContaDeleteCommand(string codigo)
    {
        Codigo = codigo;
    }
    public string Codigo { get; set; }
}