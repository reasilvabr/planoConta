using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanoContas.Domain.Conta.Command;
using PlanoContas.Domain.Conta.Dto;
using PlanoContas.Domain.Conta.Entity;
using PlanoContas.Domain.Conta.Query;

namespace PlanoContas.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaController : ControllerBase
{
    private readonly IMediator _mediator;
    public ContaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetContasPai")]
    public async Task<IEnumerable<ContaDto>> GetContas([FromQuery] bool? pai = null)
    {
        IEnumerable<Conta> retorno;

        if (pai.HasValue && pai.Value)
        {
            var paiQuery = new ContaPaiGetQuery();
            retorno = await _mediator.Send<IEnumerable<Conta>>(paiQuery);
        }
        else
        {
            var query = new ContaGetQuery();
            retorno = await _mediator.Send<IEnumerable<Conta>>(query);
        }
        return retorno.OrderBy(c => c.CodigoConta).Select(c => new ContaDto(c));
    }

    [HttpPost(Name = "CreateConta")]
    public async Task CreateConta([FromBody] ContaCreateCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpPut(Name = "UpdateConta")]
    public async Task UpdateConta([FromBody] ContaUpdateCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpDelete(Name = "DeleteConta")]
    public async Task DeleteConta([FromQuery] string codigo)
    {
        var command = new ContaDeleteCommand(codigo);
        await _mediator.Send(command);
    }
}