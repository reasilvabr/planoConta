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
    public async Task<IEnumerable<ContaDto>> GetContas([FromQuery] bool pai)
    {
        IEnumerable<Conta> retorno;
        if (pai)
        {
            var paiQuery = new ContaPaiGetQuery();
            retorno = await _mediator.Send<IEnumerable<Conta>>(paiQuery);
        }
        var query = new ContaGetQuery();
        retorno = await _mediator.Send<IEnumerable<Conta>>(query);

        return retorno.OrderBy(c => c.CodigoConta).Select(c => new ContaDto(c));
    }

    [HttpPost(Name = "CreateConta")]
    public void CreateConta([FromBody] ContaCreateCommand command)
    {
        _mediator.Send(command);
    }
}