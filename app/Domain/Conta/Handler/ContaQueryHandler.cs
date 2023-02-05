using MediatR;
using PlanoContas.Domain.Conta.Adapter;
using PlanoContas.Domain.Conta.Dto;
using PlanoContas.Domain.Conta.Entity;
using PlanoContas.Domain.Conta.Query;
using PlanoContas.Infra.Repository;

namespace PlanoContas.Domain.Conta.Handler;

public class ContaQueryHandler :
    IRequestHandler<ContaGetQuery, IEnumerable<Conta.Entity.Conta>>,
    IRequestHandler<ContaPaiGetQuery, IEnumerable<Conta.Entity.Conta>>,
    IRequestHandler<CodigoContaGetQuery, SugestaoCodigoContaDto>
{

    private readonly IContasRepository _repository;

    public ContaQueryHandler(IContasRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Conta.Entity.Conta>> Handle(ContaGetQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetContasAsync();
    }

    public async Task<IEnumerable<Entity.Conta>> Handle(ContaPaiGetQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetContasPaiAsync();
    }

    public async Task<SugestaoCodigoContaDto> Handle(CodigoContaGetQuery request, CancellationToken cancellationToken)
    {
        Conta.Entity.Conta? contaPai = null;
        CodigoConta? codigoContaPai = null;
        CodigoContaAdapter adapter =
            new CodigoContaAdapter(await _repository.GetContasAsync());
        if (request.CodigoPai != null)
        {
            codigoContaPai = new CodigoConta(request.CodigoPai);
            contaPai = await _repository.GetContaAsync(codigoContaPai);
        }

        var codigos = adapter.ProximoCodigo(codigoContaPai);
        return new SugestaoCodigoContaDto(codigos.Item1, codigos.Item2);
    }
}