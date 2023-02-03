using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanoContas.Domain.Conta.Command;
using PlanoContas.Domain.Conta.Dto;
using PlanoContas.Domain.Conta.Entity;
using PlanoContas.Domain.Conta.Query;

namespace PlanoContas.Controllers;

[ApiController]
[Route("[controller]")]
public class CodigoContaController : ControllerBase
{
    private readonly IMediator _mediator;
    public CodigoContaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetProximoCodigo")]
    public string GetProximoCodigo([FromQuery]string? codigoPai)
    {
        var query = new CodigoContaGetQuery(codigoPai);
        return "ok";
    }
}