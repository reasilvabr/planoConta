using MediatR;
using PlanoContas.Domain.Conta.Entity;
using PlanoContas.Domain.Conta.Query;
using PlanoContas.Infra.Repository;

namespace PlanoContas.Domain.Conta.Handler;

public class ContaQueryHandler : 
    IRequestHandler<ContaGetQuery, IEnumerable<Conta.Entity.Conta>>,
    IRequestHandler<ContaPaiGetQuery, IEnumerable<Conta.Entity.Conta>>,
    IRequestHandler<CodigoContaGetQuery, string>
{

    private readonly IContasRepository _repository;

    public ContaQueryHandler(IContasRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Conta.Entity.Conta>> Handle(ContaGetQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetContas();
    }

    public async Task<IEnumerable<Entity.Conta>> Handle(ContaPaiGetQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetContasPai();
    }

    public async Task<string> Handle(CodigoContaGetQuery request, CancellationToken cancellationToken)
    {
        Conta.Entity.Conta? contaPai = null;
        if(request.CodigoPai != null)
        {
            var codigoContaPai = new CodigoConta(request.CodigoPai);
            contaPai = await _repository.GetConta(codigoContaPai);
        }
        return string.Empty;
    }
}