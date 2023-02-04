using MediatR;
using PlanoContas.Domain.Conta.Command;
using PlanoContas.Domain.Conta.Entity;
using PlanoContas.Infra.Repository;

namespace PlanoContas.Domain.Conta.Handler;

public class ContaCommandHandler : 
    IRequestHandler<ContaCreateCommand>,
    IRequestHandler<ContaUpdateCommand>,
    IRequestHandler<ContaDeleteCommand>
{
    private readonly IContasRepository _repository;

    public ContaCommandHandler(IContasRepository repository){
        _repository = repository;
    }


    public async Task<Unit> Handle(ContaCreateCommand request, CancellationToken cancellationToken)
    {
        Conta.Entity.Conta? contaPai = null;
        if(request.CodigoPai != null)
        {
            contaPai = await _repository.GetContaAsync(new CodigoConta(request.CodigoPai));
        }
        var conta = 
            new Conta.Entity.Conta(
                new CodigoConta(request.Codigo),
                null,
                request.Nome, 
                (ETipoConta)request.Tipo, 
                request.AceitaLancamento);
        conta.ContaPai = contaPai;
        await _repository.CreateContaAsync(conta);
        return Unit.Value;
    }

    public async Task<Unit> Handle(ContaUpdateCommand request, CancellationToken cancellationToken)
    {
        Conta.Entity.Conta? contaPai = null;
        if(request.CodigoPai != null)
        {
            contaPai = await _repository.GetContaAsync(new CodigoConta(request.CodigoPai));
        }
        var conta = 
            new Conta.Entity.Conta(
                new CodigoConta(request.Codigo),
                null,
                request.Nome, 
                (ETipoConta)request.Tipo, 
                request.AceitaLancamento);
        conta.ContaPai = contaPai;
        await _repository.UpdateContaAsync(conta);
        return Unit.Value;
    }

    public async Task<Unit> Handle(ContaDeleteCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteContaAsync(new CodigoConta(request.Codigo));
        return Unit.Value;
    }
}