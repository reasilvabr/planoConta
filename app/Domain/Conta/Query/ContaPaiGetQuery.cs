using MediatR;

namespace PlanoContas.Domain.Conta.Query;

public class ContaPaiGetQuery : IRequest<IEnumerable<Conta.Entity.Conta>>
{
}