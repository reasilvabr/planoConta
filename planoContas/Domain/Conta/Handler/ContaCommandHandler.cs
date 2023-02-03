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
        var conta = new Conta.Entity.Conta(new CodigoConta(request.Codigo), request.Nome, (ETipoConta)request.Tipo, request.AceitaLancamento);
        await _repository.CreateConta(conta);
        return Unit.Value;
    }

    public async Task<Unit> Handle(ContaUpdateCommand request, CancellationToken cancellationToken)
    {
        var conta = new Conta.Entity.Conta(new CodigoConta(request.Codigo), request.Nome, (ETipoConta)request.Tipo, request.AceitaLancamento);
        await _repository.UpdateConta(conta);
        return Unit.Value;
    }

    public async Task<Unit> Handle(ContaDeleteCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteConta(new CodigoConta(request.Codigo));
        return Unit.Value;
    }
}