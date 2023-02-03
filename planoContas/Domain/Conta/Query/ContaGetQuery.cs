using MediatR;

namespace PlanoContas.Domain.Conta.Query;

public class ContaGetQuery : IRequest<IEnumerable<Conta.Entity.Conta>>
{

}