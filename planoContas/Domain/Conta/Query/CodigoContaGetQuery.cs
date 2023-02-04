using MediatR;
using PlanoContas.Domain.Conta.Dto;

namespace PlanoContas.Domain.Conta.Query;

public class CodigoContaGetQuery : IRequest<SugestaoCodigoContaDto>
{
    public CodigoContaGetQuery(string? codigoPai)
    {
        CodigoPai = codigoPai;
    }
    public string? CodigoPai { get; set; }
}